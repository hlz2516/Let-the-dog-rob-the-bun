using System.Diagnostics;

namespace 放狗抢包子
{
    /// <summary>
    /// 该示例模拟：
    /// 点击“开始抢包子”后，三只狗（其实是线程）开始争抢同一笼里的包子（共享变量），
    /// 狗的逻辑：只要笼子里还有包子，就争抢。
    /// 可以通过“开始放包子”按钮来添加笼里的包子数量。
    /// </summary>
    public partial class Form3_NoLimitBun : Form
    {
        private int bunNum;
        private static readonly object lockobj = new object();
        private static bool IsClosing = false;
        private Thread PushBuns;
        private bool continuePush;

        public int BunNum
        {
            get { return bunNum; }
            set
            {
                bunNum = value;
                lbl_bunNum.Text = bunNum.ToString();
            }
        }

        public Form3_NoLimitBun()
        {
            InitializeComponent();
            BunNum = 200;
            PushBuns = new Thread(() =>
            {
                while (true)
                {
                    //每隔一秒钟放一个包子
                    if (continuePush)
                    {
                        this?.Invoke(new Action(() => 
                        {
                            BunNum++;
                        }));
                    }
                    Thread.Sleep(100);
                }
            });
            PushBuns.IsBackground = true;
            PushBuns.Start();
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
                                Thread.Sleep(200);
                                if (IsClosing)
                                {
                                    break;
                                }
                                continue;
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

                            Thread.Sleep(200);
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
            //检查线程是否初始化
            if (threads[0] == null)
            {
                return;
            }

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

        private void button2_Click(object sender, EventArgs e)
        {
            continuePush = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            continuePush = false;
        }
    }
}