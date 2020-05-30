using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace JudgesDrawMDD
{
    [ValueConversion(typeof(bool), typeof(double))]
    public class BoolToMaxDJWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value == true) ? 90d : 0d;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {    // Don't need any convert back
            return null;
        }
    }

    [ValueConversion(typeof(string), typeof(string))]
    public class CountryToFlagConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string input = value as string;
           
            if (!string.IsNullOrEmpty(input))
            {
                return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(input).Alpha2 + ".png";
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {    // Don't need any convert back
            return null;
        }
    }


    [ValueConversion(typeof(string), typeof(string))]
    public class JudgeNameToFlagConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string input = value as string;
            Juez j = new Juez();
            List<Juez> lj = new List<Juez>();
            lj = MainWindow.jueces.Where(x => x.JudgeName == input).ToList();
            if (lj.Count > 0)
            {
                j = lj[0];
                return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(j.Country.ToUpper()).Alpha2 + ".png";
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {    // Don't need any convert back
            return null;
        }
    }
    public class NotEmptyJudgeValidationRule : ValidationRule

    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)

        {

            return string.IsNullOrWhiteSpace((value ?? "").ToString())

                ? new ValidationResult(false, "Judge is required.")

                : ValidationResult.ValidResult;

        }

    }

    public class FutureDateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime time;
            if (!DateTime.TryParse((value ?? "").ToString(), CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces, out time)) return new ValidationResult(false, "Invalid date");

            return time.Date <= DateTime.Now.Date
                ? new ValidationResult(false, "Future date required")
                : ValidationResult.ValidResult;
        }
    }

    public static class ExtensionMethods
    {
        public static int Remove<T>(
            this ObservableCollection<T> coll, Func<T, bool> condition)
        {
            var itemsToRemove = coll.Where(condition).ToList();

            foreach (var itemToRemove in itemsToRemove)
            {
                coll.Remove(itemToRemove);

            }

            return itemsToRemove.Count;
        }
    }
    public class BooleanConverter<T> : IValueConverter
    {
        public BooleanConverter(T trueValue, T falseValue)
        {
            True = trueValue;
            False = falseValue;
        }

        public T True { get; set; }
        public T False { get; set; }

        public virtual object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value is bool && ((bool)value) ? True : False;
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value is T && EqualityComparer<T>.Default.Equals((T)value, True);
        }
    }

    public sealed class BooleanToVisibilityConverterH : BooleanConverter<Visibility>
    {
        public BooleanToVisibilityConverterH() :
            base(Visibility.Visible, Visibility.Hidden)
        { }
    }
    public sealed class BooleanToVisibilityConverterC : BooleanConverter<Visibility>
    {
        public BooleanToVisibilityConverterC() :
            base(Visibility.Visible, Visibility.Collapsed)
        { }
    }

    public class NameToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string input = value as string;
            if (input == MainWindow.evento.SJPJudge)
            {
                return Brushes.Coral;
            }
            if (input == MainWindow.evento.SJD1Judge)
            {
                return Brushes.Coral;
            }
            if (input == MainWindow.evento.SJD2Judge)
            {
                return Brushes.Coral;
            }
            if (input == MainWindow.evento.SJE1Judge)
            {
                return Brushes.Coral;
            }
            if (input == MainWindow.evento.SJE2Judge)
            {
                return Brushes.Coral;
            }
            if (input == MainWindow.evento.SJA1Judge)
            {
                return Brushes.Coral;
            }
            if (input == MainWindow.evento.SJA2Judge)
            {
                return Brushes.Coral;
            }
            if (input == MainWindow.evento.CPJP1)
            {
                return Brushes.Brown;
            }
            if (input == MainWindow.evento.CPJP2)
            {
                return Brushes.Brown;
            }
            return DependencyProperty.UnsetValue;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    // Conversor de Cat Mod Ej a D1

    public class CatModExToD1Judge : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string input = value as string;
            if (input == "11-16 WP BAL")
            {
                return MainWindow.evento.WP1116BALD1;
            }
            if (input == "11-16 MP BAL")
            {
                return MainWindow.evento.MP1116BALD1;
            }
            if (input == "11-16 MXP BAL")
            {
                return MainWindow.evento.MXP1116BALD1;
            }
            if (input == "11-16 WG BAL")
            {
                return MainWindow.evento.WG1116BALD1;
            }
            if (input == "11-16 MG BAL")
            {
                return MainWindow.evento.MG1116BALD1;
            }
            if (input == "11-16 WP DYN")
            {
                return MainWindow.evento.WP1116DYND1;
            }
            if (input == "11-16 MP DYN")
            {
                return MainWindow.evento.MP1116DYND1;
            }
            if (input == "11-16 MXP DYN")
            {
                return MainWindow.evento.MXP1116DYND1;
            }
            if (input == "11-16 WG DYN")
            {
                return MainWindow.evento.WG1116DYND1;
            }
            if (input == "11-16 MG DYN")
            {
                return MainWindow.evento.MG1116DYND1;
            }
            if (input == "12-18 WP BAL")
            {
                return MainWindow.evento.WP1218BALD1;
            }
            if (input == "12-18 MP BAL")
            {
                return MainWindow.evento.MP1218BALD1;
            }
            if (input == "12-18 MXP BAL")
            {
                return MainWindow.evento.MXP1218BALD1;
            }
            if (input == "12-18 WG BAL")
            {
                return MainWindow.evento.WG1218BALD1;
            }
            if (input == "12-18 MG BAL")
            {
                return MainWindow.evento.MG1218BALD1;
            }
            if (input == "12-18 WP DYN")
            {
                return MainWindow.evento.WP1218DYND1;
            }
            if (input == "12-18 MP DYN")
            {
                return MainWindow.evento.MP1218DYND1;
            }
            if (input == "12-18 MXP DYN")
            {
                return MainWindow.evento.MXP1218DYND1;
            }
            if (input == "12-18 WG DYN")
            {
                return MainWindow.evento.WG1218DYND1;
            }
            if (input == "12-18 MG DYN")
            {
                return MainWindow.evento.MG1218DYND1;
            }
            if (input == "12-18 WP COM")
            {
                return MainWindow.evento.WP1218COMD1;
            }
            if (input == "12-18 MP COM")
            {
                return MainWindow.evento.MP1218COMD1;
            }
            if (input == "12-18 MXP COM")
            {
                return MainWindow.evento.MXP1218COMD1;
            }
            if (input == "12-18 WG COM")
            {
                return MainWindow.evento.WG1218COMD1;
            }
            if (input == "12-18 MG COM")
            {
                return MainWindow.evento.MG1218COMD1;
            }
            // 13-19
            if (input == "13-19 WP BAL")
            {
                return MainWindow.evento.WP1319BALD1;
            }
            if (input == "13-19 MP BAL")
            {
                return MainWindow.evento.MP1319BALD1;
            }
            if (input == "13-19 MXP BAL")
            {
                return MainWindow.evento.MXP1319BALD1;
            }
            if (input == "13-19 WG BAL")
            {
                return MainWindow.evento.WG1319BALD1;
            }
            if (input == "13-19 MG BAL")
            {
                return MainWindow.evento.MG1319BALD1;
            }
            if (input == "13-19 WP DYN")
            {
                return MainWindow.evento.WP1319DYND1;
            }
            if (input == "13-19 MP DYN")
            {
                return MainWindow.evento.MP1319DYND1;
            }
            if (input == "13-19 MXP DYN")
            {
                return MainWindow.evento.MXP1319DYND1;
            }
            if (input == "13-19 WG DYN")
            {
                return MainWindow.evento.WG1319DYND1;
            }
            if (input == "13-19 MG DYN")
            {
                return MainWindow.evento.MG1319DYND1;
            }
            if (input == "13-19 WP COM")
            {
                return MainWindow.evento.WP1319COMD1;
            }
            if (input == "13-19 MP COM")
            {
                return MainWindow.evento.MP1319COMD1;
            }
            if (input == "13-19 MXP COM")
            {
                return MainWindow.evento.MXP1319COMD1;
            }
            if (input == "13-19 WG COM")
            {
                return MainWindow.evento.WG1319COMD1;
            }
            if (input == "13-19 MG COM")
            {
                return MainWindow.evento.MG1319COMD1;
            }
            // SENIOR
            if (input == "12-18 WP BAL")
            {
                return MainWindow.evento.WPSENBALD1;
            }
            if (input == "12-18 MP BAL")
            {
                return MainWindow.evento.MPSENBALD1;
            }
            if (input == "12-18 MXP BAL")
            {
                return MainWindow.evento.MXPSENBALD1;
            }
            if (input == "12-18 WG BAL")
            {
                return MainWindow.evento.WGSENBALD1;
            }
            if (input == "12-18 MG BAL")
            {
                return MainWindow.evento.MGSENBALD1;
            }
            if (input == "12-18 WP DYN")
            {
                return MainWindow.evento.WPSENDYND1;
            }
            if (input == "12-18 MP DYN")
            {
                return MainWindow.evento.MPSENDYND1;
            }
            if (input == "12-18 MXP DYN")
            {
                return MainWindow.evento.MXPSENDYND1;
            }
            if (input == "12-18 WG DYN")
            {
                return MainWindow.evento.WGSENDYND1;
            }
            if (input == "12-18 MG DYN")
            {
                return MainWindow.evento.MGSENDYND1;
            }
            if (input == "12-18 WP COM")
            {
                return MainWindow.evento.WPSENCOMD1;
            }
            if (input == "12-18 MP COM")
            {
                return MainWindow.evento.MPSENCOMD1;
            }
            if (input == "12-18 MXP COM")
            {
                return MainWindow.evento.MXPSENCOMD1;
            }
            if (input == "12-18 WG COM")
            {
                return MainWindow.evento.WGSENCOMD1;
            }
            if (input == "12-18 MG COM")
            {
                return MainWindow.evento.MGSENCOMD1;
            }

            return DependencyProperty.UnsetValue;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    // Conversor de Cat Mod Ej a D2

    public class CatModExToD2Judge : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string input = value as string;
            if (input == "11-16 WP BAL")
            {
                return MainWindow.evento.WP1116BALD2;
            }
            if (input == "11-16 MP BAL")
            {
                return MainWindow.evento.MP1116BALD2;
            }
            if (input == "11-16 MXP BAL")
            {
                return MainWindow.evento.MXP1116BALD2;
            }
            if (input == "11-16 WG BAL")
            {
                return MainWindow.evento.WG1116BALD2;
            }
            if (input == "11-16 MG BAL")
            {
                return MainWindow.evento.MG1116BALD2;
            }
            if (input == "11-16 WP DYN")
            {
                return MainWindow.evento.WP1116DYND2;
            }
            if (input == "11-16 MP DYN")
            {
                return MainWindow.evento.MP1116DYND2;
            }
            if (input == "11-16 MXP DYN")
            {
                return MainWindow.evento.MXP1116DYND2;
            }
            if (input == "11-16 WG DYN")
            {
                return MainWindow.evento.WG1116DYND2;
            }
            if (input == "11-16 MG DYN")
            {
                return MainWindow.evento.MG1116DYND2;
            }
            if (input == "12-18 WP BAL")
            {
                return MainWindow.evento.WP1218BALD2;
            }
            if (input == "12-18 MP BAL")
            {
                return MainWindow.evento.MP1218BALD2;
            }
            if (input == "12-18 MXP BAL")
            {
                return MainWindow.evento.MXP1218BALD2;
            }
            if (input == "12-18 WG BAL")
            {
                return MainWindow.evento.WG1218BALD2;
            }
            if (input == "12-18 MG BAL")
            {
                return MainWindow.evento.MG1218BALD2;
            }
            if (input == "12-18 WP DYN")
            {
                return MainWindow.evento.WP1218DYND2;
            }
            if (input == "12-18 MP DYN")
            {
                return MainWindow.evento.MP1218DYND2;
            }
            if (input == "12-18 MXP DYN")
            {
                return MainWindow.evento.MXP1218DYND2;
            }
            if (input == "12-18 WG DYN")
            {
                return MainWindow.evento.WG1218DYND2;
            }
            if (input == "12-18 MG DYN")
            {
                return MainWindow.evento.MG1218DYND2;
            }
            if (input == "12-18 WP COM")
            {
                return MainWindow.evento.WP1218COMD2;
            }
            if (input == "12-18 MP COM")
            {
                return MainWindow.evento.MP1218COMD2;
            }
            if (input == "12-18 MXP COM")
            {
                return MainWindow.evento.MXP1218COMD2;
            }
            if (input == "12-18 WG COM")
            {
                return MainWindow.evento.WG1218COMD2;
            }
            if (input == "12-18 MG COM")
            {
                return MainWindow.evento.MG1218COMD2;
            }
            // 13-19
            if (input == "13-19 WP BAL")
            {
                return MainWindow.evento.WP1319BALD2;
            }
            if (input == "13-19 MP BAL")
            {
                return MainWindow.evento.MP1319BALD2;
            }
            if (input == "13-19 MXP BAL")
            {
                return MainWindow.evento.MXP1319BALD2;
            }
            if (input == "13-19 WG BAL")
            {
                return MainWindow.evento.WG1319BALD2;
            }
            if (input == "13-19 MG BAL")
            {
                return MainWindow.evento.MG1319BALD2;
            }
            if (input == "13-19 WP DYN")
            {
                return MainWindow.evento.WP1319DYND2;
            }
            if (input == "13-19 MP DYN")
            {
                return MainWindow.evento.MP1319DYND2;
            }
            if (input == "13-19 MXP DYN")
            {
                return MainWindow.evento.MXP1319DYND2;
            }
            if (input == "13-19 WG DYN")
            {
                return MainWindow.evento.WG1319DYND2;
            }
            if (input == "13-19 MG DYN")
            {
                return MainWindow.evento.MG1319DYND2;
            }
            if (input == "13-19 WP COM")
            {
                return MainWindow.evento.WP1319COMD2;
            }
            if (input == "13-19 MP COM")
            {
                return MainWindow.evento.MP1319COMD2;
            }
            if (input == "13-19 MXP COM")
            {
                return MainWindow.evento.MXP1319COMD2;
            }
            if (input == "13-19 WG COM")
            {
                return MainWindow.evento.WG1319COMD2;
            }
            if (input == "13-19 MG COM")
            {
                return MainWindow.evento.MG1319COMD2;
            }
            // SENIOR
            if (input == "12-18 WP BAL")
            {
                return MainWindow.evento.WPSENBALD2;
            }
            if (input == "12-18 MP BAL")
            {
                return MainWindow.evento.MPSENBALD2;
            }
            if (input == "12-18 MXP BAL")
            {
                return MainWindow.evento.MXPSENBALD2;
            }
            if (input == "12-18 WG BAL")
            {
                return MainWindow.evento.WGSENBALD2;
            }
            if (input == "12-18 MG BAL")
            {
                return MainWindow.evento.MGSENBALD2;
            }
            if (input == "12-18 WP DYN")
            {
                return MainWindow.evento.WPSENDYND2;
            }
            if (input == "12-18 MP DYN")
            {
                return MainWindow.evento.MPSENDYND2;
            }
            if (input == "12-18 MXP DYN")
            {
                return MainWindow.evento.MXPSENDYND2;
            }
            if (input == "12-18 WG DYN")
            {
                return MainWindow.evento.WGSENDYND2;
            }
            if (input == "12-18 MG DYN")
            {
                return MainWindow.evento.MGSENDYND2;
            }
            if (input == "12-18 WP COM")
            {
                return MainWindow.evento.WPSENCOMD2;
            }
            if (input == "12-18 MP COM")
            {
                return MainWindow.evento.MPSENCOMD2;
            }
            if (input == "12-18 MXP COM")
            {
                return MainWindow.evento.MXPSENCOMD2;
            }
            if (input == "12-18 WG COM")
            {
                return MainWindow.evento.WGSENCOMD2;
            }
            if (input == "12-18 MG COM")
            {
                return MainWindow.evento.MGSENCOMD2;
            }

            return DependencyProperty.UnsetValue;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


}
