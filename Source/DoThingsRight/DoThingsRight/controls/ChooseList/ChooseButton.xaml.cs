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

namespace DoThingsRight.controls.ChooseList
{
    /// <summary>
    /// ChooseButton.xaml 的交互逻辑
    /// </summary>
    public partial class ChooseButton : UserControl
    {
        public ChooseButton()
        {
            InitializeComponent();

            Loaded += ChooseButton_Loaded;

            //将鼠标进入和离开事件绑定到动画
            MouseEnter += CustomControl_MouseEnter;
            MouseLeave += CustomControl_MouseLeave;
            //MouseLeftButtonDown += MyCheckBox_MouseLeftButtonDown;
        }

        public ImageBrush imageFront = new ImageBrush();
        public ImageBrush imageUnchoose = new ImageBrush();
        public ImageBrush imageChoose = new ImageBrush();

        public string pathFront;
        public string pathUnchoose;
        public string pathChoose;

        public double time = 0.3;//控制动画时间

        private void ChooseButton_Loaded(object sender, RoutedEventArgs e)
        {
            pathFront = FrontImage;
            pathUnchoose=UnchooseImage;
            pathChoose = ChooseImage;

            imageFront.ImageSource = new BitmapImage(new Uri(pathFront, UriKind.Relative));
            imageFront.Stretch = Stretch.Fill;
            imageUnchoose.ImageSource = new BitmapImage(new Uri(pathUnchoose, UriKind.Relative));
            imageUnchoose.Stretch = Stretch.Fill;
            imageChoose.ImageSource = new BitmapImage(new Uri(pathChoose, UriKind.Relative));
            imageChoose.Stretch = Stretch.Fill;

            Front.Source = imageFront.ImageSource;
            BehindUnchoose.Source = imageUnchoose.ImageSource;
            BehindChoose.Source = imageChoose.ImageSource;
        }

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
        DependencyProperty.Register("FrontImage", typeof(string), typeof(ChooseButton), new PropertyMetadata(null));

        public string FrontImage
        {
            get { return (string)GetValue(FrontImageProperty); }
            set { SetValue(FrontImageProperty, value); }
        }
        #endregion

        #region 勾选后图片
        public static readonly DependencyProperty ChooseImageProperty =
            DependencyProperty.Register("ChooseImage", typeof(string),
                typeof(ChooseButton), new PropertyMetadata(null));

        public string ChooseImage
        {
            get { return (string)GetValue(ChooseImageProperty); }
            set { SetValue(ChooseImageProperty, value); }
        }
        #endregion

        #region 未勾选图片
        public static readonly DependencyProperty UnChooseImageProperty =
            DependencyProperty.Register("UnChooseImage", typeof(string),
                typeof(ChooseButton), new PropertyMetadata(null));

        public string UnchooseImage
        {
            get { return (string)GetValue(UnChooseImageProperty); }
            set { SetValue(UnChooseImageProperty, value); }
        }
        #endregion

        #region 记录是否勾选状态
        public static readonly DependencyProperty IsChooseProperty =
            DependencyProperty.Register(nameof(IsChoose), typeof(bool),
                typeof(ChooseButton), new PropertyMetadata(false, OnIsCheckedPropertyChanged));

        private static void OnIsCheckedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var TheCheckBox = d as ChooseButton;
            var BehindChoose = TheCheckBox.FindName("BehindChoose") as Image;
            var BehindUnchoose = TheCheckBox.FindName("BehindUnchoose") as Image;

            if (TheCheckBox.IsChoose)
            {
                Storyboard storyOpacityChecked = new Storyboard();
                DoubleAnimation animationOpacityChecked = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.3)));
                Storyboard.SetTarget(animationOpacityChecked, BehindChoose);
                Storyboard.SetTargetProperty(animationOpacityChecked, new PropertyPath("Opacity"));
                storyOpacityChecked.Children.Add(animationOpacityChecked);
                storyOpacityChecked.Begin();

                Storyboard storyOpacityUnchecked = new Storyboard();
                DoubleAnimation animationOpacityUnchecked = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(0.3)));
                Storyboard.SetTarget(animationOpacityUnchecked, BehindUnchoose);
                Storyboard.SetTargetProperty(animationOpacityUnchecked, new PropertyPath("Opacity"));
                storyOpacityUnchecked.Children.Add(animationOpacityUnchecked);
                storyOpacityUnchecked.Begin();
            }
            else
            {
                Storyboard storyOpacityChecked = new Storyboard();
                DoubleAnimation animationOpacityChecked = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(0.3)));
                Storyboard.SetTarget(animationOpacityChecked, BehindChoose);
                Storyboard.SetTargetProperty(animationOpacityChecked, new PropertyPath("Opacity"));
                storyOpacityChecked.Children.Add(animationOpacityChecked);
                storyOpacityChecked.Begin();

                Storyboard storyOpacityUnchecked = new Storyboard();
                DoubleAnimation animationOpacityUnchecked = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.3)));
                Storyboard.SetTarget(animationOpacityUnchecked, BehindUnchoose);
                Storyboard.SetTargetProperty(animationOpacityUnchecked, new PropertyPath("Opacity"));
                storyOpacityUnchecked.Children.Add(animationOpacityUnchecked);
                storyOpacityUnchecked.Begin();
            }
        }

        public bool IsChoose
        {
            get { return (bool)GetValue(IsChooseProperty); }
            set { SetValue(IsChooseProperty, value); }
        }
        #endregion
    }
}
