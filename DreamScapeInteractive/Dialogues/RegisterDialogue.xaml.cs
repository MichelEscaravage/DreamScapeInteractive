    using DreamScapeInteractive.Data.Classes;
using DreamScapeInteractive.Utility;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DreamScapeInteractive.Dialogues
{
    public sealed partial class RegisterDialogue : ContentDialog
    {
        private readonly AppDbContext _context = new AppDbContext();
        private List<string> _usernames;
        private bool _isAdmin = false;
        private bool _isPasswordGenerated = false;
        private string _password;
        
        public RegisterDialogue()
        {
            this.InitializeComponent();
            User.LoggedInUser = _context.Users.FirstOrDefault(u => u.IsAdmin);
            if (User.LoggedInUser.IsAdmin == true)
            {
                IsAdminSwitch.Visibility = Visibility.Visible;
            }
            else
            {
                IsAdminSwitch.Visibility = Visibility.Collapsed;
            }

            _usernames = _context.Users.Select(u => u.Username).ToList();
        }

        private void IsAdminSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (IsAdminSwitch.IsOn)
            {
                _isAdmin = true;
            }
            else
            {
                _isAdmin = false;
            }
        }

        private void GeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            _isPasswordGenerated = true;
            ErrorBlock.Visibility = Visibility.Collapsed;
            GeneratePassword.BorderBrush = new SolidColorBrush(Colors.Gold);

            //set possible characters for password
            string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()_";
            int length = 20;
            char[] separateChars = letters.ToCharArray();
            Random randomizer = new Random();
            string password = "";
            for (int i = 0; i < length; i++)
            {
                password += separateChars[randomizer.Next(0, separateChars.Count())];
            }
            _password = password;
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            List<Control> inputControls = new List<Control>()
            {
                UserNameTextbox,
                EmailAdressBox
            };

            bool hasEmptyFields = FormChecker.ValidateControls(inputControls);
            bool usernameAlreadyExists = _context.Users.Any(u => u.Username == UserNameTextbox.Text);
            bool isEmailvalid = IsValidEmail(EmailAdressBox.Text);

            if (hasEmptyFields)
            {
                return;
            }

            if (usernameAlreadyExists)
            {
                UserNameTextbox.Text = string.Empty;
                EmailAdressBox.Text = string.Empty;
                UserNameTextbox.PlaceholderText = "Username already in use!";
                UserNameTextbox.PlaceholderForeground = new SolidColorBrush(Colors.Red);
                return;
            }

            if (!isEmailvalid)
            {
                UserNameTextbox.Text = string.Empty;
                EmailAdressBox.Text = string.Empty;
                EmailAdressBox.BorderBrush = new SolidColorBrush(Colors.Red);
                EmailAdressBox.PlaceholderText = "Please fill in a valid email";
                return;
            }

            if (!_isPasswordGenerated)
            {
                ErrorBlock.Text = "Please generate a password!";
                ErrorBlock.Visibility = Visibility.Visible;
                GeneratePassword.BorderBrush = new SolidColorBrush(Colors.Red);
                return;
            }

            User user = new User()
            {
                Username = UserNameTextbox.Text,
                EmailAddress = EmailAdressBox.Text,
                HashedPassword = SecureHasher.Hash(_password),
                IsAdmin = _isAdmin,
            };

            _context.Add(user);
            await _context.SaveChangesAsync();


            //TODO CHANGE EMAIL ADDRESS TO RECIPIENT ADDRESS
            MailSender.SendEmail("michelescaravage@hotmail.com  ", "Your password!",

                $"Here are your login credentials!\n\n" +
                $"Your username: {UserNameTextbox.Text}\n" +
                $"And your first-time use password: {_password}\n\n" +
                $"After logging in for the first time you will be asked to " +
                $"change your password." +
                $"\n" +
                $"\n" +
                $"Cheers!" +
                $"\n\n" +
                $"The DreamScapeInteractive team"
            );

            this.Hide();
        }
  //--------------------------------------------------------------------------
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _context.Dispose();
            this.Hide();
        }
    }
}
