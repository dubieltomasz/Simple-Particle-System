using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Particle_System
{
    public partial class Form1 : Form
    {
        List<Particle> particles = new List<Particle>();
        Bitmap bmp;
        Graphics g, buffer;

        public Form1()
        {
            InitializeComponent();

            g = panel.CreateGraphics();
            bmp = new Bitmap(panel.Width, panel.Height);
            buffer = Graphics.FromImage(bmp);
        }

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            particles.Add(new Particle(e.Location.X, e.Location.Y, 20.0f));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buffer.Clear(Color.White);

            foreach(Particle particle in particles)
            {
                buffer.FillEllipse(Brushes.Red, particle.x - particle.d/2, particle.y - particle.d/2, particle.d, particle.d);
                buffer.DrawEllipse(Pens.Black, particle.x - particle.d/2, particle.y - particle.d/2, particle.d, particle.d);
            }

            g.DrawImage(bmp, 0, 0);
        }
    }
}
