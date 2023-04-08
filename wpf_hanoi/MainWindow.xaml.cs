using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace wpf_hanoi
{
    public partial class MainWindow : Window
    {
        private List<Button> buttons;
        private List<int> numbers;
        private int firstButtonIndex = -1;
        private int secondButtonIndex = -1;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            // создаем список кнопок и чисел
            buttons = grid.Children.OfType<Button>().ToList();
            numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 };

            // перемешиваем числа
            var rnd = new Random();
            numbers = numbers.OrderBy(x => rnd.Next()).ToList();

            // задаем числа на кнопках
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Tag = numbers[i];
                buttons[i].Content = "?";
                buttons[i].Foreground = Brushes.Black;
                buttons[i].IsEnabled = true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int buttonIndex = buttons.IndexOf((Button)sender);
            if (buttonIndex == firstButtonIndex || buttonIndex == secondButtonIndex)
                return;

            ((Button)sender).Content = ((Button)sender).Tag.ToString();
            ((Button)sender).Foreground = Brushes.Black;

            if (firstButtonIndex == -1)
            {
                firstButtonIndex = buttonIndex;
            }
            else
            {
                secondButtonIndex = buttonIndex;
                if ((int)buttons[firstButtonIndex].Tag == (int)buttons[secondButtonIndex].Tag)
                {
                    buttons[firstButtonIndex].IsEnabled = false;
                    buttons[secondButtonIndex].IsEnabled = false;
                }
                else
                {
                    buttons[firstButtonIndex].Content = "?";
                    buttons[firstButtonIndex].Foreground = Brushes.Black;
                    buttons[secondButtonIndex].Content = "?";
                    buttons[secondButtonIndex].Foreground = Brushes.Black;
                }
                firstButtonIndex = -1;
                secondButtonIndex = -1;
            }
        }


        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeGame();
        }
    }
}