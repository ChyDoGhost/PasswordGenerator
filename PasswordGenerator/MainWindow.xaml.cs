using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using Microsoft.Toolkit.Uwp.Notifications;

namespace PasswordGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Генерирование пароля на основе значений со слайдера
        /// </summary>
        /// <returns>Сгенерированный пароль</returns>
        public string Generate()
        {
            string word = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string number = "123456789";
            string symbol = "!@#№;$%:^?&*()_-+=[]{}\\|/.<>,";

            var random = new Random();
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < SliderWord.Value; i++)
                stringBuilder.Insert(random.Next(0, stringBuilder.Length), word[random.Next(0, word.Length)]);

            for (int i = 0; i < SliderNumber.Value; i++)
                stringBuilder.Insert(random.Next(0, stringBuilder.Length), number[random.Next(0, number.Length)]);

            for (int i = 0; i < SliderSymbol.Value; i++)
                stringBuilder.Insert(random.Next(0, stringBuilder.Length), symbol[random.Next(0, symbol.Length)]);

            return stringBuilder.ToString();
        }
        /// <summary>
        /// Вывод значений со слайдера в текст блок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider1TextBlock1.Text = ((int)SliderSymbol.Value).ToString();
            Slider2TextBlock1.Text = ((int)SliderWord.Value).ToString();
            Slider3TextBlock1.Text = ((int)SliderNumber.Value).ToString();
            Slider1TextBlock.Text = ((int)SliderSymbol.Value + (int)SliderWord.Value + (int)SliderNumber.Value).ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Генерирование пароля
            string password = Generate();
            TextBlockPassword.Text = password;
            if (((int)SliderSymbol.Value > 0) || ((int)SliderWord.Value > 0) || ((int)SliderNumber.Value > 0))
            {
                //Копирование пароля в буфер обмена
                Clipboard.SetText(password);
                //TextBlockPasswordCopied.Text = "*Пароль скопирован в буфер обмена";

                ToastContentBuilder toastContentBuilder = new ToastContentBuilder();
                toastContentBuilder.AddText("Пароль скопирован в буфер обмена");
                toastContentBuilder.Show();
            }
        }

    }
}
