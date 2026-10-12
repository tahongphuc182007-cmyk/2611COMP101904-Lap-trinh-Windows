using ShopManagerMini.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Vòng lặp cho phép đăng xuất rồi quay lại màn hình đăng nhập
        while (true)
        {
            User? user;
            using (FrmLogin login = new FrmLogin())
            {
                // ShowDialog: chặn chương trình cho tới khi đăng nhập xong
                if (login.ShowDialog() != DialogResult.OK) break;
                user = login.CurrentUser;
            }
            if (user == null) break;

            FrmMain main = new FrmMain(user);
            Application.Run(main);

            bool loggedOut = main.IsLoggingOut;
            main.Dispose();
            if (!loggedOut) break;
        }
    }
}
