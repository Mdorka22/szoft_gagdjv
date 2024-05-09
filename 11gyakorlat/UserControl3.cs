using _11gyakorlat.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11gyakorlat
{
    public partial class UserControl3 : UserControl
    {
        StudiesContext context = new StudiesContext();
        public UserControl3()
        {
            InitializeComponent();
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {

            var lessons = from l in context.Instructors

                          select new
                          {
                              Oktató = l.Name,
                              s = l.Salutation,
                              Munka = l.EmployementFkNavigation.Name,
                              Státusz = l.StatusFkNavigation.Name


                          };
            dataGridView1.DataSource = lessons.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw= new StreamWriter(saveFileDialog.FileName);
                var csv = new CsvWriter(sw, CultureInfo.InvariantCulture);
                csv.WriteRecord(dataGridView1);
                sw.Close();
            }
        }
    }
}
