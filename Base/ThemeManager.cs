using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AquaTherm.Base
{
    public static class ThemeManager
    {
        public static void ApplyTheme(string themeName)
        {
            var dict = new ResourceDictionary();
            switch (themeName)
            {
                case "Dark":
                    dict.Source = new Uri("Themes/DarkTheme.xaml", UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("Themes/LightTheme.xaml", UriKind.Relative);
                    break;
            }

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
    }

}
