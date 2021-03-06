﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace FormExample
{
    public partial class Form1 : Form
    {
        public static Form form;
        public static Thread rthread;
        public static Thread uthread;

        public static Sprite parent = new Sprite();
        public static int s = 100;
        public static int fps = 30;
        public static double running_fps = 30.0;
        public static Font font = new Font("Ubuntu", 12);
        public static int counter = 1;
        public static SoundPlayer jukebox = new SoundPlayer(Properties.Resources.jukebox);
        
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            form = this;
            rthread = new Thread(new ThreadStart(render));
            uthread = new Thread(new ThreadStart(update));
            rthread.Start();
            uthread.Start();

        }



        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            rthread.Abort();
            uthread.Abort();
        }
        
        

        protected override void OnPaint(PaintEventArgs e)
        {
            parent.act();
            parent.render(e.Graphics);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static void update()
        {
            DateTime last = DateTime.Now;
            DateTime now = last;
            TimeSpan FrameTime = new TimeSpan(10000000 / fps);
            while(true)
            {
                DateTime temp = DateTime.Now;
                now = temp;
                TimeSpan diff = now - last;
                if (diff.TotalMilliseconds < FrameTime.TotalMilliseconds)
                    Thread.Sleep((FrameTime - diff).Milliseconds);
                last = DateTime.Now;
                parent.update();
            }
        }

        public static void render()
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
