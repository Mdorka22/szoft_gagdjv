namespace Veletlenek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {


                Button b = new Button();
                Controls.Add(b);
                Random rnd = new Random();
                b.Left = rnd.Next(ClientRectangle.Width-40);
                b.Top = rnd.Next(ClientRectangle.Height-40);
                b.Height = rnd.Next(40);
                b.Width = rnd.Next(40);
                b.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            }
        }
    }
}