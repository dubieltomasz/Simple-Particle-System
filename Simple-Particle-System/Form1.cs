﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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
            Random rand = new Random();
            float d = (float)(20 + (50-20) * rand.NextDouble());
            float vx = (float)(-1 + (1+1) * rand.NextDouble());
            float vy = (float)(-1 + (1+1) * rand.NextDouble());

            particles.Add(new Particle(e.Location.X, e.Location.Y, d, vx, vy, 0.0f, 0.5f));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buffer.Clear(Color.White);

            foreach(Particle particle in particles)
            {
                buffer.FillEllipse(Brushes.Red, particle.posX - particle.d/2, particle.posY - particle.d/2, particle.d, particle.d);
                buffer.DrawEllipse(Pens.Black, particle.posX - particle.d/2, particle.posY - particle.d/2, particle.d, particle.d);
                
                particle.calculateCollisions(panel.Height, panel.Width, particles);
                particle.calculateNextPosition();
            }

            g.DrawImage(bmp, 0, 0);
        }
    }
}
