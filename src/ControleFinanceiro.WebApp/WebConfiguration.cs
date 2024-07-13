using MudBlazor;

namespace ControleFinanceiro.WebApp
{
    public static class WebConfiguration
    {
        public const string HTTP_CLIENT_NAME = "ControleFinanceiro";
        public static string BackendUrl { get; set; } = string.Empty;

        public static MudTheme theme = new()
        {
            Typography = new Typography
            {   
                Default = new Default
                {
                    FontFamily = ["Teko", "sons-serif"]
                }
            },
            PaletteDark = new PaletteDark
            {
                Primary = Colors.Blue.Darken3,
                Secondary = Colors.LightBlue.Darken3,
                AppbarBackground = Colors.LightBlue.Darken3,
                AppbarText = Colors.Shades.White
            }
        };
    }
}
