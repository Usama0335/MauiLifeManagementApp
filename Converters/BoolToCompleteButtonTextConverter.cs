﻿using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace MauiApp1.Converters
{
    public class BoolToCompleteButtonTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isCompleted)
                return isCompleted ? "Undo" : "Complete";
            return "Complete";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
