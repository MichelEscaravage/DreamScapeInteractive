using System;
using System.Collections.Generic;
using System.Linq;
using DreamScapeInteractive;
using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace DreamScapeInteractive.Utility
{
    public static class FormChecker
    {
        public static bool ValidateControls(List<Control> controls)
        {
            bool hasEmptyFields = false;

            foreach (var control in controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.PlaceholderText = "Required";
                        textBox.PlaceholderForeground = new SolidColorBrush(Colors.Red);
                        hasEmptyFields = true;
                    }
                    
                }
                else if (control is PasswordBox passwordBox)
                {
                    if (string.IsNullOrWhiteSpace(passwordBox.Password))
                    {
                        passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                        hasEmptyFields = true;
                    }
                }
                else if (control is DatePicker datePicker)
                {
                    if (!datePicker.SelectedDate.HasValue)
                    {
                        datePicker.BorderBrush = new SolidColorBrush(Colors.Red);
                        datePicker.BorderThickness = new Microsoft.UI.Xaml.Thickness(2);
                        hasEmptyFields = true;
                    }
                }
                else if (control is Slider slider)
                {
                    if (slider.Value == 0)
                    {
                        slider.BorderBrush = new SolidColorBrush(Colors.Red);
                        slider.BorderThickness = new Microsoft.UI.Xaml.Thickness(2);
                        hasEmptyFields = true;
                    }
                }
                else if (control is ListBox listBox)
                {
                    if (listBox.SelectedItems.Count == 0)
                    {
                        listBox.BorderBrush = new SolidColorBrush(Colors.Red);
                        listBox.BorderThickness = new Microsoft.UI.Xaml.Thickness(2);
                        hasEmptyFields = true;
                    }
                }               
            }

            return hasEmptyFields;
        }
    }
}
