﻿using System;
using Xamarin.Forms;
using System.Net.Mail;
using LoginNavigation.Models;

namespace LoginNavigation
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Email = emailEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        async void OnForgotPassword(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPassword());
        }

        bool AreCredentialsCorrect(User user)
        {
            return (RegisteredUsers.registeredUsers.FindIndex(a => a.Password == passwordEntry.Text && a.Email.ToLower() == emailEntry.Text.ToLower()) != -1);
        }
    }
}
