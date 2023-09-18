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

namespace DoThingsRight.controls.Close
{
    /// <summary>
    /// CloseButton.xaml 的交互逻辑
    /// </summary>
    public partial class CloseButton : Button
    {
        public CloseButton()
        {
            InitializeComponent();
            TrueClose.Loaded += TrueClose_Loaded; ;
        }

        public ImageBrush imageCloseEnter = new ImageBrush();
        public string pathCloseEnter = "pic/closeEnter.png";

        public double time = 0.3;//控制动画时间

        private void TrueClose_Loaded(object sender, RoutedEventArgs e)
        {
            imageCloseEnter.ImageSource = new BitmapImage(new Uri(pathCloseEnter, UriKind.Relative));
            imageCloseEnter.Stretch = Stretch.Fill;

            var deleteEnter = Template.FindName("CloseEnter", this) as Border;

            deleteEnter.Width = TrueClose.Width;
            deleteEnter.Height = TrueClose.Height;
            deleteEnter.Background = imageCloseEnter;
        }

        private void baseGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            var closeEnter = Template.FindName("CloseEnter", this) as Border;

            Storyboard storyOpacity = new Storyboard();
            DoubleAnimation animationOpacity = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(time)));
            Storyboard.SetTarget(animationOpacity, closeEnter);
            Storyboard.SetTargetProperty(animationOpacity, new PropertyPath("Opacity"));
            storyOpacity.Children.Add(animationOpacity);
            storyOpacity.Begin();
        }

        private void baseGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            var closeEnter = Template.FindName("CloseEnter", this) as Border;
            Storyboard storyOpacity = new Storyboard();
            DoubleAnimation animationOpacity = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(time)));
            Storyboard.SetTarget(animationOpacity, closeEnter);
            Storyboard.SetTargetProperty(animationOpacity, new PropertyPath("Opacity"));
            storyOpacity.Children.Add(animationOpacity);
            storyOpacity.Begin();
        }
    }
}
