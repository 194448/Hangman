using System;
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

namespace Hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] Words = new string[10];
        string Word2Guess = "";
        string tempword = "";
        Random rnd = new Random();
        Button[] btnLetters;
        int BadGuess = 0;
        public MainWindow()
        {
            InitializeComponent();
            addButtons();
            System.IO.StreamReader sr = new System.IO.StreamReader("Words.txt");
            int counter = 0;
            int num = rnd.Next(1, 10);
            while (!sr.EndOfStream) 
            {
                Words[counter] = sr.ReadLine();
                if (counter == num)
                {
                    //MessageBox.Show(Words[counter]);
                    //WordHint.Text = Words[counter].ToString();
                    string Word2Guess = Words[counter].ToString();
                    //WordHint.Text = Word2Guess.ToString();
                    lblWord2Guess.Content = Word2Guess.ToString();
                    for (int i = 0; i < Word2Guess.Length; i++)
                    {
                        WordHint.Text += "_ ";
                    }
                }
                
                counter++;
            }
            sr.Close();
            Word2Guess = lblWord2Guess.Content.ToString();
           

        }

        private void delButtons()
        {
            LetterLocation.Children.Clear();
        }

        private void addButtons()
        {
            btnLetters = new Button[26];
            int A = (int)'A';
            for (int i = 0; i < 26; i++) 
            {
                btnLetters[i] = new Button() { Content = ((char)(i + A)).ToString(), Width = 40 };
                btnLetters[i].Click += btnGuessLetters;
                LetterLocation.Children.Add(btnLetters[i]);
            }
        }

        private void btnGuessLetters(object sender, RoutedEventArgs e)
        {
            Button temp = (Button)sender;
            string Letter2Guess = temp.Content.ToString();
            for (int i = 0; i < Word2Guess.Length; i++)
            {
                if (Letter2Guess == Word2Guess[i].ToString().ToUpper())
                {
                    tempword += Word2Guess[i] + " ";
                }

                else
                {
                    tempword += WordHint.Text.ToString()[i * 2] + " ";
                }
            }
            if (tempword == WordHint.Text)
            {
                BadGuess++;
            }

            //MessageBox.Show(tempword.ToString());
            WordHint.Text = tempword;
            tempword = "";
            //MessageBox.Show(temp.Content.ToString());
            temp.Visibility = Visibility.Hidden;
        }

        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {
            if (txtbxInput.Text.ToUpper() == lblWord2Guess.Content.ToString().ToUpper())
            {
                lblWin.Visibility = Visibility.Visible;
            }

            else
            {
                BadGuess++;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            string[] Words = new string[10];
            string tempword = "";
            int BadGuess = 0;


            System.IO.StreamReader sr = new System.IO.StreamReader("Words.txt");
            delButtons();
            int counter = 0;
            int num = rnd.Next(1, 10);
            WordHint.Text = "";
            lblWin.Visibility = Visibility.Collapsed;
            while (!sr.EndOfStream)
            {
                Words[counter] = sr.ReadLine();
                if (counter == num)
                {
                    //MessageBox.Show(Words[counter]);
                    //WordHint.Text = Words[counter].ToString();
                    string Word2Guess = Words[counter].ToString();
                    //WordHint.Text = Word2Guess.ToString();
                    lblWord2Guess.Content = Word2Guess.ToString();
                    for (int i = 0; i < Word2Guess.Length; i++)
                    {
                        WordHint.Text += "_ ";
                    }
                }

                counter++;
            }
            sr.Close();
            Word2Guess = lblWord2Guess.Content.ToString();
            txtbxInput.Text = "";
            addButtons();

        }
    }
}
