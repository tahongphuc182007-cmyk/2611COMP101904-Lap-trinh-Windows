using System.Data;
using Microsoft.Data.SqlClient;

namespace QLSinhVienLab12.DAL;

/// <summary>Truy cập database cho module kết quả học tập; mọi thao tác đều gọi stored procedure có tham số.</summary>
public class KetQuaDAL
{
    public DataTable GetLop()
    {
        return ExecuteProcedure("sp_Lop_GetAll");
    }

    public DataTable GetMonHoc()
    {
        return ExecuteProcedure("sp_MonHoc_GetAll");
    }

    /// <summary>Danh sách sinh viên của lớp kèm điểm môn học (Diem là NULL nếu chưa có điểm).</summary>
    public DataTable GetKetQuaByLopMon(string maLop, string maMon)
    {
        return ExecuteProcedure("sp_KetQua_GetByLopMon",
            new SqlParameter("@MaLop", SqlDbType.NVarChar, 20) { Value = maLop },
            new SqlParameter("@MaMon", SqlDbType.NVarChar, 20) { Value = maMon });
    }

    private static DataTable ExecuteProcedure(string procedureName, params SqlParameter[] parameters)
    {
        using SqlConnection conn = new SqlConnection(Database.ConnectionString);
        using SqlCommand cmd = new SqlCommand(procedureName, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddRange(parameters);

        using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    /// <summary>
    /// Lưu điểm của tất cả dòng trong MỘT transaction: chỉ commit khi mọi dòng đều lưu được,
    /// có lỗi ở bất kỳ dòng nào thì rollback toàn bộ rồi ném lại lỗi.
    /// Trả về số dòng đã lưu.
    /// </summary>
    public int SaveAll(string maMon, DataTable table)
    {
        using SqlConnection conn = new SqlConnection(Database.ConnectionString);
        conn.Open();

        using SqlTransaction trans = conn.BeginTransaction();
        try
        {
            // Command gắn với transaction (tham số thứ ba), nếu không transaction sẽ không có tác dụng
            using SqlCommand cmd = new SqlCommand("sp_KetQua_Save", conn, trans);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter pMaSV = cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar, 20);
            SqlParameter pMaMon = cmd.Parameters.Add("@MaMon", SqlDbType.NVarChar, 20);
            SqlParameter pDiem = cmd.Parameters.Add("@Diem", SqlDbType.Float);
            SqlParameter pGhiChu = cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 255);
            pMaMon.Value = maMon;

            int count = 0;
            foreach (DataRow row in table.Rows)
            {
                pMaSV.Value = Convert.ToString(row["MaSV"]);
                pDiem.Value = Convert.ToDouble(row["Diem"]);
                pGhiChu.Value = Convert.ToString(row["GhiChu"]) ?? string.Empty;

                cmd.ExecuteNonQuery();
                count++;
            }

            trans.Commit();   // chỉ commit một lần, sau khi tất cả dòng đã lưu thành công
            return count;
        }
        catch
        {
            trans.Rollback(); // hủy toàn bộ các dòng đã lưu trước đó trong lần bấm này
            throw;
        }
    }
}
