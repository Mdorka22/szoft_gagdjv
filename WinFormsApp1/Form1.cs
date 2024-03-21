using kigyosjatek;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int fej_x = 100;
        int fej_y = 100;
        int irány_x = 1;
        int irány_y = 0;
        int lépésszám = 0;
        int hossz = 5;

        private void timer1_Tick(object sender, EventArgs e)
        {
            lépésszám++;
            fej_x += irány_x * KígyóElem.Méret;
            fej_y += irány_y * KígyóElem.Méret;



            foreach (object item in Controls)
            {   if (item is KígyóElem)
                {
                    KígyóElem k = (KígyóElem)item;
                    if (k.Top == fej_y && k.Left == fej_x)
                    {
                        timer1.Enabled = false;
                        return;
                        
                    }
                }
            }


            KígyóElem ke = new KígyóElem();
            ke.Top = fej_y;
            ke.Left = fej_x;
            kígyó.Add(ke);
            Controls.Add(ke);
            Random rnd = new Random();
            if (lépésszám % 5 == 0)
            {

                Alma alma = new Alma();
                alma.Top = rnd.Next(0, ClientRectangle.Width/Alma.Méret)*Alma.Méret;
                alma.Left = rnd.Next(0, ClientRectangle.Height / Alma.Méret) * Alma.Méret;
                Controls.Add(alma);
            }

            
            if (kígyó.Count>hossz)
            {
                KígyóElem levágandó = kígyó[0];
                kígyó.RemoveAt(0);
                Controls.Remove(levágandó);
            }
            if (lépésszám % 2 == 0)
            {
                ke.BackColor = Color.LightSeaGreen;
            }

        }

        List<KígyóElem> kígyó = new List<KígyóElem>();
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                irány_y = -1;
                irány_x = 0;
            }
            if (e.KeyCode == Keys.Down)
            {
                irány_y = 1;
                irány_x = 0;
            }
            if (e.KeyCode == Keys.Left)
            {
                irány_y = 0;
                irány_x = -1;
            }
            if (e.KeyCode == Keys.Right)
            {
                irány_y = 0;
                irány_x = 1;
            }
        }
    }
}