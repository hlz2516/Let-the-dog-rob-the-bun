using System.Diagnostics;

namespace 放狗抢包子
{
    public partial class Form1_NoLock : Form
    {
        private static readonly object lockobj = new object();
        private int bunNum;
        //包子总数
        public int BunNum
        {
            get { return bunNum; }
            set
            {
                bunNum = value;
                lbl_bunNum.Text = bunNum.ToString();
            }
        }

        public Form1_NoLock()
        {
            InitializeComponent();
            BunNum = 200;
        }

        private Thread[] threads = new Thread[3];
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                //一条线程代表一条狗
                threads[i] = new Thread((obj) =>
                {
                    string name = Thread.CurrentThread.Name;
                    bool isRunning = true;
                    while (isRunning)
                    {
                        try
                        {
                            if (BunNum <= 0)
                            {
                                break;
                            }
                            this.Invoke(new Action(() =>
                            {
                                BunNum--;
                                var dog = Controls["dog" + name] as Dog;
                                dog.BunNum++;
                            }));
                            //System.Diagnostics.Debug.WriteLine($"Thread[{name}]:current bun num:{BunNum}");
                            Thread.Sleep(100);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                        }
                    }
                });
                threads[i].Name = (i + 1).ToString();
                threads[i].Start(lockobj);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}