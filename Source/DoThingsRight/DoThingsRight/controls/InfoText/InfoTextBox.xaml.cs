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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DoThingsRight.controls.InfoText
{
    public partial class InfoTextBox : UserControl
    {
        public double time = 0.2;

        public InfoTextBox()
        {
            InitializeComponent();
        }

        public string Text
        {
            get {return (string)GetValue(TextProperty);}
            set { SetValue(TextProperty, value);}
        }

        public static DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text),typeof(string), typeof(InfoTextBox), new PropertyMetadata(null));

        public string InfoText
        {
            get { return (string)GetValue(InfoTextProperty); }
            set { SetValue(InfoTextProperty, value); }
        }

        public static DependencyProperty InfoTextProperty = DependencyProperty.Register(nameof(InfoText)
            , typeof(string), typeof(InfoTextBox), new PropertyMetadata(null));

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(myTextBox.Text))
            {
                myTextBlock.Opacity = 0;

                //Storyboard storyOpacity = new Storyboard();
                //DoubleAnimation animationOpacity = new DoubleAnimation(0.5, 0, new Duration(TimeSpan.FromSeconds(time)));
                //Storyboard.SetTarget(animationOpacity, myTextBlock);
                //Storyboard.SetTargetProperty(animationOpacity, new PropertyPath("Opacity"));
                //storyOpacity.Children.Add(animationOpacity);
                //storyOpacity.Begin();
            }
            else
            {
                myTextBlock.Opacity = 0.5;

                //Storyboard storyOpacity = new Storyboard();
                //DoubleAnimation animationOpacity = new DoubleAnimation(0, 0.5, new Duration(TimeSpan.FromSeconds(time)));
                //Storyboard.SetTarget(animationOpacity, myTextBlock);
                //Storyboard.SetTargetProperty(animationOpacity, new PropertyPath("Opacity"));
                //storyOpacity.Children.Add(animationOpacity);
                //storyOpacity.Begin();
            }
        }
    }
}
