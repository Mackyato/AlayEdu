// Converters/UserToIdConverter.cs
using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Mod08.Model;

namespace Mod08.Converters
{
    public class UserToIdConverter : IValueConverter
    {
        // Convert User object and attendance type to a Tuple<int, string>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is User user && parameter is string attendanceType)
            {
                return new Tuple<int, string>(user.ID, attendanceType);
            }
            return null;
        }

        // Not implemented as it's not needed for one-way binding
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
