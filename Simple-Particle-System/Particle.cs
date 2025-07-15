using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Particle_System
{
    internal class Particle
    {
        public float posX, posY, d;
        public float velocityX, velocityY;
        public float accelerationX, accelerationY;
        public float mass;
        int e = 1;

        public Particle(float x, float y, float d, float vx, float vy, float ax, float ay)
        {
            posX = x;
            posY = y;
            this.d = d;
            velocityX = vx;
            velocityY = vy;
            accelerationX = ax;
            accelerationY = ay;
            mass = d / 5;
        }

        public void calculateNextPosition()
        {
            velocityX += accelerationX;
            velocityY += accelerationY;
            posX += velocityX;
            posY += velocityY;
        }

        public void calculateCollisions(int height, int width, List<Particle> particles)
        {
            if (this.posX + this.d / 2 > width)
            {
                this.posX = width - this.d / 2;
                this.velocityX *= -1;
            }

            if (this.posX - this.d / 2 < 0)
            {
                this.posX = this.d / 2;
                this.velocityX *= -1;
            }

            if (this.posY + this.d / 2 > height)
            {
                this.posY = height - this.d / 2;
                this.velocityY *= -1;
            }

            if (this.posY - this.d / 2 < 0)
            {
                this.posY = this.d / 2;
                this.velocityY *= -1;
            }

            foreach (Particle particle in particles)
            {
                if (this == particle) continue;

                float actualDistance = (float)Math.Sqrt(Math.Pow(particle.posX - this.posX, 2) + Math.Pow(particle.posY - this.posY, 2));
                float minimumDistance = this.d / 2 + particle.d / 2;

                if (actualDistance <= minimumDistance)
                {
                    float normalX = (particle.posX - this.posX) / actualDistance;
                    float normalY = (particle.posY - this.posY) / actualDistance;
                    
                    float relativeX = this.velocityX - particle.velocityX;
                    float relativeY = this.velocityY - particle.velocityY;

                    float relativeNormal = relativeX * normalX + relativeY * normalY;

                    float impulse = -(1 + e) * relativeNormal / (1.0f / this.mass + 1.0f / particle.mass);
                    float impulseX = normalX * impulse;
                    float impulseY = normalY * impulse;

                    this.velocityX += impulseX / this.mass;
                    this.velocityY += impulseY / this.mass;
                    particle.velocityX -= impulseX / particle.mass;
                    particle.velocityY -= impulseY / particle.mass;

                    this.posX -= normalX * (minimumDistance - actualDistance);
                    this.posY -= normalY * (minimumDistance - actualDistance);
                    particle.posX += normalX * (minimumDistance - actualDistance);
                    particle.posY += normalY * (minimumDistance - actualDistance);
                }
            }
        }
    }
}
