namespace Lab01_ThongTinCaNhan
{
    /// <summary>
    /// Lớp chứa điểm khởi đầu (entry point) của chương trình.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Điểm khởi đầu chính của ứng dụng.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Bật các cấu hình mặc định cho ứng dụng Windows Forms
            ApplicationConfiguration.Initialize();

            // Chạy Form chính của ứng dụng
            Application.Run(new Form1());
        }
    }
}
