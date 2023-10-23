﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DumbSrum {
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window {
        public SignInWindow() {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e) {

        }

        private void hypSignIn_Click(object sender, RoutedEventArgs e) {
            var signUpWindow = new SignUpWindow();
            this.Close();
            signUpWindow.ShowDialog();
        }

        private void hypForgotPassword_Click(object sender, RoutedEventArgs e) {

        }
    }
}
