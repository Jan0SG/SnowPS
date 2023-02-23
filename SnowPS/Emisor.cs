using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Pelotas
{
    public class Emisor
    {
        //Pelota pelotitas = new Pelota();
        private Random rand;
        public List<Particula> particles;
        private Size space;
        public Graphics g;
        private int maxParticles;
        private float emissionRate;
        Pelotas parti;
        Bitmap bmp;

         
        
        public float x=500;
        public float y=500;

        public Emisor(Random rand, Size space, int maxParticles, Pelotas parti)
        {
            
            this.rand = rand;
            this.particles = new List<Particula>();
            this.space = space;
            this.maxParticles = maxParticles;
            this.x = rand.Next(1, 1300);
            this.x++;
            this.y = 0;
            this.parti = parti;

        }



        public void GenParticles()
        {
            parti.Drawparticle();
        }

        public void AddParticles()
        {
            particles.Add(new Particula(rand, space, particles.Count, x, y));
        }
        public void Update(float deltaTime)
        {
            if (particles.Count < maxParticles)
            {
                
                //add
                //erase
                //origin of particles

            }
        }


    }
}
