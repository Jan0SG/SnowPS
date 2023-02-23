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
using System.Runtime.CompilerServices;

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
        
        Image particleImage = Resources.clipart2650764;
        
        public float x;
        public float y;
        private Bitmap backgroundImage;
        private Bitmap emisorImage;
        



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
            backgroundImage = new Bitmap(Resources.Ice_kingdom_sunset);
            emisorImage = new Bitmap(Resources.Ice_King);
            //Nube();
            

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
            

            g.DrawImage(backgroundImage, 0, 0, PCT_CANVAS.Width, PCT_CANVAS.Height);
            g.DrawImage(emisorImage, 0, 0, 250, 250);
            Particula p;
            for (int b = 0; b < balls.Count; b++)//PINTAMOS EN SECUENCIA
            {
                p = balls[b];

                //DRAWN PARTICLES

                g.FillEllipse(new SolidBrush(p.c), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
                

                //IMAGE PARTICLES

                //g.DrawImage(particleImage, p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);

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
