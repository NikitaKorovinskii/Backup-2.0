using carrr.TableBd;
using System.Data;

namespace carrr
{
    public partial class TOAdd : Form
    {
        int IDcar;
        public TOAdd(string? idCar)
        {
            IDcar = Int32.Parse(idCar);
            InitializeComponent();
            using (work100013Context db = new work100013Context())
            {
                try
                {
                    var list = db.Cars.Where(p => p.IdCar == Int32.Parse(idCar));
                    foreach (var item in list)
                    {
                        CarName.Text = item.NameCar + " " + item.NumberCar;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
            if (DateTo.Text!=""&& Price.Text!=""&& Description.Text!="")
            {
                using (work100013Context db = new work100013Context())
                {
                    try
                    {
                        TechnicalInspection technicalInspection = new TechnicalInspection
                        {
                            DateOfPassage = DateOnly.Parse(DateTo.Text),
                            Sum = Int32.Parse(Price.Text),
                            Description = Description.Text,
                            IdCar = IDcar
                        };
                        db.TechnicalInspections.Add(technicalInspection);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

                Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
            
        }
    }
}
