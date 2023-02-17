using MudBlazor;

namespace JeagerJak.com.Shared.Classes
{
    
    public static class JeagerTheme 
    {
        private static string[] fontFamily = new[] { "Chakra", "Petch" };
        public static MudTheme Theme = new MudTheme()
        {
            Palette = new Palette()
            {
                TextDisabled = Colors.Grey.Lighten5,

                Black = "#343a40",
                White = "#f8f9fa",

                Primary = "RGBA(220, 207, 255,0.5)",
                PrimaryContrastText = "#03045e",
                PrimaryDarken = "RGBA(220, 207, 255, 1)",
                PrimaryLighten = "RGBA(220, 207, 255, .2)",

                Secondary = "RGB(224, 206, 255)",
                SecondaryContrastText = "#12263a",
                SecondaryDarken = "#fff",
                SecondaryLighten = "#fff",

                Tertiary = "RGB(200, 149, 192)",
                TertiaryContrastText = "#f8f9fa",
                TertiaryDarken = "#fff",
                TertiaryLighten = "#fff",

                Info = "RGB(194, 151, 155)",
                InfoContrastText = "#f8f9fa",
                InfoDarken = "#fff",
                InfoLighten = "#fff",

                Dark = "RGB(87, 36, 97)",
                DarkContrastText = "#f8f9fa",
                DarkDarken = "#fff",
                DarkLighten = "#fff",

                AppbarBackground = "#e85d04",
                AppbarText = "#fff",

                Background = "#f8be8c",
                BackgroundGrey = "#fff",

                DrawerBackground = "#fff",
                DrawerIcon = "#fff",
                DrawerText = "#fff",

                Success = "#fff",
                SuccessContrastText = "#fff",
                SuccessDarken = "#fff",
                SuccessLighten = "#fff",
                
                Surface = "#fff",
                
                TableHover= "#fff",
                TableStriped= "#fff",
                TableLines = "#fff",

            },
            PaletteDark = new Palette()
            {
                Primary = "#77007a",
                PrimaryContrastText = "#f7ff00",
            },
            LayoutProperties= new LayoutProperties()
            {

            },
            Typography = new Typography()
            {
                Default = new() { FontFamily = fontFamily },
                Body1 = new() { FontFamily = fontFamily },
                Body2 = new() { FontFamily = fontFamily },
                H1 = new() { FontFamily = fontFamily },
                H2 = new() { FontFamily = fontFamily },
                H3 = new() { FontFamily = fontFamily },
                H4 = new() { FontFamily = fontFamily },
                H5 = new() { FontFamily = fontFamily },
                H6 = new() { FontFamily = fontFamily },
                Button = new() { FontFamily = fontFamily },
                Overline = new() { FontFamily = fontFamily },
                Caption = new() { FontFamily = fontFamily },
                Subtitle1 = new() { FontFamily = fontFamily },
                Subtitle2 = new() { FontFamily = fontFamily },
            }
        };

    }
}
