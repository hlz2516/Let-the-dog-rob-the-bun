namespace 放狗抢包子
{
    public partial class Form1 : Form
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

        public Form1()
        {
            InitializeComponent();
            BunNum = 100;
        }
    }
}