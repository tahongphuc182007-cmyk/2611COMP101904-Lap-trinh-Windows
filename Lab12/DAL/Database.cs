using System.Text.Json;

namespace QLSinhVienLab12.DAL;

/// <summary>
/// Giữ chuỗi kết nối. Chuỗi được đọc từ appsettings.json nên đổi máy hoặc đổi server
/// chỉ cần sửa file này, không cần biên dịch lại.
/// </summary>
public static class Database
{
    private static string? connectionString;

    public static string ConnectionString => connectionString ??= LoadConnectionString();

    private static string LoadConnectionString()
    {
        string path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        if (!File.Exists(path))
            throw new FileNotFoundException("Không tìm thấy file appsettings.json cạnh file chạy.", path);

        using JsonDocument document = JsonDocument.Parse(File.ReadAllText(path));
        string? value = document.RootElement.GetProperty("ConnectionString").GetString();
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidOperationException("ConnectionString trong appsettings.json đang trống.");
        return value;
    }
}
