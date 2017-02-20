using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace FormExample
{
    public class Dovahkiin : Sprite
    {
        private Image image;
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
        
        public override void act()
        {
            base.act();
            this.X++;
            this.Y++;
        }

        public override void paint(Graphics g)
        {
            g.DrawImage(image, this.X, this.Y);
        }
    }
}
