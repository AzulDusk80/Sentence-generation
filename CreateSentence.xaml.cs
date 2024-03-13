using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public partial class CreateSentence : Window
    {
        List<Word> words;
        Algorithms algorithms;
        public CreateSentence(List<Word> words, Algorithms algorithms)
        {
            InitializeComponent();
            this.words = words;
            this.algorithms = new Algorithms();
        }

        private void GenButton_Click(object sender, RoutedEventArgs e)
        {
            String[] input = getUserWord();
            createButton.Visibility = Visibility.Hidden;
            if (!string.IsNullOrEmpty(input[0]))
            {
                generatedLabel.Content = "Generating Sentence...";
                String sentence = finishSentence(input[0]);
                generatedLabel.Content = "Generated Sentence:";
                outputSentence.Text = input[1] + sentence;

            }
            //String generatedSentence = finishSentence(words, algorithms, userInput[0]);

            createButton.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu(words);
            menu.Show();
            this.Close();
        }

        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
        }

            private string[] getUserWord() //given words and algorithms, it returns a valid word and the sentence the user inputted
        {
            String currentWord = "";
            String generatedSentece = "";
            
                String userSentence = userInput.Text;
                if (string.IsNullOrEmpty(userSentence))
                {
                    generatedLabel.Content = "Not valid";
                }
                else
                {
                    generatedSentece = userSentence;
                    string[] tempArray = userSentence.Split(" ");
                    string finalWord = tempArray[tempArray.Length - 1];
                    if (algorithms.duplicates(finalWord, words))
                    {
                        if (words[algorithms.indexList(finalWord, words)] is EndWord)
                            generatedLabel.Content = $"Sorry but {finalWord} is an end word.";
                        else
                            currentWord = finalWord;
                    }
                    else if(string.IsNullOrWhiteSpace(finalWord))
                        generatedLabel.Content = "Do not end in blank space!";
                    else
                        generatedLabel.Content =  $"Sorry but {finalWord} is not in our libary";
                }
            
            String[] user = { currentWord, generatedSentece };
            return user;
        }

        public string finishSentence(string currentWord)//given words, algorithms, and valid word. Returns a string generated sentence
        {
            bool notValid = true;
            string generatedSentece = "";
            while (notValid)
            {
                Word current = words[algorithms.indexList(currentWord, words)];
                currentWord = current.nextWord();
                generatedSentece += " " + currentWord;

                if (words[algorithms.indexList(currentWord, words)] is EndWord)
                    notValid = false;

            }

            return generatedSentece;
        }
    }


}
