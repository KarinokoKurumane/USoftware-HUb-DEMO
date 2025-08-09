using System.Windows;
using System.Windows.Controls;

namespace USoftware_HUb.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy FaqItem.xaml
    /// </summary>
    public partial class FaqItem : UserControl
    {
        public static readonly DependencyProperty QuestionProperty =
            DependencyProperty.Register("Question", typeof(string), typeof(FaqItem));

        public static readonly DependencyProperty AnswerProperty =
            DependencyProperty.Register("Answer", typeof(string), typeof(FaqItem));

        public string Question
        {
            get => (string)GetValue(QuestionProperty);
            set => SetValue(QuestionProperty, value);
        }

        public string Answer
        {
            get => (string)GetValue(AnswerProperty);
            set => SetValue(AnswerProperty, value);
        }

        public FaqItem()
        {
            InitializeComponent();
        }
    }
}
