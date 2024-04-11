using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace ZHgyak
{
    public partial class Form1 : Form
    {

        BindingList<CountryData> countrylist = new();
        public Form1()
        {
            InitializeComponent();
            countryDataBindingSource.DataSource = countrylist;
            dataGridView1.DataSource = countryDataBindingSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            StreamReader sr = new StreamReader("european_countries.csv");
            var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
            var tomb = csv.GetRecords<CountryData>();
            foreach (var item in tomb)
            {
                countrylist.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            countryDataBindingSource.RemoveCurrent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCountryEdit fce = new FormCountryEdit();
            fce.CountryData = countryDataBindingSource.Current as CountryData;
            fce.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    using (var writer = new StreamWriter(saveFileDialog.FileName))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(countrylist);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                
            }

            
        }
    }
}