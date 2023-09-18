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

namespace DoThingsRight.controls.Delete
{
    /// <summary>
    /// DeleteButton.xaml 的交互逻辑
    /// </summary>
    public partial class DeleteButton : Button
    {
        public DeleteButton()
        {
            InitializeComponent();
            TrashButton.Loaded += TrashButton_Loaded;
        }

        public ImageBrush imageDeleteEnter = new ImageBrush();
        public string pathDeleteEnter = "pic/deleteEnter.png";

        public double time = 0.3;//控制动画时间

        private void TrashButton_Loaded(object sender, RoutedEventArgs e)
        {
            imageDeleteEnter.ImageSource = new BitmapImage(new Uri(pathDeleteEnter, UriKind.Relative));
            imageDeleteEnter.Stretch = Stretch.Fill;

            var deleteEnter = Template.FindName("DeleteEnter", this) as Border;

            deleteEnter.Width = TrashButton.Width;
            deleteEnter.Height = TrashButton.Height;
            deleteEnter.Background = imageDeleteEnter;
        }

        private void baseGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            var deleteEnter = Template.FindName("DeleteEnter", this) as Border;

            Storyboard storyOpacity = new Storyboard();
            DoubleAnimation animationOpacity = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(time)));
            Storyboard.SetTarget(animationOpacity, deleteEnter);
            Storyboard.SetTargetProperty(animationOpacity, new PropertyPath("Opacity"));
            storyOpacity.Children.Add(animationOpacity);
            storyOpacity.Begin();
        }

        private void baseGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            var deleteEnter = Template.FindName("DeleteEnter", this) as Border;
            Storyboard storyOpacity = new Storyboard();
            DoubleAnimation animationOpacity = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(time)));
            Storyboard.SetTarget(animationOpacity, deleteEnter);
            Storyboard.SetTargetProperty(animationOpacity, new PropertyPath("Opacity"));
            storyOpacity.Children.Add(animationOpacity);
            storyOpacity.Begin();
        }
    }
}
