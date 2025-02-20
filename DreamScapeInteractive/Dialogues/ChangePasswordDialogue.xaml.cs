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
using DreamScapeInteractive.Utility;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DreamScapeInteractive.Dialogues
{
    public sealed partial class ChangePasswordDialogue : ContentDialog
    {
        // Gets the User that tries to log in
        internal User selectedUser { get; set; }

        // Define the canceledLogin variable
        internal bool canceledLogin = false;
        internal ChangePasswordDialogue()
        {
            this.InitializeComponent();
        }

        // Asynchroniously tries to change the old password to the new one
        private async void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            // Makes a list of control elements to check if they are empty or wrong
            var passwordControls = new List<Control>()
            {
                NewPasswordBox,
                ConfirmNewPasswordBox
            };

            // Check if the controls have empty fields
            bool hasEmptyPasswordFields = FormChecker.ValidateControls(passwordControls);

            // Gives feedback to fill in all fields if one is empty
            if (hasEmptyPasswordFields)
            {
                // Changes the text of the label to the feedback
                PasswordLabel.Text = "Please fill in all fields before proceeding";

                //changes the colour of the password label to indicate an error
                PasswordLabel.Foreground = new SolidColorBrush(Colors.Red);
            }
            // Gives feedback to use a stronger password
            else if (NewPasswordBox.Password.Count() < 8)
            {
                // empties both the password boxes
                NewPasswordBox.Password = null;
                ConfirmNewPasswordBox.Password = null;

                // Changes the Password label text to the feedback
                PasswordLabel.Text = "A password requires a minimum of 8 characters";

                //changes the colour of the password label to indicate an error
                PasswordLabel.Foreground = new SolidColorBrush(Colors.Red);

                return;
            }
            // Checks if the passwords match and gives feedback when they dont
            else if (NewPasswordBox.Password != ConfirmNewPasswordBox.Password)
            {
                // empties both the password boxes
                NewPasswordBox.Password = null;
                ConfirmNewPasswordBox.Password = null;

                // Changes the Password placeholder text to the feedback
                NewPasswordBox.PlaceholderText = "Passwords do not match";
                ConfirmNewPasswordBox.PlaceholderText = "Passwords do not match";

                //changes the colour of the password foreground to indicate an error
                NewPasswordBox.Foreground = new SolidColorBrush(Colors.Red);

                return;
            }
            // Hashes the new password and saves it to the database
            else
            {
                // Hashes the new password
                string hashedPassword = SecureHasher.Hash(NewPasswordBox.Password);

                // Makes a new AppDbContext
                using (var db = new AppDbContext())
                {
                    // Selects the chosen user
                    var user = db.Users.FirstOrDefault(u => u.Id == selectedUser.Id);

                    // Checks if user is not null
                    if (user != null)
                    {
                        // Changes the saved password to the new hashed password
                        user.HashedPassword = hashedPassword;
                        // Changes the Loggin once status to true
                        selectedUser.LoggedInOnce = true;

                        // Saves Changes to the database
                        await db.SaveChangesAsync();
                    }
                }
                // Closes the dialog window
                this.Hide();
            }
        }

        // Sets the canceledLogin to true and closes the dialog window
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Sets the Canceled Login variable to true
            canceledLogin = true;

            // Closes the dialog window
            this.Hide();
        }
    }
}