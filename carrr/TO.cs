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
    public partial class TO : Form
    {
        public TO()
        {
            InitializeComponent();
        }

        private void TechnicalInspection_Load(object sender, EventArgs e)
        {
            using (work100013Context db = new work100013Context())
            {
                var car = db.Cars.OrderBy(p=>p.IdCar);
                foreach (var c in car)
                {
                    table.Rows.Add($"{c.IdCar}", $"{c.NameCar}", $"{c.NumberCar}", $"{c.BodyType}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            EventCar eventCar = new EventCar();
            eventCar.Show();
        }

        private void table_DoubleClick(object sender, EventArgs e)
        {
            Int32 selectedCellCount = table.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                if (table.AreAllCellsSelected(true))
                {
                    MessageBox.Show("All cells are selected", "Selected Cells");
                }
                else
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < selectedCellCount; i++)
                    {
                        sb.Append("Заявка: " + table.CurrentRow.Cells[i].Value.ToString());
                        var idTrip = table.CurrentRow.Cells[i].Value.ToString();
                        Hide();
                        TOAdd acceptTrip = new TOAdd(idTrip);
                        acceptTrip.Show();
                    }

                }
            }
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
