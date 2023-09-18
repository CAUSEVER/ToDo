using DoThingsRight.controls.ChooseList;
using DoThingsRight.controls.Close;
using DoThingsRight.controls.DesignedCheck;
using DoThingsRight.controls.Exit;
using DoThingsRight.controls.InfoText;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = System.Windows.Application;
using Cursors = System.Windows.Input.Cursors;
using DragDropEffects = System.Windows.DragDropEffects;
using DragEventArgs = System.Windows.DragEventArgs;
using Window = System.Windows.Window;

namespace DoThingsRight
{
    public partial class MainWindow : Window
    {
        private int count;//记录当前事件的总个数
        private string opting;//记录当前进行操作的位置
        private int checkedCounts;//记录打勾的个数
        private double[] times = new double[15];//记录所有事件所花时间

        #region 图片及路径
        private ImageBrush imageChoice = new ImageBrush();
        private ImageBrush imageOpting = new ImageBrush();
        private ImageBrush imageChoiceMouseOver = new ImageBrush();
        private ImageBrush imageStart = new ImageBrush();
        private ImageBrush imageStop = new ImageBrush();

        private ImageBrush imageChecked = new ImageBrush();
        private ImageBrush imageUnchecked = new ImageBrush();
        private ImageBrush imageCheckBoxMouseOver = new ImageBrush();

        private string pathdoing = "data/doing.txt";
        private string pathdone = "data/donetoday.txt";
        private string pathtimes = "data/times.txt";
        private string pathdata = "data/data.txt";
        private string pathdatafolder = "data";
        #endregion

        public MainWindow()
        {
            #region 图片及文件夹初始化
            imageChoice.ImageSource = new BitmapImage(new Uri(@"pic/choice.png", UriKind.Relative));
            imageChoice.Stretch = Stretch.Fill;//设置图像的显示格式
            imageOpting.ImageSource = new BitmapImage(new Uri(@"pic/opting.png", UriKind.Relative));
            imageOpting.Stretch = Stretch.Fill;//设置图像的显示格式
            imageChoiceMouseOver.ImageSource = new BitmapImage(new Uri(@"pic/choiceMouseOver.png", UriKind.Relative));
            imageChoiceMouseOver.Stretch = Stretch.Fill;//设置图像的显示格式
            imageStart.ImageSource = new BitmapImage(new Uri(@"pic/start.png", UriKind.Relative));
            imageStart.Stretch = Stretch.Fill;//设置图像的显示格式
            imageStop.ImageSource = new BitmapImage(new Uri(@"pic/stop.png", UriKind.Relative));
            imageStop.Stretch = Stretch.Fill;//设置图像的显示格式

            imageChecked.ImageSource = new BitmapImage(new Uri(@"pic/checked.png", UriKind.Relative));
            imageChecked.Stretch = Stretch.Fill;//设置图像的显示格式
            imageUnchecked.ImageSource = new BitmapImage(new Uri(@"pic/unchecked.png", UriKind.Relative));
            imageUnchecked.Stretch = Stretch.Fill;//设置图像的显示格式
            imageCheckBoxMouseOver.ImageSource = new BitmapImage(new Uri(@"pic/checkBoxMouseOver.png", UriKind.Relative));
            imageCheckBoxMouseOver.Stretch = Stretch.Fill;//设置图像的显示格式

            if (!Directory.Exists(pathdatafolder))//判断文件夹是否存在，不存在则创建
            {
                Directory.CreateDirectory(pathdatafolder);
            }
            JudgeFileExists(pathdoing);//判断文件是否存在，若不存在则创建
            JudgeFileExists(pathdone);
            JudgeFileExists(pathtimes);
            JudgeFileExists(pathdata);
            #endregion

            InitializeComponent();

            tipText.BracketImage = "/pic/tipBlockBracket.png";
            stayButton.FrontImage = "/pic/stayMouseOver.png";
            stayButton.CheckedImage = "/pic/stayOn.png";
            stayButton.UncheckedImage = "/pic/stay.png";

            SystemIcon();//任务栏图标函数调用

            Initialize();//初始化函数调用
        }

        #region 托盘图标
        //以下是托盘图标
        internal NotifyIcon notifyIcon = new NotifyIcon();
        public void SystemIcon()
        {
            SetNotifyIcon();//设置托盘图标
            contextMenu();//托盘右键菜单设置
        }

        public void SetNotifyIcon()//设置托盘图标
        {
            notifyIcon.Icon = new System.Drawing.Icon("DoThingsRight.ico");
            notifyIcon.Text = "DoThingsRight";//鼠标在图标上显示的文本
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += OnNotifyIconDoubleClick;//双击事件显示窗口

        }

