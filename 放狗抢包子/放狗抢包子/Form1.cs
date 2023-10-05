using System.Diagnostics;

namespace 放狗抢包子
{
    public partial class Form1 : Form
    {
        private int bunNum;
        private static readonly object lockobj = new object();
        private static bool IsClosing = false;

        public int BunNum
        {
            get { return bunNum; }
            set
            {
                bunNum = value;
                lbl_bunNum.Text = bunNum.ToString();
            }
        }

        public Form1()
        {
            InitializeComponent();
            BunNum = 200;
        }

        private Thread[] threads = new Thread[3];
        private void button1_Click(object sender, EventArgs e)
        {
            //开启三个线程，每个线程要操作BunNum时其他线程不能操作BunNum
            for (int i = 0; i < 3; i++)
            {
                //一条线程代表一条狗，其下标i正好是对应的
                threads[i] = new Thread((obj) =>
                {
                    bool isRunning = true;
                    while (isRunning)
                    {
                        string name = Thread.CurrentThread.Name;
                        //lock (obj)
                        //{
                        try
                        {
                            Monitor.Enter(obj);
                            if (BunNum <= 0)
                            {
                                Monitor.Exit(obj);
                                break;
                            }
                            this.Invoke(new Action(() =>
                            {
                                BunNum--;
                                var dog = Controls["dog" + name] as Dog;
                                dog.BunNum++;
                            }));
                            //System.Diagnostics.Debug.WriteLine($"Thread[{name}]:current bun num:{BunNum}");
                            //}
                            Monitor.Exit(obj);

                            if (IsClosing)
                            {
                                break;
                            }

                            Thread.Sleep(100);
                        }
                        catch (Exception)
                        {
                            if (Monitor.IsEntered(obj))
                            {
                                Monitor.Exit(obj);
                            }
                            isRunning = false;
                        }
                    }
                });
                threads[i].Name = (i + 1).ToString();
                threads[i].Start(lockobj);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            while (true)
            {
                Application.DoEvents();
                IsClosing = true;
                bool allDone = true;
                foreach (var t in threads)
                {
                    if ((t.ThreadState & System.Threading.ThreadState.Stopped) != System.Threading.ThreadState.Stopped)
                    {
                        allDone = false;
                        break;
                    }
                }

                if (allDone)
                {
                    break;
                }

                Thread.Sleep(30);
            }
        }
    }
}