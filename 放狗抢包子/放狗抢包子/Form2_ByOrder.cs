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
    /// <summary>
    /// 该示例模拟：
    /// 三只体型不同的狗子抢包子，点击“开始抢包子”后，由体型较大的哈士奇先抢200个，
    /// 等哈士奇抢完后，再是体型中等的柯基抢100个，最后是体型小的雪纳瑞抢50个，线程结束。
    /// 
    /// 思路一：Task.Wait（这里只实现该思路）
    /// 思路二：Thread.join
    /// </summary>
    public partial class Form2_ByOrder : Form
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

        public Form2_ByOrder()
        {
            InitializeComponent();
            BunNum = 351;
        }

        private Task[] tasks = new Task[3];
        private void button1_Click(object sender, EventArgs e)
        {
            tasks[0] = new Task(() =>
            {
                int target = 200;
                int bunGot = 0;
                while (BunNum > 0 && bunGot < target)
                {
                    this.Invoke(new Action(() =>
                    {
                        BunNum--;
                        bunGot++;
                        dog1.BunNum = bunGot;
                    }));
                    Thread.Sleep(100);
                }
            });

            tasks[1] = new Task(() =>
            {
                tasks[0].Wait();
                int target = 100;
                int bunGot = 0;
                while (BunNum > 0 && bunGot < target)
                {
                    this.Invoke(new Action(() =>
                    {
                        BunNum--;
                        bunGot++;
                        dog2.BunNum = bunGot;
                    }));
                    Thread.Sleep(100);
                }
            });

            tasks[2] = new Task(() =>
            {
                tasks[1].Wait();
                int target = 50;
                int bunGot = 0;
                while (BunNum > 0 && bunGot < target)
                {
                    this.Invoke(new Action(() =>
                    {
                        BunNum--;
                        bunGot++;
                        dog3.BunNum = bunGot;
                    }));
                    Thread.Sleep(100);
                }
            });

            tasks[0].Start();
            tasks[1].Start();
            tasks[2].Start();
        }
    }
}
