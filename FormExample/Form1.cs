using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;


namespace FormExample
{
    public partial class Form1 : Form
    {
        public static Form form;
        public static Thread thread;

        public static Dovahkiin hero = new Dovahkiin();
        public static int s = 100;
        public static int fps = 30;
        public static double running_fps = 30.0;
        public static Font font = new Font("Ubuntu", 12);
        public static int counter = 1;
        
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            hero.Image = Properties.Resources.Dov;
            DoubleBuffered = true;
            form = this;
            thread = new Thread(new ThreadStart(Update));
            thread.Start();

        }



        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            thread.Abort();
        }
        
        

        protected override void OnPaint(PaintEventArgs e)
        {
            hero.act();
            hero.render(e.Graphics);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static void Update()
        {
            DateTime last = DateTime.Now;
            DateTime now = last;
            TimeSpan frameTime = new TimeSpan(10000000 / fps);
            while(true)
            {
                DateTime temp = DateTime.Now;
                running_fps = .9 * running_fps + .1 * 1000.0 / (temp - now).TotalMilliseconds;
                Console.WriteLine(running_fps);
                now = temp;
                TimeSpan diff = now - last;
                if (diff.TotalMilliseconds < frameTime.TotalMilliseconds)
                    Thread.Sleep((frameTime - diff).Milliseconds);
                last = DateTime.Now;
                form.Invoke(new MethodInvoker(form.Refresh));
            }
        }
    }
    
}
