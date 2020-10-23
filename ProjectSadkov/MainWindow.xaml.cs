using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ProjectSadkov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string phone = "_________";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckBoxLogInShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            PasswordBoxLogInPassword.Visibility = Visibility.Hidden;
            TextBoxLogInPassword.Visibility = Visibility.Visible;
        }

        private void PasswordBoxLogInPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogInPassword.Text != PasswordBoxLogInPassword.Password) TextBoxLogInPassword.Text = PasswordBoxLogInPassword.Password;
        }

        private void TextBoxLogInPassword_TextChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxLogInPassword.Password != TextBoxLogInPassword.Text) PasswordBoxLogInPassword.Password = TextBoxLogInPassword.Text;
        }

        private void CheckBoxLogInShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBoxLogInPassword.Visibility = Visibility.Visible;
            TextBoxLogInPassword.Visibility = Visibility.Hidden;
        }

        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            TextBlockLogInLoginError.Text = Validation.validationLogin(TextBoxLogInLogin.Text);
            TextBlockLogInPasswordError.Text = Validation.validationPassword(PasswordBoxLogInPassword.Password);
            if (TextBlockLogInLoginError.Text.Length == 0 && TextBlockLogInPasswordError.Text.Length == 0)
            {
                PackIconConnection.Visibility = Visibility.Visible;
                SqlMaster sqlMaster = new SqlMaster();
                if (sqlMaster.isConnected())
                {
                    if (sqlMaster.userExist(TextBoxLogInLogin.Text, PasswordBoxLogInPassword.Password))
                    {
                        OurMessageBox.Show("Успех!", "Добро пожаловать", "Вы успешно авторизовались!");
                    }
                    else
                    {
                        OurMessageBox.Show("Не удача!", "Хм... Кажется что-то пошло не так.", "Неверный логин или пароль.");
                    }
                }
                PackIconConnection.Visibility = Visibility.Hidden;
            }
        }

        private void TextBlockLogInToSignUp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TabControlAuth.SelectedValue = TabItemSignUp;
        }

        private void TextBoxLogInLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockLogInLoginError.Text = Validation.validationLogin(TextBoxLogInLogin.Text);
        }

        private void PasswordBoxLogInPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockLogInPasswordError.Text = Validation.validationPassword(PasswordBoxLogInPassword.Password);
        }

        private void TextBoxLogInPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockLogInPasswordError.Text = Validation.validationPassword(TextBoxLogInPassword.Text);
        }

        private void TextBoxSignUpLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockSignUpLoginError.Text = Validation.validationLogin(TextBoxSignUpLogin.Text);
        }

        private void TextBoxSignUpName_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockSignUpNameError.Text = Validation.validationName(TextBoxSignUpName.Text);
        }

        private void TextBoxSignUpPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockSignUpPhoneError.Text = Validation.validationPhone(TextBoxSignUpPhone.Text);
        }

        private void TextBoxSignUpPhone_KeyUp(object sender, KeyEventArgs e)
        {
            string key = e.Key.ToString();
            Regex digitKey = new Regex("^(D|NumPad)[0-9]{1}$");
            Regex extraChars = new Regex("^['D','NumPad']");
            if (digitKey.IsMatch(key))
            {
                string digit = extraChars.Replace(key, "");
                this.phone = new Regex("_").Replace(this.phone, digit, 1);
            }
            if (key == "Back") this.phone = new Regex("[0-9](_|$)").Replace(this.phone, "__", 1);
            if (this.phone == "_________") TextBoxSignUpPhone.Text = "";
            else TextBoxSignUpPhone.Text = $"+7 (9{this.phone[0]}{this.phone[1]}) {this.phone[2]}{this.phone[3]}{this.phone[4]}-{this.phone[5]}{this.phone[6]}-{this.phone[7]}{this.phone[8]}";
        }

        private void TextBoxSignUpPhone_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void TextBoxSignUpEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockSignUpEmailError.Text = Validation.validationEmail(TextBoxSignUpEmail.Text);
        }

        private void TextBoxSignUpPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockSignUpPasswordError.Text = Validation.validationPassword(TextBoxSignUpPassword.Text);
        }

        private void TextBoxSignUpConfirmPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockSignUpConfirmPasswordError.Text = Validation.validationConfirmPassword(TextBoxSignUpPassword.Text, TextBoxSignUpConfirmPassword.Text);
        }

        private void PasswordBoxSignUpPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockSignUpPasswordError.Text = Validation.validationPassword(TextBoxSignUpPassword.Text);
        }

        private void PasswordBoxSignUpConfirmPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockSignUpConfirmPasswordError.Text = Validation.validationConfirmPassword(TextBoxSignUpPassword.Text, TextBoxSignUpConfirmPassword.Text);
        }

        private void CheckBoxSignUpShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            PasswordBoxSignUpPassword.Visibility = Visibility.Hidden;
            TextBoxSignUpPassword.Visibility = Visibility.Visible;
            PasswordBoxSignUpConfirmPassword.Visibility = Visibility.Hidden;
            TextBoxSignUpConfirmPassword.Visibility = Visibility.Visible;
        }

        private void CheckBoxSignUpShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBoxSignUpPassword.Visibility = Visibility.Visible;
            TextBoxSignUpPassword.Visibility = Visibility.Hidden;
            PasswordBoxSignUpConfirmPassword.Visibility = Visibility.Visible;
            TextBoxSignUpConfirmPassword.Visibility = Visibility.Hidden;
        }

        private void PasswordBoxSignUpPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TextBoxSignUpPassword.Text != PasswordBoxSignUpPassword.Password) TextBoxSignUpPassword.Text = PasswordBoxSignUpPassword.Password;
        }

        private void TextBoxSignUpPassword_TextChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxSignUpPassword.Password != TextBoxSignUpPassword.Text) PasswordBoxSignUpPassword.Password = TextBoxSignUpPassword.Text;
        }

        private void PasswordBoxSignUpConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TextBoxSignUpConfirmPassword.Text != PasswordBoxSignUpConfirmPassword.Password) TextBoxSignUpConfirmPassword.Text = PasswordBoxSignUpConfirmPassword.Password;
        }

        private void TextBoxSignUpConfirmPassword_TextChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxSignUpConfirmPassword.Password != TextBoxSignUpConfirmPassword.Text) PasswordBoxSignUpConfirmPassword.Password = TextBoxSignUpConfirmPassword.Text;
        }

        private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            TextBlockSignUpLoginError.Text = Validation.validationLogin(TextBoxSignUpLogin.Text);
            TextBlockSignUpNameError.Text = Validation.validationName(TextBoxSignUpName.Text);
            TextBlockSignUpPhoneError.Text = Validation.validationPhone(TextBoxSignUpPhone.Text);
            TextBlockSignUpEmailError.Text = Validation.validationEmail(TextBoxSignUpEmail.Text);
            TextBlockSignUpPasswordError.Text = Validation.validationPassword(TextBoxSignUpPassword.Text);
            TextBlockSignUpConfirmPasswordError.Text = Validation.validationConfirmPassword(
                TextBoxSignUpPassword.Text,
                TextBoxSignUpConfirmPassword.Text
            );
            if (
                TextBlockSignUpLoginError.Text.Length == 0
                && TextBlockSignUpNameError.Text.Length == 0
                && TextBlockSignUpPhoneError.Text.Length == 0
                && TextBlockSignUpEmailError.Text.Length == 0
                && TextBlockSignUpPasswordError.Text.Length == 0
                && TextBlockSignUpConfirmPasswordError.Text.Length == 0
            )
            {

                PackIconConnection.Visibility = Visibility.Visible;
                SqlMaster sqlMaster = new SqlMaster();
                if (sqlMaster.isConnected())
                {
                    TextBlockSignUpLoginError.Text = sqlMaster.uniqueLogin(TextBoxSignUpLogin.Text);
                    TextBlockSignUpEmailError.Text = sqlMaster.uniqueEmail(TextBoxSignUpEmail.Text);
                    TextBlockSignUpPhoneError.Text = sqlMaster.uniquePhone(TextBoxSignUpPhone.Text);
                    if (
                        TextBlockSignUpLoginError.Text.Length == 0
                        && TextBlockSignUpPhoneError.Text.Length == 0
                        && TextBlockSignUpEmailError.Text.Length == 0
                    )
                    {
                        sqlMaster.saveUser(
                            TextBoxSignUpLogin.Text,
                            TextBoxSignUpName.Text,
                            TextBoxSignUpPhone.Text,
                            TextBoxSignUpEmail.Text,
                            TextBoxSignUpPassword.Text
                        );
                    }
                }
                PackIconConnection.Visibility = Visibility.Hidden;
            }
        }
        private DispatcherTimer timer;

        int dec;
        Code code = new Code();

        private void ButtonNewPasswordSendCode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validation.validationEmail(TextBoxNewPasswordLogin.Text).Length != 0)
                {
                    TextBlockNewPasswordLoginError.Text = Validation.validationLogin(TextBoxNewPasswordLogin.Text);
                }
                if (TextBlockNewPasswordLoginError.Text.Length == 0)
                {
                    if (code.sendCode(TextBoxNewPasswordLogin.Text.ToString()))
                    {
                        dec = 59;
                        if (dec == 59) LabelNewPasswordTimer.Text = "00:59";
                        LabelNewPasswordLogin.IsEnabled = false;
                        TextBoxNewPasswordLogin.IsEnabled = false;
                        ButtonNewPasswordSendCode.IsEnabled = false;
                        LabelNewPasswordTimer.Visibility = Visibility.Visible;
                        LabelNewPasswordSendNewCode.Visibility = Visibility.Visible;
                        labelNewPasswordCodeInfo.Visibility = Visibility.Visible;
                        TextBoxNewPasswordCode.Visibility = Visibility.Visible;
                        LabelNewPasswordCode.Visibility = Visibility.Visible;
                        TextBlockNewPasswordCodeError.Visibility = Visibility.Visible;
                        timer = new DispatcherTimer();
                        timer.Tick += new EventHandler(timer_Tick);
                        timer.Interval = new TimeSpan(0, 0, 1);
                        timer.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                OurMessageBox.Show("Не удача!", "Не удалось отправить код подтверждения.", "Аккаунта с таким логином или почтой не существует\nИли почтовый сервис отказывается принимать письмо.\n", ex.ToString());
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            dec--;
            if (LabelNewPasswordTimer.Text.ToString() != "00:00")
            {
                if (dec >= 10) LabelNewPasswordTimer.Text = "00:" + dec;
                else LabelNewPasswordTimer.Text = "00:0" + dec;
            }
            else
            {
                timer.Stop();
                LabelNewPasswordTimer.Visibility = Visibility.Hidden;
                LabelNewPasswordSendNewCode.Visibility = Visibility.Hidden;
                LabelNewPasswordLogin.IsEnabled = true;
                TextBoxNewPasswordLogin.IsEnabled = true;
                ButtonNewPasswordSendCode.IsEnabled = true;
            }
        }

        private void TextBoxNewPasswordCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBlockNewPasswordCodeError.Text = "";
            if (TextBoxNewPasswordCode.Text.Length == 4)
            {
                if (code.codeString == TextBoxNewPasswordCode.Text.ToString())
                {
                    timer.Stop();
                    LabelNewPasswordPassword.Visibility = Visibility.Visible;
                    PasswordBoxNewPasswordPassword.Visibility = Visibility.Visible;
                    LabelNewPasswordConfirmPassword.Visibility = Visibility.Visible;
                    PasswordBoxNewPasswordConfirmPassword.Visibility = Visibility.Visible;
                    CheckBoxNewPasswordShowPassword.Visibility = Visibility.Visible;
                    ButtonNewPasswordResetPassword.Visibility = Visibility.Visible;
                    TextBlockNewPasswordShowPassword.Visibility = Visibility.Visible;
                    TextBlockNewPasswordPasswordError.Visibility = Visibility.Visible;
                    TextBlockNewPasswordConfirmPasswordError.Visibility = Visibility.Visible;
                    LabelNewPasswordCode.IsEnabled = false;
                    TextBoxNewPasswordCode.IsEnabled = false;
                    labelNewPasswordCodeInfo.IsEnabled = false;
                    LabelNewPasswordSendNewCode.Text = "Вы успешно подтвердили свою почту!";
                    LabelNewPasswordTimer.Visibility = Visibility.Hidden;
                    LabelNewPasswordLogin.IsEnabled = false;
                    TextBoxNewPasswordLogin.IsEnabled = false;
                    ButtonNewPasswordSendCode.IsEnabled = false;
                }
                else
                {
                    TextBlockNewPasswordCodeError.Text = "Неверный код";
                }
            }
        }

        private void ButtonNewPasswordResetPassword_Click(object sender, RoutedEventArgs e)
        {
            TextBlockNewPasswordPasswordError.Text = Validation.validationPassword(TextBoxNewPasswordPassword.Text);
            TextBlockNewPasswordConfirmPasswordError.Text = Validation.validationConfirmPassword(TextBoxNewPasswordPassword.Text, TextBoxNewPasswordConfirmPassword.Text);
            if (TextBlockNewPasswordPasswordError.Text.Length == 0 && TextBlockNewPasswordConfirmPasswordError.Text.Length == 0)
            {
                SqlMaster sqlMaster = new SqlMaster();
                if (Validation.validationEmail(TextBoxNewPasswordLogin.Text).Length == 0)
                {
                    User user = sqlMaster.getUser("email", TextBoxNewPasswordLogin.Text);
                    sqlMaster.changePassword(TextBoxNewPasswordPassword.Text, user.login);
                }
                else sqlMaster.changePassword(TextBoxNewPasswordPassword.Text, TextBoxNewPasswordLogin.Text);
            }
        }

        private void TextBoxNewPasswordLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Validation.validationEmail(TextBoxNewPasswordLogin.Text).Length != 0)
            {
                TextBlockNewPasswordLoginError.Text = Validation.validationLogin(TextBoxNewPasswordLogin.Text);
            }
        }

        private void CheckBoxNewPasswordShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBoxNewPasswordPassword.Visibility = Visibility.Visible;
            TextBoxNewPasswordPassword.Visibility = Visibility.Hidden;
            PasswordBoxNewPasswordConfirmPassword.Visibility = Visibility.Visible;
            TextBoxNewPasswordConfirmPassword.Visibility = Visibility.Hidden;
        }

        private void CheckBoxNewPasswordShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            PasswordBoxNewPasswordPassword.Visibility = Visibility.Hidden;
            TextBoxNewPasswordPassword.Visibility = Visibility.Visible;
            PasswordBoxNewPasswordConfirmPassword.Visibility = Visibility.Hidden;
            TextBoxNewPasswordConfirmPassword.Visibility = Visibility.Visible;
        }

        private void PasswordBoxNewPasswordPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TextBoxNewPasswordPassword.Text != PasswordBoxNewPasswordPassword.Password) TextBoxNewPasswordPassword.Text = PasswordBoxNewPasswordPassword.Password;
        }
        private void PasswordBoxNewPasswordConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TextBoxNewPasswordConfirmPassword.Text != PasswordBoxNewPasswordConfirmPassword.Password) TextBoxNewPasswordConfirmPassword.Text = PasswordBoxNewPasswordConfirmPassword.Password;
        }

        private void TextBoxNewPasswordPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxNewPasswordPassword.Password != TextBoxNewPasswordPassword.Text) PasswordBoxNewPasswordPassword.Password = TextBoxNewPasswordPassword.Text;
        }
        private void TextBoxNewPasswordConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxNewPasswordConfirmPassword.Password != TextBoxNewPasswordConfirmPassword.Text) PasswordBoxNewPasswordConfirmPassword.Password = TextBoxNewPasswordConfirmPassword.Text;
        }

        private void TextBoxNewPasswordPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockNewPasswordPasswordError.Text = Validation.validationPassword(TextBoxNewPasswordPassword.Text);
        }
    }
}