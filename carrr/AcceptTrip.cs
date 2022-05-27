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
    public partial class AcceptTrip : Form
    {
        int idTrip1;
        public AcceptTrip( int idTrip)
        {
            idTrip1 = idTrip;
            InitializeComponent();
            idTripx.Text = Convert.ToString(idTrip);
            using (work100013Context db = new())
            {
                var trips = from Trip in db.Trips
                            join Client in db.Clients on Trip.IdClient equals Client.IdClient
                            join Car in db.Cars on Trip.IdCar equals Car.IdCar
                            where Trip.IdTrip == idTrip
                            select new
                            {
                                startDate = Trip.StartDate,
                                endDate = Trip.EndDate,
                                name = Client.Name,
                                carName = Car.NameCar,
                                lastName = Client.LastName,
                                middleName = Client.MiddleName,
                                numberCar = Car.NumberCar,
                                number = Client.Number,
                            };
                foreach (var u in trips)
                {
                    startDate.Text = u.startDate.ToString();
                    endDate.Text = u.endDate.ToString();
                    name.Text = u.name.ToString();
                    carName.Text = u.carName.ToString() + " " + u.numberCar;
                    lastName.Text = u.lastName.ToString();
                    middleName.Text = u.middleName.ToString();
                    number.Text = "8" + u.number.ToString();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void accept_Trip_Click(object sender, EventArgs e)
        {
            var cars = 0;
            using (work100013Context db = new())
            {

                Triptimeclient tr = new Triptimeclient
                {
                    Time = Convert.ToDateTime(time.Text),
                    IdTrip = Convert.ToInt32(idTripx.Text)
                };
                db.Triptimeclients.Add(tr);
                db.SaveChanges();
                var trips = from Trip in db.Trips
                            join Car in db.Cars on Trip.IdCar equals Car.IdCar
                            where Trip.IdTrip == idTrip1
                            select new
                            {
                                carid = Car.IdCar
                            };
                foreach (var trip in trips)
                {
                    cars = trip.carid;

                }
            }
            using (work100013Context db = new())
            {
                var carsAll = db.Cars.Where(p => p.IdCar == cars);
                foreach (var carid in carsAll)
                {
                    carid.StatusIssuance = false;

                }
                db.SaveChanges();
            }
            Hide();
            MainForm m = new MainForm();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            TripOpen tripOpen = new TripOpen();
            tripOpen.Show();
        }

        private void idTripx_Click(object sender, EventArgs e)
        {

        }
    }
}
