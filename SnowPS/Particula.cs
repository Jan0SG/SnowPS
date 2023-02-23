using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Pelotas
{
    public class Particula
    {
        int index;
        Size space;
        public Color c;
        // Variables de posición
        public float x;
        public float y;

        // Variables de velocidad
        public float vx;
        public float vy;

        // Variable de radio
        public float radio;
        public float TimeofLife;
        public float lifecounter;
        static Random rand = new Random();
        Pelotas parti;


        // Constructor 
        public Particula(Random rand,Size size, int index, float x, float y)
        {
            
            this.radio  = rand.Next(5, 15);
            this.x = rand.Next(210, 235);
            this.x++;
            this.y      = 165;            
            c           = Color.FromArgb(rand.Next(200, 255), rand.Next(250, 255), rand.Next(235, 255), rand.Next(240, 255));
            // Velocidades iniciales
            this.vx = rand.Next(1, 3);
            this.vy = rand.Next(1, 10);

            this.TimeofLife = rand.Next(200, 440);
            //this.lifecounter = this.TimeofLife;

            this.index = index;
            space = size;
        }

        // Método para actualizar la posición de la pelota en función de su velocidad
        public void Update(float deltaTime, List<Particula> balls)
        {
            //Emisor emitter = new Emisor(rand, new Size(800, 600), 100, parti);

            if (this.TimeofLife <= 0)
            {
                balls.Remove(this);
                
                if (balls.Count <= 100)
                {
                    
                    balls.Add(new Particula(rand, space, balls.Count, this.x, this.y));
                }

            }


            if ((x - radio) <= 0 || (x + radio) >= space.Width)
            {
                if (x - radio <= 0)
                    x = radio + 3;
                else
                    x = space.Width - radio-3;
                    
                vx *= -.50f;
                vy *= .75f;
                
            }

            if ((y - radio) <= 0 || (y + radio) >= space.Height)
            {
                if (y - radio<=  0)
                    y = radio + 3;
                else
                    y = space.Height - radio-3;

                vx *=  .75f;
                vy *= -.55f;
                
            }

            this.x += this.vx + 5f; //* deltaTime;
            this.y += this.vy + 3; //* deltaTime;

            
            
            int alpha = (int)Math.Min(255, 255 * this.TimeofLife / 160);
            if (alpha <= 0) alpha = 0;
            this.c = Color.FromArgb(alpha, c.R, c.G, c.B);
            // Si el tiempo de vida llega a cero, remover la pelota de la lista

           

            this.TimeofLife -= 5;
           

        }



        

    }

}
