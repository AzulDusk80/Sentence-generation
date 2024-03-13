using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public partial class AddWord : Window
    {
        List<Word> words;
        Algorithms algorithms;
        public AddWord(List<Word> words, Algorithms algorithms)
        {
            this.words = words;
            this.algorithms = algorithms;
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string inputName = name.Text;
            string inputBefore = befores.Text;
            string inputAfter = afters.Text;
            warningLabel.Content = "";
            if (!String.IsNullOrEmpty(inputName))
            {
                if (algorithms.duplicates(inputName, words))
                {
                    if (MessageBox.Show("This already exist, do you want to add to it?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        validateBeforeAfterThenAdd(inputAfter, inputBefore, inputName);
                    }
                }
                else
                {
                    validateBeforeAfterThenAdd(inputAfter, inputBefore, inputName);
                }
            }
            else
            {
                warningLabel.Content += "Name can not be empty!";
                warningLabel.Visibility = Visibility.Visible;
            }
        }

        private void validateBeforeAfterThenAdd(string inputAfter, string inputBefore, string inputName)
        {
            if (validList(inputAfter))
            {
                if (validList(inputBefore))
                {
                    title.Content = "Adding word";
                    warningLabel.Visibility = Visibility.Hidden;
                    addButton.Visibility = Visibility.Hidden;

                    algorithms.addWordBasedOnString(inputName, inputBefore.Split(" "), inputAfter.Split(" "), words);
                    title.Content = $"{inputName} has been update in the library";
                    name.Text = string.Empty;
                    befores.Text = string.Empty;
                    afters.Text = string.Empty;

                    addButton.Visibility = Visibility.Visible;
                }
                else
                {
                    warningLabel.Visibility = Visibility.Visible;
                }
            }
            else
            {
                warningLabel.Visibility = Visibility.Visible;
            }
        }

        private bool validList(String s)//verifies if the list is valid
        {
            String[] arrayBefore = s.Split(" ");
            bool space = false;
            bool repeats = true;
            String fails = "";
            for (int i = 0; i < arrayBefore.Length; i++)
            {
                if (String.IsNullOrEmpty(arrayBefore[i]))
                    space = true;
                else if (arrayBefore[i].Equals(" "))
                    space = true;
                if (!algorithms.duplicates(arrayBefore[i], words))
                {
                    repeats = false;
                    fails += arrayBefore[i] + " ";
                }
            }

            if (space)
            {
                warningLabel.Content +=  "Invalid input";
            }
            else if (!repeats)
            {
                warningLabel.Content += $"Word is not in the libary: {fails}";
            }
            else
            {
                return true;
            }
            return false;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu(words);
            menu.Show();
            this.Close();
        }
    }
}
