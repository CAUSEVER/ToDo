using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoThingsRight
{
    internal class FolderPathFind
    {
        public static string getFolderPath()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();        //这个方法可以显示文件夹选择对话框
            string directoryPath = folderBrowserDialog.SelectedPath;    //获取选择的文件夹的全路径名
            return directoryPath;
        }
    }
}
