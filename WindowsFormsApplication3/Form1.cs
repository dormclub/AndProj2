using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Deployment.Application;
using System.Web;
using System.IO;
using System.Collections.Specialized; 
   
using System.Runtime.InteropServices;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public readonly IntPtr HFILE_ERROR = new IntPtr(-1);

        private NameValueCollection GetQueryStringParameters()
        {
            NameValueCollection col = new NameValueCollection();
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                string queryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
                col = HttpUtility.ParseQueryString(queryString);
            }
            return col;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
      /*    NameValueCollection _oNameVal=  GetQueryStringParameters();
          string[] _lstStr=  _oNameVal.GetValues(0);
          string _strVal = string.Empty;
          foreach (string _str in _lstStr)
          {
              _strVal = _str + "\r\n";

          }

          textBox1.Text = _strVal;*/
        }

 
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string vFileName = @"C:\Workspace\1111EA9CDD4421DA52896836D101B7A2\A3505827710002014060076\Gather\Source\Photo\806501A314EB489D9F7221D1E59A005F.jpg";
            if (!File.Exists(vFileName))
            {
                MessageBox.Show("文件都不存在!");
                return;
            }
            IntPtr vHandle = _lopen(vFileName, OF_READWRITE | OF_SHARE_DENY_NONE);
            if (vHandle == HFILE_ERROR)
            {
                MessageBox.Show("文件被占用！");
                return;
            }
            CloseHandle(vHandle);
            MessageBox.Show("没有被占用！");
        }
    }
}
