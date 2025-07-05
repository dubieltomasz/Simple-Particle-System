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

            this.Width = 900;
            this.Height = 510;

            g = panel.CreateGraphics();
            bmp = new Bitmap(panel.Width, panel.Height);
            buffer = Graphics.FromImage(bmp);
        }

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            Random rnd = new Random();
            particles.Add(new Particle(e.Location.X, e.Location.Y, 20.0f, 1.0f, 0.0f, 0.0f, 1.0f));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buffer.Clear(Color.White);

            foreach(Particle particle in particles)
            {
                buffer.FillEllipse(Brushes.Red, particle.posX - particle.d/2, particle.posY - particle.d/2, particle.d, particle.d);
                buffer.DrawEllipse(Pens.Black, particle.posX - particle.d/2, particle.posY - particle.d/2, particle.d, particle.d);
                particle.calculateNextPosition();

                if (particle.posX + particle.d / 2 > panel.Width)
                {
                    particle.posX = panel.Width - particle.d / 2;
                    particle.velocityX *= -0.75f;
                }

                if (particle.posX - particle.d / 2 < 0)
                {
                    particle.posX = particle.d / 2;
                    particle.velocityX *= -0.75f;
                }

                if (particle.posY + particle.d / 2 > panel.Height)
                {
                    particle.posY = panel.Height - particle.d / 2;
                    particle.velocityY *= -0.75f;
                }

                if (particle.posY - particle.d / 2 < 0)
                {
                    particle.posY = particle.d / 2;
                    particle.velocityY *= -0.75f;
                }
            }

            g.DrawImage(bmp, 0, 0);
        }
    }
}
