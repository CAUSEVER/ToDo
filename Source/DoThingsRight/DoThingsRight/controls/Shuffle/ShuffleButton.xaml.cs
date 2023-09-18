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

namespace DoThingsRight.controls.Shuffle
{
    /// <summary>
    /// ShuffleButton.xaml 的交互逻辑
    /// </summary>
    public partial class ShuffleButton : Button
    {
        public ShuffleButton()
        {
            InitializeComponent();
            RandomButton.Loaded += RandomButton_Loaded;
        }

        public ImageBrush imageShuffleEnter = new ImageBrush();
        public string pathShuffleEnter = "pic/shuffleEnter.png";

        public double time = 0.3;//控制动画时间

        private void RandomButton_Loaded(object sender, RoutedEventArgs e)
        {
            imageShuffleEnter.ImageSource = new BitmapImage(new Uri(pathShuffleEnter, UriKind.Relative));
            imageShuffleEnter.Stretch = Stretch.Fill;

            var shuffleEnter = Template.FindName("ShuffleEnter", this) as Border;

            shuffleEnter.Width = RandomButton.Width;
            shuffleEnter.Height = RandomButton.Height;
            shuffleEnter.Background = imageShuffleEnter;
        }

        private void baseGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            var shuffleEnter = Template.FindName("ShuffleEnter", this) as Border;

            Storyboard storyOpacity = new Storyboard();
            DoubleAnimation animationOpacity = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(time)));
            Storyboard.SetTarget(animationOpacity, shuffleEnter);
            Storyboard.SetTargetProperty(animationOpacity, new PropertyPath("Opacity"));
            storyOpacity.Children.Add(animationOpacity);
            storyOpacity.Begin();
        }

        private void baseGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            var shuffleEnter = Template.FindName("ShuffleEnter", this) as Border;
            Storyboard storyOpacity = new Storyboard();
            DoubleAnimation animationOpacity = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(time)));
            Storyboard.SetTarget(animationOpacity, shuffleEnter);
            Storyboard.SetTargetProperty(animationOpacity, new PropertyPath("Opacity"));
            storyOpacity.Children.Add(animationOpacity);
            storyOpacity.Begin();
        }
    }
}
