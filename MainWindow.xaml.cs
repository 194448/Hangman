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
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();


            System.IO.StreamReader sr = new System.IO.StreamReader("Words.txt");
            int counter = 0;
            int num = rnd.Next(1, 10);
            while (!sr.EndOfStream) 
            {
                Words[counter] = sr.ReadLine();
                if (counter == num)
                {
                    MessageBox.Show(Words[counter]);
                    WordHint.Text = Words[counter].ToString();
                }
                
                counter++;
            }
            sr.Close(); 
        }
    }
}
