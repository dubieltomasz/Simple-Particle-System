using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Particle_System
{
    internal class Particle
    {
        public float x, y, d;
        int mass;

        public Particle(float x, float y, float d)
        {
            this.x = x;
            this.y = y;
            this.d = d;
        }
    }
}
