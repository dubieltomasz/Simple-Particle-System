using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Particle_System
{
    internal class Particle
    {
        public float posX, posY, d;
        public float velocityX, velocityY;
        public float accelerationX, accelerationY;
        int mass;

        public Particle(float x, float y, float d, float vx, float vy, float ax, float ay)
        {
            posX = x;
            posY = y;
            this.d = d;
            velocityX = vx;
            velocityY = vy;
            accelerationX = ax;
            accelerationY = ay;
        }

        public void calculateNextPosition()
        {
            velocityX += accelerationX;
            velocityY += accelerationY;
            posX += velocityX;
            posY += velocityY;
        }
    }
}
