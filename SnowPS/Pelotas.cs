using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Pelotas.Properties;
using System.Drawing.Imaging;

namespace Pelotas
{
    public partial class Pelotas : Form
    {
        //public PictureBox PCT_CANVAS;
        public List<Particula> balls;
        static Bitmap bmp;
        static Graphics g;
        static Random rand = new Random();
        static float deltaTime;
        private float elapsedTime = 0f;
        //Image particleImage = Image.FromFile("C:\\Users\\erizo\\Downloads\\vecteezy_realistic-digital-lens-flare-light-effect_11024295_460.png");
        Image particleImage = Resources.kirby_star_Right;
        //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        public float x;
        public float y;
        

        public int alpha = 255;
        
        

        
        public Pelotas()
        {
            InitializeComponent();
            
        }

        public void Init()
        {
            Emisor emitter = new Emisor(rand, new Size(800, 600), 100, this);
            if (PCT_CANVAS.Width == 0)
                return;

            balls       = new List<Particula>();
            bmp         = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g           = Graphics.FromImage(bmp);
            deltaTime   = 1;
            PCT_CANVAS.Image = bmp;
            emitter.GenParticles();
            //Nube();
            

        }
        public void Nube()
        {
            Brush brush = Brushes.White;
            int size = 50;

            // Draw a series of overlapping ellipses in a roughly circular shape


        }
        private void Pelotas_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Pelotas_SizeChanged(object sender, EventArgs e)
        {
            Init();
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Black);


            for(int i = balls.Count - 1; i >= 0; i--)
            {

                Particula P;
                P = balls[i];
                balls[i].Update(deltaTime, balls);
            }
            

            
            Particula p;
            for (int b = 0; b < balls.Count; b++)//PINTAMOS EN SECUENCIA
            {
                p = balls[b];

                //DRAWN PARTICLES
                // if (alpha < 0) alpha = 0;
                // Create a new Color object with the modified alpha value
                // Color newColor = Color.FromArgb(alpha, p.c.R, p.c.G, p.c.B);
                g.FillEllipse(new SolidBrush(p.c), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
                
                //IMAGE PARTICLES
                
                

               
                //g.DrawImage(particleImage, p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
                //g.DrawImage(particleImage, new Rectangle((int)p.x - (int)p.radio, (int)p.y - (int)p.radio, 30, 30), p.x - p.radio, p.y - p.radio, width, height, GraphicsUnit.Pixel, ia);
                //alpha = 255;
               
                //particleImage.MakeTransparent(color);
                //particleImage.M
            }

            PCT_CANVAS.Invalidate();
            deltaTime += .1f;
            elapsedTime += deltaTime;

        }

        public void Drawparticle()
        {
            for (int b = 0; b < 150; b++)
                balls.Add(new Particula(rand, PCT_CANVAS.Size, b, this.x, this.y));
        }
    }
}
