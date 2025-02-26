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
        private List<Control> inputControls = new List<Control>();
        private List<string> _usernames;
        private bool _isAdmin = false;
        private bool _isPasswordGenerated = false;
        private string _password;
        private string _passwordChecker;
        private string _confirmPassword;

        public RegisterDialogue()
        {
            this.InitializeComponent();


            if (User.LoggedInUser == null!)
            {
                IsAdminSwitch.Visibility = Visibility.Collapsed;
                GeneratePassword.Visibility = Visibility.Collapsed;
                PasswordTextBox.Visibility = Visibility.Visible;
                ConfirmPasswordTextBox.Visibility = Visibility.Visible;

            }
            else if (!User.LoggedInUser.IsAdmin)
            {
                IsAdminSwitch.Visibility = Visibility.Collapsed;
                GeneratePassword.Visibility = Visibility.Collapsed;
                PasswordTextBox.Visibility = Visibility.Visible;

            }
            else if (User.LoggedInUser.IsAdmin)
            {
                IsAdminSwitch.Visibility = Visibility.Visible;
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


        private void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _passwordChecker = PasswordTextBox.Password;
        }

        private void ConfirmPasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _confirmPassword = ConfirmPasswordTextBox.Password;
            PasswordValidator.ValidatePasswords(_passwordChecker, _confirmPassword, PasswordTextBox, ConfirmPasswordTextBox, confirmPasswordLabel);

        }

        private bool IsPasswordSafe(string Password)
        {
            return Password.Count() >= 8;
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            inputControls.AddRange(new List<Control>
            {
                UserNameTextbox,
                EmailAdressBox,
            });

            if (User.LoggedInUser == null || !User.LoggedInUser.IsAdmin)
            {
                inputControls.Add(PasswordTextBox);
            }

            bool hasEmptyFields = FormChecker.ValidateControls(inputControls);
            bool usernameAlreadyExists = _context.Users.Any(u => u.Username == UserNameTextbox.Text);
            bool emailAlreadyExists = _context.Users.Any(u => u.EmailAddress == EmailAdressBox.Text);
            bool isEmailvalid = IsValidEmail(EmailAdressBox.Text);

            if (PasswordTextBox.Visibility == Visibility.Visible)
            {
                if (!IsPasswordSafe(PasswordTextBox.Password))
                {
                    UserNameTextbox.Text = string.Empty;
                    EmailAdressBox.Text = string.Empty;
                    PasswordTextBox.Password = string.Empty;
                    ConfirmPasswordTextBox.Password = string.Empty;


                    PasswordTextBox.PlaceholderText = "Password must have atleast 8 characters!";
                    PasswordTextBox.BorderBrush = new SolidColorBrush(Colors.Red);

                    return;
                }
            }
            
            if (hasEmptyFields)
            {
                return;
            }

            if (usernameAlreadyExists)
            {
                UserNameTextbox.Text = string.Empty;
                EmailAdressBox.Text = string.Empty;
                PasswordTextBox.Password = string.Empty;
                ConfirmPasswordTextBox.Password = string.Empty;

                UserNameTextbox.PlaceholderText = "Username already in use!";
                UserNameTextbox.PlaceholderForeground = new SolidColorBrush(Colors.Red);
                return;
            }

            if (emailAlreadyExists)
            {
                UserNameTextbox.Text = string.Empty;
                EmailAdressBox.Text = string.Empty;
                PasswordTextBox.Password = string.Empty;
                ConfirmPasswordTextBox.Password = string.Empty;

                EmailAdressBox.PlaceholderText = "Email already in use!";
                UserNameTextbox.PlaceholderForeground = new SolidColorBrush(Colors.Red);
                return;
            }

            if (!isEmailvalid)
            {
                UserNameTextbox.Text = string.Empty;
                EmailAdressBox.Text = string.Empty;
                PasswordTextBox.Password = string.Empty;
                ConfirmPasswordTextBox.Password = string.Empty;

                EmailAdressBox.PlaceholderForeground = new SolidColorBrush(Colors.Red);
                EmailAdressBox.BorderBrush = new SolidColorBrush(Colors.Red);
                EmailAdressBox.PlaceholderText = "Please fill in a valid email";
                return;
            }

            if (!_isPasswordGenerated && (User.LoggedInUser == null || !User.LoggedInUser.IsAdmin))
            {
                _password = PasswordTextBox.Password;
            }
            else if (!_isPasswordGenerated && User.LoggedInUser.IsAdmin == true)
            {
                ErrorBlock.Text = "Please generate a password!";
                ErrorBlock.Visibility = Visibility.Visible;
                GeneratePassword.BorderBrush = new SolidColorBrush(Colors.Red);
                return;
            }
            
            if (User.LoggedInUser != null)
            {
                if (!PasswordValidator.ValidatePasswords(_passwordChecker, _confirmPassword, PasswordTextBox, ConfirmPasswordTextBox, confirmPasswordLabel))
                {
                    return;
                }
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

            if (User.LoggedInUser != null)
            {
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
            }           

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
