using DreamScapeInteractive.Utility;
using DreamScapeInteractive.Dialogues;
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
using Windows.Foundation;
using Windows.Foundation.Collections;
using DreamScapeInteractive.Data.Classes;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DreamScapeInteractive
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private readonly AppDbContext _context = new AppDbContext();
        User selectedUser;
        
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            List<Control> inputcontrols = new List<Control>()
            {
                UsernameTextBox,
                PasswordTextBox
            };

            bool hasEmptyFields = FormChecker.ValidateControls(inputcontrols);
            

            if (hasEmptyFields)
            {
                return;
            }

            selectedUser = selectedUser = _context.Users.
                    FirstOrDefault(u => u.Username == UsernameTextBox.Text);

            if (selectedUser == null)
            {
                UsernameTextBox.Text = string.Empty;
                PasswordTextBox.Password = string.Empty;
                UsernameTextBox.PlaceholderText = "Credentials dont match!";
                UsernameTextBox.PlaceholderForeground = new SolidColorBrush(Colors.Red);
                return;
            }

            TimeSpan timeDifference = DateTime.Now - selectedUser.LastFailedLogin;

            // Checks if user has failed to log in 3 or more times in the last 30 min
            if (selectedUser.FailedLoginAttempts >= 3 && timeDifference.TotalMinutes < 30)
            {
                //TODO DIALOGUE PAGE MAKEN---------------------
                var lockoutDialog = new ContentDialog()
                {
                    Title = "Account Locked",
                    Content = "Too many failed attempts please try again later.",
                    CloseButtonText = "OK",
                    XamlRoot = this.Content.XamlRoot

                };
                // Empties the password box
                PasswordTextBox.Password = "";
                // Shows the Lockout dialog
                await lockoutDialog.ShowAsync();
                return;
            }

            // Checks if the User is not null or the hashed password doesnt match the provided password
            if (!SecureHasher.Verify(PasswordTextBox.Password, selectedUser.HashedPassword) || selectedUser == null)
            {
                // Increases the counter of failed login attempts of the user
                selectedUser.FailedLoginAttempts++;
                // Updates the last failed login attempt to now
                selectedUser.LastFailedLogin = DateTime.Now;

                // Saves in the database
                _context.SaveChanges();

                // Prepares the login Dialog
                var loginDialog = new ContentDialog()
                {
                    Title = "Credentials dont match",
                    Content = "Wrong password or username, please try again",
                    CloseButtonText = "OK",
                    XamlRoot = this.Content.XamlRoot
                };

                // Empties the password box
                PasswordTextBox.Password = "";
                // Shows login dialog
                await loginDialog.ShowAsync();
                return;
            }

            // Checks if the user has not logged in before
            if (selectedUser.LoggedInOnce == false)
            {
                // Prepares the change password dialog
                ChangePasswordDialogue changePasswordDialog = new ChangePasswordDialogue()
                {
                    // Sets the root
                    XamlRoot = this.Content.XamlRoot,
                    //Sets the selected user to selected user
                    selectedUser = selectedUser,
                };
                // Opens the change password dialog
                await changePasswordDialog.ShowAsync();

                // Checks if the user canceled the login and returns
                if (changePasswordDialog.canceledLogin)
                {
                    return;
                }
            }

            // Resets the failed login attempts of the current user to 0
            selectedUser.FailedLoginAttempts = 0;
            // Sets the last failed login attempt to now
            selectedUser.LastFailedLogin = DateTime.Now;

            // Save to the database
            _context.SaveChanges();
            // sets the selected user to the logged in user
            User.LoggedInUser = selectedUser;

            // Opens the mainwindow
            if (selectedUser.IsAdmin == true)
            {
                this.Frame.Navigate(typeof(AdminPanelPage));
                _context.Dispose();

            }
            else if (selectedUser.IsAdmin == false)
            {
                this.Frame.Navigate(typeof(CatalogusPage));
                _context.Dispose();
            }
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterDialogue contentDialog = new RegisterDialogue()
            {
                XamlRoot = this.XamlRoot
            };

            await contentDialog.ShowAsync();
        }
    }
}

