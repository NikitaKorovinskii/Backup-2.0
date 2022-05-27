using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carrr
{
    public partial class TOAdd : Form
    {
        int IDcar;
        public TOAdd(string? idCar)
        {
            IDcar = Int32.Parse(idCar);
            InitializeComponent();
            using(work100013Context db = new work100013Context())
            {
                var list = db.Cars.Where(p => p.IdCar == Int32.Parse(idCar));
                foreach(var item in list)
                {
                    CarName.Text = item.NameCar +" "+ item.NumberCar;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            TO tO = new TO();
            tO.Show();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using(work100013Context db = new work100013Context())
            {
                TechnicalInspection technicalInspection = new TechnicalInspection
                {
                    DateOfPassage = DateOnly.Parse(DateTo.Text) ,
                    Sum = Int32.Parse(Price.Text),
                    Description = Description.Text,
                    IdCar=IDcar
                };
                db.TechnicalInspections.Add(technicalInspection);
                db.SaveChanges();
            }
           
            Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
