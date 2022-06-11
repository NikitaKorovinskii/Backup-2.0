
using carrr.TableBd;
using System.Data;

namespace carrr
{
    public partial class TripNew : Form
    {
        int carid;
        int clientId;
        int oneDayPriceCar;
        double price = 0;
        public TripNew()
        {
            InitializeComponent();
            Scence2.Visible = false;
            label6.Visible = false;
            priceTrip.Visible = false;
            using (work100013Context db = new())
            {
                try
                {
                    var list = db.Cars;
                    foreach (var car in list)
                    {
                        comboBox1.Items.Add(car.NameCar);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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

            if (lastName.Text != "" && name.Text != "" && middleName.Text != "" && passport.Text != "" && driverNum.Text != "" && phone.Text != "" && dateOfBith.Text != "")
            {
                Scence2.Visible = true;
                Scence1.Visible = false;
                using (work100013Context db = new())
                {
                    try
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

                        var list = db.Clients.Where(p => p.Passport == passport.Text);
                        foreach (var u in list)
                        {
                            clientId = u.IdClient;
                        }
                        Wallet wallet = new Wallet
                        {
                            Sum = 0,
                            IdClient = clientId
                        };
                        db.Wallets.Add(wallet);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }



        }

        private void endBTN_Click(object sender, EventArgs e)
        {

            using (work100013Context db = new())
            {
                try
                {
                    var cars = db.Cars.Where(p => p.NameCar == comboBox1.SelectedItem);
                    foreach (var u in cars)
                    {
                        carid = u.IdCar;
                        oneDayPriceCar = u.PriceCar;
                      

                    }
                    int Idwallet = 0;
                    var list = db.Wallets.Where(p => p.IdClient == clientId);
                    foreach (var wallet in list)
                    {
                        Idwallet = wallet.IdWallet;
                    }
                    HistoryWallet historyWallet = new HistoryWallet
                    {
                        DateOperation = DateOnly.FromDateTime(DateTime.Now),
                        TimeOperation = DateTimeOffset.Now,
                        Sum = (int)price,
                        IdWallet = Idwallet
                    };
                    db.HistoryWallets.Add(historyWallet);
                    db.SaveChanges();

                    HistoryWallet wallet1 = new HistoryWallet
                    {
                        DateOperation = DateOnly.FromDateTime(DateTime.Now),
                        TimeOperation = DateTimeOffset.Now,
                        Sum = -(int)price,
                        IdWallet = Idwallet
                    };
                    db.HistoryWallets.Add(wallet1);
                    db.SaveChanges();

                    Trip trip = new Trip
                    {
                        StartDate = DateOnly.Parse(startDate.Text),
                        EndDate = DateOnly.Parse(endDate.Text),
                        IdCar = carid,
                        IdClient = clientId,
                        StatusTrip = true,
                        StatusCar= false
                    };
                    db.Trips.Add(trip);
                    db.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            Hide();
            MainForm mainForm2 = new MainForm();
            mainForm2.Show();
        }

        private void PriceCount_Click(object sender, EventArgs e)
        {
            using (work100013Context db = new())
            {
                try
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

                    if (countMonth == 0 && countDay == 1)
                    {
                        price = ((countDay + countMonth) * oneDayPriceCar);
                    }
                    else
                    {
                        price = ((countDay + countMonth) * oneDayPriceCar) * 0.8;
                    }
                    priceTrip.Text = price.ToString() + " ₽";
                    PriceCount.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

        }
    }
}
