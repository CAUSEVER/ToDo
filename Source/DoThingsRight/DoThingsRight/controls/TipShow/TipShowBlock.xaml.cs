using DoThingsRight.controls.ChooseList;
using DoThingsRight.controls.InfoText;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoThingsRight.controls.TipShow
{
    /// <summary>
    /// TipShowBlock.xaml 的交互逻辑
    /// </summary>
    public partial class TipShowBlock : UserControl
    {
        public TipShowBlock()
        {
            InitializeComponent();
            Loaded += TipShowBlock_Loaded;
        }

        public ImageBrush imageBracket = new ImageBrush();

        public string pathBracket;

        private void TipShowBlock_Loaded(object sender, RoutedEventArgs e)
        {
            pathBracket = BracketImage;

            imageBracket.ImageSource = new BitmapImage(new Uri(pathBracket, UriKind.Relative));
            imageBracket.Stretch = Stretch.Fill;

            BracketLeft.Source = imageBracket.ImageSource;
            BracketRight.Source = imageBracket.ImageSource;
        }

        #region tipshow内容
        public string TipText
        {
            get { return (string)GetValue(TipTextProperty); }
            set { SetValue(TipTextProperty, value); }
        }

        public static readonly DependencyProperty TipTextProperty =
            DependencyProperty.Register("TipText", typeof(string), typeof(TipShowBlock),
                new PropertyMetadata(string.Empty));
        #endregion

        #region 括号图片
        public static readonly DependencyProperty BracketImageProperty =
            DependencyProperty.Register("BracketImage", typeof(string),
                typeof(ChooseButton), new PropertyMetadata(null));

        public string BracketImage
        {
            get { return (string)GetValue(BracketImageProperty); }
            set { SetValue(BracketImageProperty, value); }
        }
        #endregion
    }
}
