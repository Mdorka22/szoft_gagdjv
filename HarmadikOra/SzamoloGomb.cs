using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmadikOra
{
    internal class SzamoloGomb: VillogoGomb
    {
        public SzamoloGomb()
        {
            MouseClick += SzamoloGomb_MouseClick;
            
        }
        int szám = 1;
        private void SzamoloGomb_MouseClick(object? sender, MouseEventArgs e)
        {
            if (szám < 6) 
            {
                szám += 1;
                Text=szám.ToString();

            }
            else
            {
                szám = 1;
                Text = szám.ToString();
            }

        }
    }
}
