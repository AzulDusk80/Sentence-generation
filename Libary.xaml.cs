using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public partial class Libary : Window
    {
        List<Word> words;
        public Libary(List<Word> words)
        {
            this.words = words;
            InitializeComponent();

            string[] listWord = new string[words.Count];
            for (int i = 0; i < words.Count; i++)
            {
                listWord[i] = words[i].ToString();
            }

            listBox.ItemsSource = listWord;
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu(words);
            menu.Show();
            this.Close();
        }
    }
}
