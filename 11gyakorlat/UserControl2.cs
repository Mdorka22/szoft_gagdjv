using _11gyakorlat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11gyakorlat
{
    public partial class UserControl2 : UserControl
    {
        StudiesContext context = new StudiesContext();
        public UserControl2()
        {
            InitializeComponent();
            listBox1.DisplayMember = "Name";
            FillDataSource();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            var ilist = from i in context.Courses
                        select i;
        }
        private void FillDataSource()
        {
            listBox1.DataSource = (from i in context.Courses
                                   where i.Name.Contains(textBox1.Text)
                                   select i).ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FillDataSource();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            Course course = listBox1.SelectedItem as Course;
            var lessons = from l in context.Lessons
                          where l.CourseFk == course.CourseSk
                          select new
                          {
                              Oktató = l.InstructorFkNavigation.Name,
                              Nap = l.DayFkNavigation.Name,
                              Sáv = l.TimeFkNavigation.Name

                          };
            dataGridView1.DataSource = lessons.ToList();
        }
    }
}
