using System.Data;

namespace carrr
{
    public partial class TripOpen : Form
    {
        public TripOpen()
        {
            InitializeComponent();


        }


        private async void TripOpen_Load(object sender, EventArgs e)
        {




            table.AllowUserToAddRows = false; //запрешаем пользователю самому добавлять строки
                                              //Добавляем строку, указывая значения колонок поочереди слева направо
            using (work100013Context db = new())
            {
                try
                {
                    var trips =  from Trip in db.Trips
                                join Client in db.Clients on Trip.IdClient equals Client.IdClient
                                       join Car in db.Cars on Trip.IdCar equals Car.IdCar
                                where Trip.StatusTrip==true
                                select new
                                {
                                    idTrip = Trip.IdTrip,
                                    startDate = Trip.StartDate,
                                    endDate = Trip.EndDate,
                                    name = Client.Name,
                                    carName = Car.NameCar
                                };
                    foreach (var u in trips)
                    {

                        table.Rows.Add($"{u.idTrip} ", $"{u.startDate}", $"{u.endDate}", $"{u.name}", $"{u.carName}");

                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < selectedCellCount; i++)
                    {
                        sb.Append("Заявка: " + table.CurrentRow.Cells[i].Value.ToString());
                        var idTrip = table.CurrentRow.Cells[i].Value.ToString();
                        Hide();
                        AcceptTrip acceptTrip = new AcceptTrip(Int32.Parse(idTrip));
                        acceptTrip.Show();
                    }

                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
