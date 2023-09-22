using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 放狗抢包子
{
    public partial class Dog : UserControl
    {
        private int bunNum;

        public int BunNum
        {
            get { return bunNum; }
            set
            {
                bunNum = value;
                lbl_bunNum.Text = bunNum.ToString();
            }
        }

        public Image DogImage
        {
            set { pictureBox1.Image = value; }
            get { return pictureBox1.Image; }
        }

        public Dog()
        {
            InitializeComponent();
        }
    }
}
