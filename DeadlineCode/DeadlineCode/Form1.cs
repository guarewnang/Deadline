using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using metronButton = MetroFramework.Controls.MetroButton;

namespace DeadlineCode
{
    public partial class 限期激活码转换工具 : MetroFramework.Forms.MetroForm
    {
        public 限期激活码转换工具()
        {
            InitializeComponent();
        }

        private void btn_convert_Click(object sender, EventArgs e)
        {
            string deadlineyear = Convert.ToInt16(numd_deadlineYear.Value-2000).ToString("D2");
            string deadlinemonth = Convert.ToInt16(numd_deadlineMonth.Value).ToString("D2");
            string deadlinecode = deadlineyear + deadlinemonth + deadlineyear + deadlinemonth;
            byte[] ascii = new byte[8];
            ascii = Encoding.Default.GetBytes(deadlinecode);
            int [] convertcode=new int[8];
            NumericUpDown n=new NumericUpDown();            
            for (int i = 0; i < 8; i++)
            {               
                convertcode[i] = Convert.ToInt16(((NumericUpDown)(this.Controls.Find("numd_code"+(i+1).ToString(),false)[0])).Value);
               ((TextBox)(this.Controls.Find("txb_deadline" + (i+1).ToString(), false)[0])).Text = (Convert.ToInt16(ascii[i]) + convertcode[i]).ToString();
            }
            
        }




    }
}
