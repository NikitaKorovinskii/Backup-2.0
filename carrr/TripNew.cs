using System.Data;

namespace carrr
{
    public partial class TripNew : Form
    {
        int carid;
        int clientId;
        int oneDayPriceCar;
        public TripNew()
        {
            InitializeComponent();
            Scence2.Visible = false;
            label6.Visible = false;
            priceTrip.Visible = false;
            using (work100013Context db = new())
            {
                var list = db.Cars;
                foreach (var car in list)
                {
                    comboBox1.Items.Add(car.NameCar);
                }
            }
            startDate.MinDate = DateTime.Now;
            endDate.MinDate = DateTime.Now.AddDays(1);
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void contBTN_Click(object sender, EventArgs e)
        {
            Scence2.Visible = true;
            Scence1.Visible = false;
            using (work100013Context db = new())
            {
                Client client = new Client
                {
                    LastName = lastName.Text,
                    Name = name.Text,
                    MiddleName = middleName.Text,
                    Passport = passport.Text,
                    NumberDriver = driverNum.Text,
                    Number = phone.Text,
                    DataOfBith = DateOnly.Parse(dateOfBith.Text) // Исправить ошибку и при добавление поездки менять статусы у машины оба на true.
                };

                db.Clients.Add(client);
                db.SaveChanges();
            }


        }

        private void endBTN_Click(object sender, EventArgs e)
        {
           
            using (work100013Context db = new())
            {

                var cars = db.Cars.Where(p => p.NameCar == comboBox1.SelectedItem);
                foreach (var u in cars)
                {
                    carid = u.IdCar;
                    oneDayPriceCar = u.PriceCar;
                    u.StatusBooking = true;
                    u.StatusIssuance = true;

                }

                var clients = db.Clients.Where(p => p.Passport == passport.Text);
                foreach (var u in clients)
                {
                    clientId = u.IdClient;
                }


                Trip trip = new Trip
                {
                    StartDate = DateOnly.Parse(startDate.Text),
                    EndDate = DateOnly.Parse(endDate.Text),
                    IdCar = carid,
                    IdClient = clientId
                };
                db.Trips.Add(trip);
                db.SaveChanges();

            }
            Hide();
            MainForm mainForm2 = new MainForm();
            mainForm2.Show();
        }

        private void PriceCount_Click(object sender, EventArgs e)
        {
            using (work100013Context db = new())
            {

                var cars = db.Cars.Where(p => p.NameCar == comboBox1.SelectedItem);
                foreach (var u in cars)
                {

                    oneDayPriceCar = u.PriceCar;

                }
                priceTrip.Visible = true;
                label6.Visible = true;
                var countMonth = (endDate.Value.Month - startDate.Value.Month) * 30;
                var countDay = endDate.Value.Day - startDate.Value.Day;
                double x = 0;
                if (countMonth == 0 && countDay == 1)
                {
                    x = ((countDay + countMonth) * oneDayPriceCar);
                }
                else
                {
                    x = ((countDay + countMonth) * oneDayPriceCar) * 0.8;
                }
                priceTrip.Text = x.ToString() + " ₽";
                PriceCount.Visible = false;
            }

        }
    }
}
