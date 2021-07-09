using humanrights.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace humanrights
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        public Quiz currentQuestion = new Quiz();
        public int pos = 0;
        public int correctCount = 0;
        public int totalCount = 0;

        public ObservableCollection<Quiz> _quiz = new ObservableCollection<Quiz>();
        Random rnd = new Random();


        public QuizWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            currentQuestion = App._quiz[0];
            this._quiz = App._quiz;
            this.totalCount = this._quiz.Count;
            this.generateAnswer(currentQuestion); 
        }

        private void generateAnswer(Quiz currentQuestion)
        {
            List<string> answers = new List<string>();

            quesBlock.Text = currentQuestion.question;
            answers.Add(currentQuestion.answer);
            do
            {
                int index = rnd.Next(4);
                if (!answers.Contains(this._quiz[index].answer))
                {
                    answers.Add(this._quiz[index].answer);
                }
            } while (answers.Count < 4);
            List<string> shuffledAnswers = answers.OrderBy(a => rnd.Next(4)).ToList();
            Lbx_answers.ItemsSource = shuffledAnswers;

        }

        private void Cbx_selected(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;

            tbx_marked_answer.Visibility = Visibility.Visible;

            if (radioButton.Content.ToString() == this.currentQuestion.answer)
            {
                tbx_marked_answer.Text = "Congratulations!! Your Answer is Correct";
                tbx_marked_answer.Foreground = Brushes.Green;
                this.correctCount++;
                
            }
            
            else
            {
                tbx_marked_answer.Text = "You have selected Incorrect Answers!answer is : " + currentQuestion.answer;
                tbx_marked_answer.Foreground = Brushes.Red;
               

            }

            


        }

        private void Button_Next_Page(object sender, RoutedEventArgs e)
        {
            this.pos++;
            tbx_marked_answer.Text = String.Empty;
            currentQuestion = this._quiz[this.pos];
            this.generateAnswer(currentQuestion);
            if (this.pos == (this._quiz.Count - 1))
            {
                btn_next.Visibility = Visibility.Hidden;
                btn_finish.Visibility = Visibility.Visible;
            }


        }

        private void Button_Finish_Page(object sender, RoutedEventArgs e)
        {
           
            MessageBox.Show("Right Answers: " + correctCount + " out of Total " + _quiz.Count + " Questions!");

            correctCount = 0;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;
        }
    }
}
