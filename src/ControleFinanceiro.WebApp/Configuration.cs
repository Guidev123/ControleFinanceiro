using MudBlazor;

namespace ControleFinanceiro.WebApp
{
    public static class Configuration
    {
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
                Primary = "#040943",
                Secondary = Colors.LightBlue.Darken3,
                AppbarBackground = "#040943",
                AppbarText = "#d5d7d9"
            },
            PaletteLight = new PaletteLight
            {
                Primary = "#ffffff",
                Secondary = Colors.LightBlue.Darken3,
                Background = Colors.Gray.Lighten4,
                AppbarBackground = "#ffffff",
                AppbarText = Colors.Shades.Black,
                TextPrimary = Colors.Shades.Black,
                PrimaryContrastText = Colors.Shades.White,
                DrawerText = Colors.Shades.Black,
                DrawerBackground = Colors.LightBlue.Lighten4
            }
        };
    }
}
