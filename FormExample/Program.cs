using System;
using System.Windows.Forms;

namespace FormExample
{
    public class Program : Form1
    {

        public static SlideSprite Dov;


        protected override void OnKeyDown(KeyEventArgs e)
        {
            //base.OnKeyDown(e);
            //Console.WriteLine("asdffasdf");
            if (e.KeyCode == Keys.Left) Dov.TargetX -= 30;
            if (e.KeyCode == Keys.Right) Dov.TargetX += 30;
            if (e.KeyCode == Keys.Up) Dov.TargetY -= 30;
            if (e.KeyCode == Keys.Down) Dov.TargetY += 30;
            if (e.KeyCode == Keys.M) jukebox.PlayLooping();
            if (e.KeyCode == Keys.N) jukebox.Stop();
            if (e.KeyCode == Keys.R) Dov.Rotation += 30;
            if (e.KeyCode == Keys.U) Dov.Velocity += 5;
            if (e.KeyCode == Keys.I)
            {
                if (Dov.Velocity <= 0)
                    Dov.Velocity = 0;
                else Dov.Velocity -= 5;
            }
            if (e.KeyCode == Keys.H)
            {
                Dov.TargetX = 50;
                Dov.TargetY = 50;
            }

        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Dov = new SlideSprite(Properties.Resources.Dov);
            Dov.TargetX = 100;
            Dov.TargetY = 100;
            Dov.Velocity = 5;
            Program.parent.add(Dov);
            Application.Run(new Program());
        }
    }
}