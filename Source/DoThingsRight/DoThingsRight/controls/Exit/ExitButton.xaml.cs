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

namespace DoThingsRight.controls.Exit
{
    /// <summary>
    /// ExitButton.xaml 的交互逻辑
    /// </summary>
    public partial class ExitButton : Button
    {
        public ExitButton()
        {
            InitializeComponent();
            RoundButton.Loaded += RoundButton_Loaded;
        }

        public ImageBrush imageAround = new ImageBrush();
        public ImageBrush imageAroundEnter = new ImageBrush();
        public string pathAround = "pic/Around.png";
        public string pathAroundEnter = "pic/AroundEnter.png";

        public double time = 0.3;//控制动画时间

        private void RoundButton_Loaded(object sender, RoutedEventArgs e)//初始化
        {
            imageAroundEnter.ImageSource = new BitmapImage(new Uri(pathAroundEnter, UriKind.Relative));
            imageAroundEnter.Stretch = Stretch.Fill;
            imageAround.ImageSource = new BitmapImage(new Uri(pathAround, UriKind.Relative));
            imageAround.Stretch = Stretch.Fill;

            var around = Template.FindName("Around", this) as Border;
            var aroundEnter = Template.FindName("AroundEnter", this) as Border;

            around.Width = RoundButton.Width;
            around.Height = RoundButton.Height;
            around.Background = imageAround;

            aroundEnter.Width = RoundButton.Width;
            aroundEnter.Height = RoundButton.Height;
            aroundEnter.Background = imageAroundEnter;

            RotateTransform rotate = new RotateTransform();
            //绑定旋转中心
            aroundEnter.RenderTransform = rotate;
            //设置旋转中心百分比
            aroundEnter.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        private void baseGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            var around = Template.FindName("Around", this) as Border;
            around.Background = Brushes.Transparent;

            var aroundEnter = Template.FindName("AroundEnter", this) as Border;
            Storyboard storyRotate = new Storyboard();
            DoubleAnimation animationRotate = new DoubleAnimation(0, 360, new Duration(TimeSpan.FromSeconds(time)));
            Storyboard.SetTarget(animationRotate, aroundEnter);
            Storyboard.SetTargetProperty(animationRotate, new PropertyPath("RenderTransform.Angle"));
            storyRotate.Children.Add(animationRotate);
            storyRotate.Begin();

            Storyboard storyOpacity = new Storyboard();
            DoubleAnimation animationOpacity = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(time)));
            Storyboard.SetTarget(animationOpacity, aroundEnter);
            Storyboard.SetTargetProperty(animationOpacity, new PropertyPath("Opacity"));
            storyOpacity.Children.Add(animationOpacity);
            storyOpacity.Begin();
        }

        private void baseGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            var around = Template.FindName("Around", this) as Border;
            around.Background = imageAround;

            var aroundEnter = Template.FindName("AroundEnter", this) as Border;
            Storyboard storyOpacity = new Storyboard();
            DoubleAnimation animationOpacity = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(time)));
            Storyboard.SetTarget(animationOpacity, aroundEnter);
            Storyboard.SetTargetProperty(animationOpacity, new PropertyPath("Opacity"));
            storyOpacity.Children.Add(animationOpacity);
            storyOpacity.Begin();
        }
    }
}
