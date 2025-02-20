using Microsoft.UI.Xaml.Controls;
using Microsoft.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;

namespace DreamScapeInteractive.Utility
{
    public static class PasswordValidator
    {
        public static bool ValidatePasswords(string password, string confimPassword, PasswordBox passwordBox, PasswordBox confirmPasswordBox, TextBlock? confirmPasswordLabel)
        {
            if (password != confimPassword)
            {
                passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                confirmPasswordLabel.Text = "Passwords dont match!";
                confirmPasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);

                return false;
            }

            passwordBox.BorderBrush = null;
            confirmPasswordLabel.Text = "";
            confirmPasswordBox.BorderBrush = null;

            return true;
        }
    }
}
