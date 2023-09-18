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

namespace DoThingsRight.controls.DesignedCheck
{
    public partial class DesignedCheckBox : UserControl
    {
        public DesignedCheckBox()
        {
            InitializeComponent();

            Loaded += DesignedCheckBox_Loaded;
            //将鼠标进入和离开事件绑定到动画
            MouseEnter += CustomControl_MouseEnter;
            MouseLeave += CustomControl_MouseLeave;
            MouseLeftButtonDown += MyCheckBox_MouseLeftButtonDown;
        }

        public ImageBrush imageFront = new ImageBrush();
        public ImageBrush imageUnchecked = new ImageBrush();
        public ImageBrush imageChecked = new ImageBrush();

        public string pathFront;
        public string pathUnchecked;
        public string pathChecked;

        public double time = 0.3;//控制动画时间

        private void DesignedCheckBox_Loaded(object sender, RoutedEventArgs e)
        {
            pathFront = FrontImage;
            pathUnchecked = UncheckedImage;
            pathChecked = CheckedImage;

            imageFront.ImageSource = new BitmapImage(new Uri(pathFront, UriKind.Relative));
            imageFront.Stretch = Stretch.Fill;
            imageUnchecked.ImageSource = new BitmapImage(new Uri(pathUnchecked, UriKind.Relative));
            imageUnchecked.Stretch = Stretch.Fill;
            imageChecked.ImageSource = new BitmapImage(new Uri(pathChecked, UriKind.Relative));
            imageChecked.Stretch = Stretch.Fill;

            Front.Source = imageFront.ImageSource;
            BehindUnchecked.Source = imageUnchecked.ImageSource;
            BehindChecked.Source = imageChecked.ImageSource;
        }

        #region 勾选和取消勾选状态转换
        private void MyCheckBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!TheCheckBox.IsChecked)
            {
                TheCheckBox.IsChecked = true;
            }
            else
            {
                TheCheckBox.IsChecked = false;
            }
        }
        #endregion

        #region 鼠标移入移出动画
        private void CustomControl_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard storyOpacity = new Storyboard();
            DoubleAnimation animationOpacity = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(time)));
            Storyboard.SetTarget(animationOpacity, Front);
            Storyboard.SetTargetProperty(animationOpacity, new PropertyPath("Opacity"));
            storyOpacity.Children.Add(animationOpacity);
            storyOpacity.Begin();
        }

        private void CustomControl_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard storyOpacity = new Storyboard();
            DoubleAnimation animationOpacity = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(time)));
            Storyboard.SetTarget(animationOpacity, Front);
            Storyboard.SetTargetProperty(animationOpacity, new PropertyPath("Opacity"));
            storyOpacity.Children.Add(animationOpacity);
            storyOpacity.Begin();
        }
        #endregion

        #region 前景图
        public static readonly DependencyProperty FrontImageProperty =
        DependencyProperty.Register("FrontImage", typeof(string), typeof(DesignedCheckBox), new PropertyMetadata(null));

        public string FrontImage
        {
            get { return (string)GetValue(FrontImageProperty); }
            set { SetValue(FrontImageProperty, value); }
        }
        #endregion

        #region 勾选后图片
        public static readonly DependencyProperty CheckedImageProperty =
            DependencyProperty.Register("CheckedImage", typeof(string),
                typeof(DesignedCheckBox), new PropertyMetadata(null));

        public string CheckedImage
        {
            get { return (string)GetValue(CheckedImageProperty); }
            set { SetValue(CheckedImageProperty, value); }
        }
        #endregion

        #region 未勾选图片
        public static readonly DependencyProperty UnCheckedImageProperty =
            DependencyProperty.Register("UnCheckedImage", typeof(string),
                typeof(DesignedCheckBox), new PropertyMetadata(null));

        public string UncheckedImage
        {
            get { return (string)GetValue(UnCheckedImageProperty); }
            set { SetValue(UnCheckedImageProperty, value); }
        }
        #endregion

        #region 记录是否勾选状态，勾选状态改变时动画
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register(nameof(IsChecked), typeof(bool),
                typeof(DesignedCheckBox), new PropertyMetadata(false, OnIsCheckedChanged));

        private static void OnIsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var TheCheckBox = d as DesignedCheckBox;
            var BehindChecked = TheCheckBox.FindName("BehindChecked") as Image;
            var BehindUnchecked = TheCheckBox.FindName("BehindUnchecked") as Image;

            if (TheCheckBox.IsChecked)
            {
                Storyboard storyOpacityChecked = new Storyboard();
                DoubleAnimation animationOpacityChecked = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.3)));
                Storyboard.SetTarget(animationOpacityChecked, BehindChecked);
                Storyboard.SetTargetProperty(animationOpacityChecked, new PropertyPath("Opacity"));
                storyOpacityChecked.Children.Add(animationOpacityChecked);
                storyOpacityChecked.Begin();

                Storyboard storyOpacityUnchecked = new Storyboard();
                DoubleAnimation animationOpacityUnchecked = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(0.3)));
                Storyboard.SetTarget(animationOpacityUnchecked, BehindUnchecked);
                Storyboard.SetTargetProperty(animationOpacityUnchecked, new PropertyPath("Opacity"));
                storyOpacityUnchecked.Children.Add(animationOpacityUnchecked);
                storyOpacityUnchecked.Begin();
            }
            else
            {
                Storyboard storyOpacityChecked = new Storyboard();
                DoubleAnimation animationOpacityChecked = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(0.3)));
                Storyboard.SetTarget(animationOpacityChecked, BehindChecked);
                Storyboard.SetTargetProperty(animationOpacityChecked, new PropertyPath("Opacity"));
                storyOpacityChecked.Children.Add(animationOpacityChecked);
                storyOpacityChecked.Begin();

                Storyboard storyOpacityUnchecked = new Storyboard();
                DoubleAnimation animationOpacityUnchecked = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.3)));
                Storyboard.SetTarget(animationOpacityUnchecked, BehindUnchecked);
                Storyboard.SetTargetProperty(animationOpacityUnchecked, new PropertyPath("Opacity"));
                storyOpacityUnchecked.Children.Add(animationOpacityUnchecked);
                storyOpacityUnchecked.Begin();
            }
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        #endregion
    }
}
