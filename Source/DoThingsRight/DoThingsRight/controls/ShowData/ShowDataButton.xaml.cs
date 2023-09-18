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

namespace DoThingsRight.controls.ShowData
{
    /// <summary>
    /// ShowDataButton.xaml 的交互逻辑
    /// </summary>
    public partial class ShowDataButton : Button
    {
        public ShowDataButton()
        {
            InitializeComponent();
            DisplayDataButton.Loaded += DisplayDataButton_Loaded;
        }

        public ImageBrush imageEnter = new ImageBrush();
        public string pathEnter = "pic/showDataEnter.png";

        public double time = 0.3;//控制动画时间

        private void DisplayDataButton_Loaded(object sender, RoutedEventArgs e)
        {
            imageEnter.ImageSource = new BitmapImage(new Uri(pathEnter, UriKind.Relative));
            imageEnter.Stretch = Stretch.Fill;

            var buttonEnter = Template.FindName("ButtonEnter", this) as Border;

            buttonEnter.Width = DisplayDataButton.Width;
            buttonEnter.Height = DisplayDataButton.Height;
            buttonEnter.Background = imageEnter;
        }

        private void baseGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            var buttonEnter = Template.FindName("ButtonEnter", this) as Border;

            Storyboard storyOpacity = new Storyboard();
            DoubleAnimation animationOpacity = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(time)));
            Storyboard.SetTarget(animationOpacity, buttonEnter);
            Storyboard.SetTargetProperty(animationOpacity, new PropertyPath("Opacity"));
            storyOpacity.Children.Add(animationOpacity);
            storyOpacity.Begin();
        }

        private void baseGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            var buttonEnter = Template.FindName("ButtonEnter", this) as Border;
            Storyboard storyOpacity = new Storyboard();
            DoubleAnimation animationOpacity = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(time)));
            Storyboard.SetTarget(animationOpacity, buttonEnter);
            Storyboard.SetTargetProperty(animationOpacity, new PropertyPath("Opacity"));
            storyOpacity.Children.Add(animationOpacity);
            storyOpacity.Begin();
        }
    }
}
