using carrr.TableBd;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace carrr
{
    public partial class AcceptTrip : Form
    {
        int idTrip1;
        public AcceptTrip(int idTrip)
        {
            idTrip1 = idTrip;
            InitializeComponent();
            idTripx.Text = Convert.ToString(idTrip);
            using (work100013Context db = new())
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void accept_Trip_Click(object sender, EventArgs e)
        {
            if (time.Text != "")
            {
                var cars = 0;
                using (work100013Context db = new())
                {
                    try
                    {
                        var list = db.Trips.Where(p => p.StatusTrip == true);
                        foreach (var u in list)
                        {
                            u.StatusTrip = false;
                        }
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
                        Triptimeclient tr = new Triptimeclient
                        {
                            Time = Convert.ToDateTime(time.Text),
                            IdTrip = Convert.ToInt32(idTripx.Text)
                        };
                        db.Triptimeclients.Add(tr);
                        db.SaveChanges();



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }
                using (work100013Context db = new())
                {
                    try
                    {
                        var carsAll = db.Cars.Where(p => p.IdCar == cars);
                        foreach (var carid in carsAll)
                        {
                            carid.StatusIssuance = false;

                        }
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


                Hide();
                MainForm m = new MainForm();
                m.Show();
            }
            else
            {
                MessageBox.Show("Введите время");
            }
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




        private void button1_Click_1(object sender, EventArgs e)
        {

            using (work100013Context db = new work100013Context())
            {


                try
                {
                    

                    var trips = from Trip in db.Trips
                                join Client in db.Clients on Trip.IdClient equals Client.IdClient
                                join Car in db.Cars on Trip.IdCar equals Car.IdCar
                                where Trip.IdTrip == idTrip1
                                select new
                                {
                                    idTrip = Trip.IdTrip,
                                    startDate = Trip.StartDate,
                                    endDate = Trip.EndDate,
                                    name = Client.Name,
                                    carName = Car.NameCar,
                                    lastName = Client.LastName,
                                    middleName = Client.MiddleName,
                                    numberCar = Car.NumberCar,
                                    number = Client.Number,
                                };
                    Excel.Application excel = new Excel.Application();
                    excel.Workbooks.Add(Type.Missing);
                    Excel.Workbook workbook = excel.Workbooks[1];
                    Excel.Worksheet worksheet = workbook.Worksheets.get_Item(1);

                    worksheet.Cells[1, 1].Value = "Номер поездки";
                    worksheet.Cells[1, 2].Value = "Начало";
                    worksheet.Cells[1, 3].Value = "Конец";
                    worksheet.Cells[1, 4].Value = "Фимилия";
                    worksheet.Cells[1, 5].Value = "Имя";
                    worksheet.Cells[1, 6].Value = "Отчество";
                    worksheet.Cells[1, 7].Value = "Название авто";
                    worksheet.Cells[1, 8].Value = "Номер авто";
                    foreach (var u in trips)
                    {

                        worksheet.Cells[2, 1].Value = u.idTrip;
                        worksheet.Cells[2, 2].Value = Convert.ToString(u.startDate);
                        worksheet.Cells[2, 3].Value = Convert.ToString(u.endDate);
                        worksheet.Cells[2, 4].Value = u.lastName;
                        worksheet.Cells[2, 5].Value = u.name;
                        worksheet.Cells[2, 6].Value = u.middleName;
                        worksheet.Cells[2, 7].Value = u.carName;
                        worksheet.Cells[2, 8].Value = u.numberCar;

                    }
                    excel.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Что-то пошло не так :" + ex.Message);
                }


            }
        }
    }
}
