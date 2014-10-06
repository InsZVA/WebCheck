using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string strId = textBox1.Text;//用户名

            string strPassword = textBox2.Text;//密码
            //string strsubmit = "YES";
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "user=" + strId;
            postData += ("&password=" + strPassword);
            //postData += ("&Accept=" + strsubmit);
            byte[] data = encoding.GetBytes(postData);
            // Prepare web request...
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.inszva.tk/loginsys/test.php");
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            // Get response
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            //Response.Write(content); 
            if (content.Equals("-1")) MessageBox.Show("密码错误！");
            if (content.Equals("0")) MessageBox.Show("用户名错误！");
            if (content.Equals("1")) MessageBox.Show("登陆成功，开始计费，欢迎使用本系统！");
        }
    }
}
