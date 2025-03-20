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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfStudyNote.Views.Controller.Views
{
    /// <summary>
    /// RegisterView.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!PasswordBox.Password.Equals(RePasswordBox.Password))
                ErrorMessage.Text = "两次输入的密码不一致";
            else
                ErrorMessage.Text = "";
        }
    }
}
