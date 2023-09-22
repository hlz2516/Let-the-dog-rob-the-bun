namespace 放狗抢包子
{
    public partial class Form1 : Form
    {
        private int bunNum;
        private static readonly object lockobj = new object();

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
                threads[i] = new Thread((num) =>
                {
                    while (BunNum > 0)
                    {
                        this.Invoke(new Action(() =>
                        {
                            BunNum--;
                            var dog = Controls["dog" + num] as Dog;
                            if (dog != null)
                            {
                                dog.BunNum++;
                            }
                        }));

                        Thread.Sleep(20);
                    }
                });
                threads[i].Start(i+1);
            }
        }

    }
}