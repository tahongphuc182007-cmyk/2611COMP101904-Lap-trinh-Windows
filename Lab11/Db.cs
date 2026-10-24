using System.Text.Json;

namespace COMP1019_Buoi11_Lab11;

/// <summary>Đọc chuỗi kết nối từ appsettings.json để đổi server mà không cần biên dịch lại.</summary>
public static class Db
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