        private void OnNotifyIconDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Show();//显示窗口
        }

        private void contextMenu()//托盘右键菜单设置
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            //关联 NotifyIcon 和 ContextMenuStrip
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem();
            exitMenuItem.Text = "退出";
            exitMenuItem.Click += exitMenuItem_Click;

            contextMenuStrip.Items.Add(exitMenuItem);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)//退出键
        {
            Save();
            this.notifyIcon.Dispose();
            this.Close();
        }
        //以上是托盘图标
        #endregion

        #region 设置checkBox，textBox，chooseButton
        private void setCheckBox(string checkBoxName)//设置checkBox
        {
            DesignedCheckBox checkBox = new DesignedCheckBox();
            checkBox.Name = checkBoxName;
            checkBox.Height = 15;
            checkBox.Width = 15;
            checkBox.Margin = new Thickness(10);
            checkBox.MouseLeftButtonDown += CheckBox_Click;
            checkBox.FrontImage = "/pic/checkBoxMouseOver.png";
            checkBox.CheckedImage = "/pic/checked.png";
            checkBox.UncheckedImage = "/pic/unchecked.png";
            checkBox.Cursor = Cursors.Hand;
            checkBoxColumn.Children.Add(checkBox);
            checkBoxColumn.RegisterName(checkBoxName, checkBox);
        }

        private void setTextBox(string textBoxName)//设置textBox
        {
            InfoTextBox textBox = new InfoTextBox();
            textBox.Name = textBoxName;
            textBox.Margin = new Thickness(2.5);
            textBox.InfoText = "请输入您想做的事...";
            textBox.Height = 30;
            textBox.KeyDown += InfoTextBox_KeyDown;
            textBoxColumn.Children.Add(textBox);
            textBoxColumn.RegisterName(textBoxName, textBox);
        }

        private void setChooseButton(string chooseButtonName)//chooseButton
        {
            ChooseButton chooseButton = new ChooseButton();
            chooseButton.Name = chooseButtonName;
            chooseButton.Width = 25;
            chooseButton.Height = 25;
            chooseButton.Margin = new Thickness(5);
            chooseButton.FrontImage = "/pic/choiceMouseOver.png";
            chooseButton.ChooseImage = "/pic/opting.png";
            chooseButton.UnchooseImage = "/pic/choice.png";
            chooseButton.Cursor = Cursors.Hand;
            chooseButton.MouseLeftButtonDown += ChooseButton_MouseLeftButtonDown;
            chooseButtonColumn.Children.Add(chooseButton);
            chooseButtonColumn.RegisterName(chooseButtonName, chooseButton);
        }
        #endregion

        #region 规范化时间显示
        private void timeDisplay(string state, double timeshow)//时间显示
        {
            time.Text = state + timeFormat(Math.Floor(timeshow / 60 / 60).ToString())
                + ":" + timeFormat(Math.Floor(timeshow / 60 % 60).ToString())
                + ":" + timeFormat(Math.Floor(timeshow % 60).ToString());
        }
        private string timeFormat(string s)
        {
            if (s.Length == 1)
            {
                return "0" + s;
            }
            else
            {
                return s;
            }
        }//规范化时间
        #endregion

        #region 退出
        //以下是退出部分的代码
        private double animationTime = 0.4;
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            var exitEllipse = MyGrid.FindName("ExitEllipse") as EllipseGeometry;
            exitEllipse.Center = Mouse.GetPosition(this);
            var animationEllipse = new DoubleAnimation()
            {
                From = 0,
                To = 600,
                Duration = new Duration(TimeSpan.FromSeconds(animationTime))
            };
            exitEllipse.BeginAnimation(EllipseGeometry.RadiusXProperty, animationEllipse);
            var animationOpacity = new DoubleAnimation()
            {
                From = 0,
                To = 0.8,
                Duration = new Duration(TimeSpan.FromSeconds(animationTime))
            };
            var target = MyGrid.FindName("ExitPath") as System.Windows.Shapes.Path;
            target.BeginAnimation(System.Windows.Shapes.Path.OpacityProperty, animationOpacity);
            target.MouseLeftButtonDown += ExitPath_MouseLeftButtonDown;

            var close = MyGrid.FindName("close") as CloseButton;
            close.Visibility = Visibility.Visible;
        }//退出动画

        private void ExitPath_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)//点击其他部位的动画
        {
            var target = sender as System.Windows.Shapes.Path;
            target.MouseLeftButtonDown -= ExitPath_MouseLeftButtonDown;

            close.Visibility = Visibility.Hidden;

            var exitEllipse = MyGrid.FindName("ExitEllipse") as EllipseGeometry;
            exitEllipse.Center = Mouse.GetPosition(this);

            var animationEllipse = new DoubleAnimation()
            {
                From = 600,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(animationTime))
            };
            exitEllipse.BeginAnimation(EllipseGeometry.RadiusXProperty, animationEllipse);
            var animationOpacity = new DoubleAnimation()
            {
                From = 0.9,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(animationTime))
            };
            //var target = MyGrid.FindName("ExitPath") as System.Windows.Shapes.Path;
            target.BeginAnimation(System.Windows.Shapes.Path.OpacityProperty, animationOpacity);

            DataScroll.Visibility = Visibility.Hidden;
            ExportData.Visibility = Visibility.Hidden;
        }

        private void close_Click(object sender, RoutedEventArgs e)//退出
        {
            var exitPath = MyGrid.FindName("ExitPath") as System.Windows.Shapes.Path;
            exitPath.MouseLeftButtonDown -= ExitPath_MouseLeftButtonDown;

            var baseplate = MyGrid.FindName("baseplate") as Border;

            var exitEllipse = MyGrid.FindName("ExitEllipse") as EllipseGeometry;
            exitEllipse.Center = Mouse.GetPosition(this);

            baseplate.Opacity = 0;

            var animationEllipse = new DoubleAnimation()
            {
                From = 600,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(animationTime))
            };
            exitEllipse.BeginAnimation(EllipseGeometry.RadiusXProperty, animationEllipse);

            var close = MyGrid.FindName("close") as CloseButton;
            close.Click -= close_Click;

            var animationOpacity = new DoubleAnimation()
            {
                From = 0.9,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(animationTime))
            };
            MyGrid.BeginAnimation(System.Windows.Shapes.Path.OpacityProperty, animationOpacity);

            DispatcherTimer exitTimer = new DispatcherTimer();
            exitTimer.Interval = TimeSpan.FromMilliseconds(1);
            exitTimer.Tick += ExitTimer_Tick;
            exitTimer.Start();
        }

        private void ExitTimer_Tick(object sender, EventArgs e)//等待动画播放完毕后退出
        {
            if (MyGrid.Opacity == 0)
            {
                Save();
                this.notifyIcon.Dispose();
                this.Close();
            }
        }
        //以上是退出部分的代码
        #endregion

        #region 窗口操作，删除，添加，窗口前置
        private void minimize_Click(object sender, RoutedEventArgs e)//隐藏窗口
        {
            this.Hide();
        }

        private const double MinimizedHeight = 54; //缩小后的高度
        private bool isMinimized = false; // 标记窗口是否已缩小

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2) // 界面空白处
            {
                if (isMinimized)
                    RestoreWindow();
                else
                    MinimizeWindow();
            }
            else
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    var windowMode = this.ResizeMode;
                    if (this.ResizeMode != ResizeMode.NoResize)
                    {
                        this.ResizeMode = ResizeMode.NoResize;
                    }
                    this.UpdateLayout();

                    DragMove();
                    if (this.ResizeMode != windowMode)
                    {
                        this.ResizeMode = windowMode;
                    }
                    this.UpdateLayout();
                }
            }
        }//实现窗口拖动，禁止放大与缩小

        private void MinimizeWindow()
        {
            isMinimized = true;

            //WindowState = WindowState.Normal;
            //Width = MinimizedWidth;
            Height = MinimizedHeight;

        }//缩小窗口

        private void RestoreWindow()
        {
            isMinimized = false;
            Height = 520;
        }//恢复窗口大小


        private void stayButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)//保持窗口处于前置状态
        {
            if(stayButton.IsChecked==true)
            {
                Topmost = true;
            }
            else
            {
                Topmost= false;
            }
        }

        private void AddThing_Click(object sender, RoutedEventArgs e)
        {
            if (count <= 10)
            {
                count++;
                string textBoxName = "textBox" + count.ToString();
                setTextBox(textBoxName);

                string checkBoxName = "checkBox" + count.ToString();
                setCheckBox(checkBoxName);

                string chooseButtonName = "chooseButton" + count.ToString();
                setChooseButton(chooseButtonName);

                times[count] = 0;//用时0s

                if (checkedCounts>0)
                {
                    if(opting!=null)
                    {
                        int opt=Convert.ToInt32(opting);
                        if(opt>=count-checkedCounts)
                        {
                            Switchstate("chooseButton"+opting,"chooseButton"+(opt+1).ToString());
                        }
                    }
                    for (int i = count; i >= count - checkedCounts + 1; i--)
                    {
                        switchThings(i, i - 1);
                    }
                }
                
            }

        }//添加键

        private void DeleteThing_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (count - checkedCounts > 0)
            {
                int t=count- checkedCounts;
                int startto = 0;
                string textBoxName = "textBox" + count.ToString();
                string checkBoxName = "checkBox" + count.ToString();
                string chooseButtonName = "chooseButton" + count.ToString();

                string optchooseButtonName = "chooseButton" + opting;
                ChooseButton chooseButtonopt = chooseButtonColumn.FindName(optchooseButtonName) as ChooseButton;

                InfoTextBox textBox = textBoxColumn.FindName(textBoxName) as InfoTextBox;
                DesignedCheckBox checkBox = checkBoxColumn.FindName(checkBoxName) as DesignedCheckBox;
                ChooseButton chooseButton = chooseButtonColumn.FindName(chooseButtonName) as ChooseButton;
                if (textBox != null)//textBox存在
                {
                    if (!isStop)//暂停
                    {
                        if (opting != null)//有选择
                        {
                            if(Convert.ToInt32(opting)<=t)
                            {
                                chooseButtonopt.IsChoose = false;

                                startto = Convert.ToInt32(opting);

                                opting = null;
                                time.Text = "空闲中";
                            }
                            else
                            {
                                showTips("已完成的事件不能删除哦");
                                return;
                            }
                        }
                        else
                        {
                            startto = count-checkedCounts;
                        }

                        for (int i = startto; i <= count - 1; i++)
                        {
                            switchThings(i, i + 1);
                        }

                        textBoxColumn.Children.Remove(textBox);
                        textBoxColumn.UnregisterName(textBoxName);
                        checkBoxColumn.Children.Remove(checkBox);
                        checkBoxColumn.UnregisterName(checkBoxName);
                        chooseButtonColumn.Children.Remove(chooseButton);
                        chooseButtonColumn.UnregisterName(chooseButtonName);
                        times[count] = 0;
                        count--;
                    }
                    else
                    {
                        showTips("计时时不能删除待办");
                    }
                }
            }
        }//删除键
        #endregion

        #region 提示窗口操作使用函数showTips(string s);
        //如下为显示提示窗口的代码
        DispatcherTimer checkTime = new DispatcherTimer();
        DispatcherTimer checkTime2 = new DispatcherTimer();

        private double tiptime = 2;
        private void showTips(string s)//显示提示窗口
        {
            tipText.TipText = s;
            var animationOpacity = new DoubleAnimation()
            {
                From = 0,
                To = 0.8,
                Duration = new Duration(TimeSpan.FromSeconds(tiptime))
            };
            tipText.BeginAnimation(OpacityProperty, animationOpacity);

            checkTime.Interval = TimeSpan.FromMilliseconds(1);
            checkTime.Tick += CheckTime_Tick;
            tipText.Visibility = Visibility.Visible;
            checkTime.Start();

        }

        private void CheckTime_Tick(object sender, EventArgs e)//检测提示窗口状态
        {
            if (tipText.Opacity == 0.8)
            {
                var animationOpacity = new DoubleAnimation()
                {
                    From = 0.8,
                    To = 0,
                    Duration = new Duration(TimeSpan.FromSeconds(tiptime))
                };
                tipText.BeginAnimation(OpacityProperty, animationOpacity);
                checkTime.Stop();

                checkTime2.Interval = TimeSpan.FromMilliseconds(1);
                checkTime2.Tick += CheckTime_Tick2;
                tipText.Visibility = Visibility.Visible;
                checkTime2.Start();
            }
        }

        private void CheckTime_Tick2(object sender, EventArgs e)//检测提示窗口消失状态
        {
            if (tipText.Opacity == 0.0)
            {
                tipText.Visibility = Visibility.Hidden;
                checkTime2.Stop();
            }
        }

        private void switchThings(int t1, int t2)
        {
            string textBoxName1 = "textBox" + t1.ToString();
            string checkBoxName1 = "checkBox" + t1.ToString();
            //string chooseButtonName1 = "label" + t1.ToString();

            string textBoxName2 = "textBox" + t2.ToString();
            string checkBoxName2 = "checkBox" + t2.ToString();
            //string chooseButtonName2 = "label" + t2.ToString();

            InfoTextBox textBox1 = textBoxColumn.FindName(textBoxName1) as InfoTextBox;
            DesignedCheckBox checkBox1 = checkBoxColumn.FindName(checkBoxName1) as DesignedCheckBox;
            //ChooseButton label1 = chooseButtonColumn.FindName(chooseButtonName1) as ChooseButton;

            InfoTextBox textBox2 = textBoxColumn.FindName(textBoxName2) as InfoTextBox;
            DesignedCheckBox checkBox2 = checkBoxColumn.FindName(checkBoxName2) as DesignedCheckBox;
            //ChooseButton label2 = chooseButtonColumn.FindName(chooseButtonName2) as ChooseButton;

            string s;
            bool state;
            double t;
            s = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = s;

            state = Convert.ToBoolean(checkBox1.IsChecked);
            checkBox1.IsChecked = checkBox2.IsChecked;
            checkBox2.IsChecked = state;

            t = times[t1];
            times[t1] = times[t2];
            times[t2] = t;
        }//交换两个thing之间的所有信息
         //如上为显示提示窗口的代码
        #endregion

        private string getNum(string s)
        {
            char[] chars = s.ToCharArray();
            string result = "";
            for (int i = 6; i < s.Length; i++)
            {
                if (chars[i] >= '0' && chars[i] <= '9')
                {
                    result = result + chars[i];
                }
            }
            return result;
        }//获取字符串中的数字

        #region 控制计时
        //如下一段为控制计时的代码
        public DispatcherTimer timer = new DispatcherTimer();
        public string starttime, nowtime;
        public bool isStop;//记录是否处于开始计时状态
        public double change;
        private void StartAndStop_Click(object sender, RoutedEventArgs e)
        {
            if (opting != null)
            {
                if (Convert.ToInt32(opting) <= (count - checkedCounts))
                {
                    if (!isStop)
                    {
                        StartAndStop.ToolTip = "暂停";
                        isStop = true;
                        StartAndStop.Background = imageStop;
                        starttime = DateTime.Now.ToLongTimeString();
                        timer.Tick += timer_Tick;
                        timer.Start();
                    }
                    else
                    {
                        StartAndStop.ToolTip = "在选择了任务之后开始计时吧！";
                        isStop = false;
                        StartAndStop.Background = imageStart;
                        starttime = nowtime;
                        times[Convert.ToInt32(opting)] = change;
                        timer.Stop();

                        timeDisplay("休息中", change);
                    }
                }
                else
                {
                    showTips("已完成的任务不能继续计时哦");
                }
            }
            else
            {
                showTips("请选择一项任务之后再开始计时");
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            nowtime = DateTime.Now.ToLongTimeString();
            dopass();
        }
        public void dopass()
        {
            if (starttime.Length == 7)
            {
                starttime = "0" + starttime;
            }
            if (nowtime.Length == 7)
            {
                nowtime = "0" + nowtime;
            }

            char[] starts = starttime.ToCharArray();
            char[] nows = nowtime.ToCharArray();
            int shour, sminute, ssecond;
            int nhour, nminute, nsecond;

            shour = (starts[0] - 48) * 10 + starts[1] - 48;
            sminute = (starts[3] - 48) * 10 + starts[4] - 48;
            ssecond = (starts[6] - 48) * 10 + starts[7] - 48;

            nhour = (nows[0] - 48) * 10 + nows[1] - 48;
            nminute = (nows[3] - 48) * 10 + nows[4] - 48;
            nsecond = (nows[6] - 48) * 10 + nows[7] - 48;
            int changehour, changeminute, changesecond;

            changehour = nhour - shour;
            changeminute = nminute - sminute;
            changesecond = nsecond - ssecond;
            if (changehour >= 0)
            {
                change = changehour * 60 * 60 + changeminute * 60 + changesecond + times[Convert.ToInt32(opting)];
            }
            else
            {
                change = (changehour + 24) * 60 * 60 + changeminute * 60 + changesecond + times[Convert.ToInt32(opting)];
            }

            timeDisplay(string.Empty, change);
        }  //时间显示刷新
           //如上一段为控制计时的代码
        #endregion

        #region 保存信息
        //如下一段为保存信息的代码
        public void Save()
        {
            string time = System.DateTime.Now.ToString();
            string timed = System.DateTime.Now.ToString("d");
            string textBoxName, checkBoxName;
            string save = "";
            string doing = "";
            string doingTime = "";

            if (isStop)//保证未暂停状态下时间依旧能保存
            {
                times[Convert.ToInt32(opting)] = change;
            }//保证未暂停状态下时间依旧能保存

            for (int i = 1; i <= count-checkedCounts; i++)
            {
                textBoxName = "textBox" + i.ToString();
                checkBoxName = "checkBox" + i.ToString();
                InfoTextBox textBox = textBoxColumn.FindName(textBoxName) as InfoTextBox;
                DesignedCheckBox checkBox = checkBoxColumn.FindName(checkBoxName) as DesignedCheckBox;

                doing = doing + textBox.Text + "\n";
                doingTime = doingTime + (times[i]).ToString() + "\n";
            }  //保存正在做的事
            File.WriteAllText(pathdoing, doing + time);
            File.WriteAllText(pathtimes, doingTime);
            string[] read;

            if (File.ReadAllText(pathdata) == string.Empty)
            {
                File.WriteAllText(pathdata, "AllData\tTime(min)");
            }

            read = File.ReadAllLines(pathdata);
            save = File.ReadAllText(pathdone);
            string[] t = save.Split('\n');
            int pos = read.Length - 1;
            int judge=0;
            if(save!=string.Empty)
            {
                for (int i = read.Length - 1; i >= 0; i--)  //获取前一天时间
                {
                    if (JudgeFormat(read[i]))
                    {
                        if (read[i] == t[1] && judge == 0)
                        {
                            judge++;
                            continue;
                        }
                        else if (judge == 1)
                        {
                            pos = i;
                        }
                        break;
                    }
                }  //获取前一天时间pos，默认pos为0

                save = DeleteTime(save);

                if (pos != read.Length - 1)
                {
                    File.WriteAllText(pathdata, string.Empty);//删除时间内所有行
                    for (int i = 0; i < read.Length - 1; i++)
                    {
                        File.AppendAllText(pathdata, read[i] + "\n");
                    }
                    File.AppendAllText(pathdata, save);//添加
                }
                else
                {
                    File.AppendAllText(pathdata, "\n" + "\n" + save);//添加
                }
                File.WriteAllText(pathdone, string.Empty);
            }
        }

        private string DeleteTime(string s)//删除时间，只保留待办，现更新为整理
        {
            if (s == string.Empty)
            {
                return string.Empty;
            }
            string[] all = s.Split('\n');
            string t = all[1];
            s = "";
            for (int i = 0; i < all.Length - 1; i=i+2)
            {
                if (all[i+1]!=t)
                {
                    s = s + t + "\n" + "\n";
                    t = all[i + 1];
                }
                s = s + all[i] + "\n";
            }
            s = s + t;
            return s;
        }

        private bool JudgeFormat(string format)//判断是否为时间格式
        {
            string[] s = format.Split('/');
            if (s.Length == 3 && s[0].Length == 4 && (s[1].Length >= 1 && s[1].Length <= 2)
                && (s[2].Length >= 1 && s[2].Length <= 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //如上一段为保存信息的代码
        #endregion

        #region 读取信息并初始化
        //如下一段为读取信息并初始化的代码
        private void Initialize()
        {
            timer.Interval = TimeSpan.FromSeconds(0.5);//初始化时间
            timer.Tick += timer_Tick;
            starttime = DateTime.Now.ToLongTimeString();
            count = 0;
            checkedCounts = 0;//初始化打勾的个数

            string[] read;
            string[] readTimes;
            string textBoxName;
            string chooseButtonName;

            read = File.ReadAllLines(pathdoing);
            readTimes = File.ReadAllLines(pathtimes);
            if (read.Length != 0)
            {
                count = read.Length - 1;
            }
            for (int i = 0; i < read.Length - 1; i++)
            {
                textBoxName = "textBox" + (i + 1).ToString();
                setTextBox(textBoxName);
                InfoTextBox textBox = textBoxColumn.FindName(textBoxName) as InfoTextBox;
                textBox.Text = read[i];

                string checkBoxName = "checkBox" + (i + 1).ToString();
                setCheckBox(checkBoxName);

                chooseButtonName = "chooseButton" + (i + 1).ToString();
                setChooseButton(chooseButtonName);

                times[i + 1] = Convert.ToDouble(readTimes[i]);
            }
        }

        private void JudgeFileExists(string path)//判断文件是否存在，若不存在则创建
        {
            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                fs.Close();
            }
        }
        //如上一段为读取信息并初始化的代码
        #endregion

        #region 各类按钮操作
        private void RandomChoose_Click(object sender, RoutedEventArgs e)//随机选择一项事件
        {
            if(!isStop)
            {
                if (count - checkedCounts + 1 > 1)
                {
                    Random random = new Random();
                    int r = random.Next(1, count - checkedCounts + 1);
                    var chooseButton = chooseButtonColumn.FindName("chooseButton" + r.ToString()) as ChooseButton;
                    if (opting != null)
                    {
                        if (r != Convert.ToInt32(opting))
                        {
                            Switchstate("chooseButton" + opting, "chooseButton" + r.ToString());
                            timeDisplay("已用时", times[Convert.ToInt32(opting)]);
                        }
                    }
                    else
                    {
                        chooseButton.IsChoose = true;
                        opting = r.ToString();
                        timeDisplay("已用时", times[Convert.ToInt32(opting)]);
                    }
                }
            }
            else
            {
                showTips("开始计时后不能随机哦");
            }
        }

        private void showData_Click(object sender, RoutedEventArgs e)//显示所有数据按钮操作
        {
            DataScroll.Visibility = Visibility.Visible;
            ExportData.Visibility = Visibility.Visible;
            var exitEllipse = MyGrid.FindName("ExitEllipse") as EllipseGeometry;
            exitEllipse.Center = Mouse.GetPosition(this);
            var animationEllipse = new DoubleAnimation()
            {
                From = 0,
                To = 600,
                Duration = new Duration(TimeSpan.FromSeconds(animationTime))
            };
            exitEllipse.BeginAnimation(EllipseGeometry.RadiusXProperty, animationEllipse);
            var animationOpacity = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(animationTime))
            };
            var target = MyGrid.FindName("ExitPath") as System.Windows.Shapes.Path;
            target.BeginAnimation(System.Windows.Shapes.Path.OpacityProperty, animationOpacity);
            target.MouseLeftButtonDown += ExitPath_MouseLeftButtonDown;
            DataScroll.BeginAnimation(OpacityProperty, animationOpacity);
            ExportData.BeginAnimation(OpacityProperty, animationOpacity);

            string s = File.ReadAllText(pathdata);
            string[] strings = File.ReadAllLines(pathdata);
            AllData.Height = strings.Length * AllData.LineHeight;
            AllData.Text = s;
        }

        private void ExportData_Click(object sender, RoutedEventArgs e)//导出数据按钮操作
        {
            string savepath = FolderPathFind.getFolderPath() + "\\data.txt";
            if (savepath != "\\data.txt")
            {
                JudgeFileExists(savepath);
                File.WriteAllText(savepath, AllData.Text);
                showTips("导出成功");
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)//完成事件和取消完成事件操作
        {
            DesignedCheckBox checkBox = sender as DesignedCheckBox;
            InfoTextBox textBox = textBoxColumn.FindName("textBox" + getNum(checkBox.Name)) as InfoTextBox;
            ChooseButton chooseButtonopt = chooseButtonColumn.FindName("chooseButton" + opting) as ChooseButton;
            int checkedBoxNum = Convert.ToInt32(getNum(checkBox.Name));
            string timed = System.DateTime.Now.ToString("d");
            if (checkBox.IsChecked == true)//完成任务
            {
                checkedCounts++;
                if (opting != null)//如果有操作项
                {
                    if (getNum(checkBox.Name) == opting)//选择项与操作项相同位置
                    {
                        if (isStop)//正在计时
                        {
                            isStop = false;
                            StartAndStop.Background = imageStart;
                            starttime = nowtime;
                            times[Convert.ToInt32(opting)] = change;
                            timer.Stop();
                        }
                        chooseButtonopt.IsChoose = false;

                        for (int i = Convert.ToInt32(opting); i <= count - 1; i++)
                        {
                            switchThings(i, i + 1);
                        }
                        opting = null;
                        time.Text = "空闲中";
                    }
                    else//选择项与操作项位置不同
                    {
                        if (!isStop)//未开始计时
                        {
                            chooseButtonopt.IsChoose = false;

                            for (int i = Convert.ToInt32(getNum(checkBox.Name)); i <= count - 1; i++)
                            {
                                switchThings(i, i + 1);
                            }
                            opting = null;
                            time.Text = "空闲中";
                        }
                        else//开始计时
                        {
                            int t, o;
                            t = Convert.ToInt32(getNum(checkBox.Name));//选择项
                            o = Convert.ToInt32(opting);//操作项
                            if (o >= 2 && t < o)//操作项位置位于第二位以上，选择项位置小于操作项
                            {
                                Switchstate("chooseButton" + opting, "chooseButton" + (o - 1).ToString());
                            }

                            for (int i = t; i <= count - 1; i++)
                            {
                                switchThings(i, i + 1);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = Convert.ToInt32(getNum(checkBox.Name)); i <= count - 1; i++)
                    {
                        switchThings(i, i + 1);
                    }
                }
                InfoTextBox tTextBox = textBoxColumn.FindName("textBox"+count.ToString()) as InfoTextBox;
                File.AppendAllText(pathdone, tTextBox.Text + "\t" + (times[count] / 60).ToString("f1") + "\n" + timed + "\n");
            }
            else
            {
                checkedCounts--;
                FindAndDeleteThing(textBox.Text,checkedBoxNum);
                switchThings(count - checkedCounts, Convert.ToInt32(getNum(checkBox.Name)));
            }
        }

        private void FindAndDeleteThing(string text, int checkedBoxNum)
        {
            string[] s = File.ReadAllLines(pathdone);
            string result = "";
            for(int i=0;i<s.Length; i=i+2)
            {
                string t = text + "\t" + (times[checkedBoxNum]/60).ToString("0.0");
                if (t == s[i])
                {
                    continue;
                }
                result += s[i] + "\n" + s[i + 1];
            }
            File.WriteAllText(pathdone, result);
        }
        #endregion

        #region 改变选择任务操作
        private void ChooseButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var chooseButton = sender as ChooseButton;
            if (!isStop)//暂停状态
            {
                if (opting != null)
                {
                    if (opting == getNum(chooseButton.Name))
                    {
                        chooseButton.IsChoose = false;
                        opting = null;
                        time.Text = "空闲中";
                    }
                    else
                    {
                        Switchstate("chooseButton" + opting, chooseButton.Name);
                        timeDisplay("已用时", times[Convert.ToInt32(opting)]);
                    }
                }
                else
                {
                    chooseButton.IsChoose = true;
                    opting = getNum(chooseButton.Name);
                    timeDisplay("已用时", times[Convert.ToInt32(opting)]);
                }
            }
            else //开始计时状态
            {
                if (opting != null)
                {
                    if (opting == getNum(chooseButton.Name))
                    {
                        StartAndStop.ToolTip = "在选择了任务之后开始计时吧！";
                        isStop = false;
                        StartAndStop.Background = imageStart;
                        starttime = nowtime;
                        times[Convert.ToInt32(opting)] = change;
                        timer.Stop();

                        chooseButton.IsChoose = false;
                        opting = null;
                        time.Text = "空闲中";
                    }
                    else
                    {
                        StartAndStop.ToolTip = "在选择了任务之后开始计时吧！";
                        isStop = false;
                        StartAndStop.Background = imageStart;
                        starttime = nowtime;
                        times[Convert.ToInt32(opting)] = change;
                        timer.Stop();

                        Switchstate("chooseButton" + opting, chooseButton.Name);
                        timeDisplay("已用时", times[Convert.ToInt32(opting)]);
                    }
                }
                 //showTips("开始计时后不能修改在做的事");
            }

        }

        private void InfoTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)//按下Tab键后的操作
        {
            InfoTextBox infoTextBox = sender as InfoTextBox;
            if(e.Key == Key.Tab)
            {
                if (getNum(infoTextBox.Name) == (count-checkedCounts).ToString())
                {
                    e.Handled = true;
                    AddThing.RaiseEvent(new RoutedEventArgs(ExitButton.ClickEvent));
                    //string t = "textBox" + (count - checkedCounts).ToString();
                    //InfoTextBox infoTextBoxFocus = textBoxColumn.FindName(t) as InfoTextBox;
                    //infoTextBoxFocus.Focus();
                }
            }
            if(e.Key == Key.Enter && !isStop)
            {
                string t=getNum(infoTextBox.Name);
                ChooseButton chooseButton = chooseButtonColumn.FindName("chooseButton" + t) as ChooseButton;
                if(opting == null)
                {
                    chooseButton.IsChoose = true;
                    opting = t;
                }
                else
                {
                    Switchstate("chooseButton" + opting, "chooseButton" + t);
                }
                timeDisplay("已用时", times[Convert.ToInt32(opting)]);
                StartAndStop.Focus();
            }
        }

        private void Switchstate(string chooseButtonFrom, string chooseButtonTo)
        {
            var chooseFrom = chooseButtonColumn.FindName(chooseButtonFrom) as ChooseButton;
            var chooseTo = chooseButtonColumn.FindName(chooseButtonTo) as ChooseButton;

            chooseFrom.IsChoose = false;
            chooseTo.IsChoose = true;

            opting = getNum(chooseTo.Name);
        }
        #endregion

    }
    public partial class App : Application
    {
        private static System.Threading.Mutex mutex;
        protected override void OnStartup(StartupEventArgs e)
        {
            mutex = new System.Threading.Mutex(true, "OnlyRun_CRNS");
            if (mutex.WaitOne(0, false))
            {
                base.OnStartup(e);
            }
            else
            {
                this.Shutdown();
            }
        }
    }
}
