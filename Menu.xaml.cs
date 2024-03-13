using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public partial class Menu : Window
    {
        List<Word> words;
        Algorithms algorithms = new Algorithms();
        public Menu(List<Word> words)
        {
            this.words = words;
            InitializeComponent();
            if (words.Count == 0)
            {
                warningLabel.Content = "Warning! The libary is emtpy, you must create a libary to use the rest of the program!";
                loadLibary.Visibility = Visibility.Hidden;
                addButton.Visibility = Visibility.Hidden;
                sentenceButton.Visibility = Visibility.Hidden;
                loadButton.Visibility = Visibility.Hidden;
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            words.Clear();

            warningLabel.Content = string.Empty;
            loadLibary.Visibility = Visibility.Hidden;
            createButton.Visibility = Visibility.Hidden;
            addButton.Visibility = Visibility.Hidden;
            sentenceButton.Visibility = Visibility.Hidden;
            loadButton.Visibility = Visibility.Hidden;

            //start
            const string MediaFile = "Massive-text-file.txt";

            if (!File.Exists(MediaFile))
            {
                warningLabel.Content = $"File does not exist, Needs: {MediaFile}";
                return;
            }

            using (StreamReader reader = new StreamReader(MediaFile))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    String[] split = line.Split(" ");

                    //given a split string and word array it will add the split into the word
                    algorithms.addStringArrayToList(split, words);
                }

            }
            //end
            loadLibary.Visibility = Visibility.Visible;
            createButton.Visibility = Visibility.Visible;
            addButton.Visibility = Visibility.Visible;
            sentenceButton.Visibility = Visibility.Visible;
            loadButton.Visibility = Visibility.Visible;
        }

        private void LoadLibButton_Click(object sender, RoutedEventArgs e)
        {
            Libary libary = new Libary(words);
            libary.Show();
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWord addWord = new AddWord(words,algorithms);
            addWord.Show();
            this.Close();
        }

        private void SentenceButton_Click(object sender, RoutedEventArgs e)
        {
            CreateSentence createSent = new CreateSentence(words, algorithms);
            createSent.Show();
            this.Close();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
