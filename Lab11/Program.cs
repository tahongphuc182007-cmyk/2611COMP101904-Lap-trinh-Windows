namespace COMP1019_Buoi11_Lab11;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FrmLop());
    }
}
