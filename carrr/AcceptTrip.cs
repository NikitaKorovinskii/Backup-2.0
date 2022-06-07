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

            InitializeComponent();
            idTrip1 = idTrip;
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
                                passport = Client.Passport,
                                oneDayPriceCar = Car.PriceCar
                            };

                Excel.Application excel = new Excel.Application();
                excel.Workbooks.Add(Type.Missing);
                Excel.Workbook workbook = excel.Workbooks[1];
                Excel.Worksheet worksheet = workbook.Worksheets.get_Item(1);

                foreach (var u in trips)
                {
                    double price = 0;

                    var countMonth = (u.endDate.Month - u.startDate.Month) * 30;
                    var countDay = u.endDate.Day - u.startDate.Day;

                    if (countMonth == 0 && countDay == 1)
                    {
                        price = ((countDay + countMonth) * u.oneDayPriceCar);
                    }
                    else
                    {
                        price = ((countDay + countMonth) * u.oneDayPriceCar) * 0.8;
                    }


                    worksheet.Cells[1, 1].Value = $"Договор № {u.idTrip}";
                    worksheet.Cells[2, 1].Value = "Мы:";
                    worksheet.Cells[3, 1].Value = "ООО " + "CoinCar" + ", по адресу ул. Карла Маркса, 63, Киров, Россия, именуемый в дальнейшем Арендодатель";
                    worksheet.Cells[4, 1].Value = "И";
                    worksheet.Cells[5, 1].Value = u.lastName + " " + u.name + " " + u.middleName + $" Пасспорт: {u.passport} именуемый в дальнейшем Арендатор";
                    worksheet.Cells[6, 1].Value = "заключили настоящий договор о нижеследующем: ";
                    worksheet.Cells[7, 1].Value = "Предмет ";
                    worksheet.Cells[8, 1].Value = "1.    Арендодатель предоставляет Арендатору автомобиль: ";
                    worksheet.Cells[9, 1].Value = worksheet.Cells[10, 1].Value = $"Легковой автомобиль марки {u.carName}, государсвенный номер {u.numberCar}";
                    worksheet.Cells[10, 1].Value = "выдается во временное пользование и владение за плату, оговоренную в настоящем договоре. ";
                    worksheet.Cells[11, 1].Value = "2.    Арендодатель предоставляет транспортное средство в пользование Арендатору.  ";
                    worksheet.Cells[12, 1].Value = "2.1.         Транспортное средство находится в технически исправном состоянии, не содержит каких-либо дефектов. ";
                    worksheet.Cells[13, 1].Value = "2.2.         Арендатор обязан после истечения срока настоящего соглашения возвратить транспортное средство в технически исправном состоянии, в котором оно находилось при приеме-передаче автомобиля.";
                    worksheet.Cells[14, 1].Value = "Срок действия настоящего соглашения:";
                    worksheet.Cells[15, 1].Value = $"C {Convert.ToString(u.startDate)} по {Convert.ToString(u.endDate)}";
                    worksheet.Cells[16, 1].Value = $"Сумма аренды: {price} ₽ оплачена";
                    worksheet.Cells[17, 1].Value = "Ответственность сторон: ";
                    worksheet.Cells[18, 1].Value = "3.    Арендатор несет ответственность за состояние транспортного средства. В случае если транспортное средство было утеряно или повреждено, он обязуется возместить нанесенный ущерб либо предоставить равноценный автомобиль в пользу Арендодателя в срок: 5 (Пять) дней после выявления таких фактов. ";
                    worksheet.Cells[19, 1].Value = "3.1.         Ответственность за состояние транспортного средства в нерабочее время переходит на Арендодателя. В случае наступления вышеперечисленных фактов, Арендодатель возмещает понесенный ущерб за свой счет, а также возмещает ущерб в пользу Арендатора.";
                    worksheet.Cells[20, 1].Value = "3.2.         Арендатор обязан после истечения срока настоящего соглашения возвратить транспортное средство в технически исправном состоянии, в котором оно находилось при приеме-передаче автомобиля.";
                    worksheet.Cells[21, 1].Value = "Форс-мажорные ситуации:";
                    worksheet.Cells[22, 1].Value = "4.    Контрагенты освобождаются от ответственности по настоящему \n соглашению в случае возникновения ситуаций, происходящих вследствие непреодолимой силы. К таким ситуациям могут относиться обстоятельства, которые одна из сторон не может самостоятельно контролировать, например: неисполнение обязательств по настоящему договору одной из сторон.";
                    worksheet.Cells[23, 1].Value = "4.1.         При возникновении таких ситуаций одна из сторон обязуется уведомить другую в письменной форме в срок: 5 (Пять) дней после выявления такого факта.";
                    worksheet.Cells[24, 1].Value = "4.2.         Если обязательства по настоящему соглашению не могут быть исполнены из-за факторов, которые не зависят от воли сторон, Арендатор обязуется выплатить арендную плату за эксплуатацию автомобиля в том объеме, который он должен за момент использования транспортного средства. ";
                    worksheet.Cells[25, 1].Value = "Дополнительные условия: ";
                    worksheet.Cells[26, 1].Value = "5.    Соглашение может быть расторгнуто по обоюдному соглашению сторон.";
                    worksheet.Cells[27, 1].Value = "5.1.В случае наступления каких - либо спорных ситуаций, связанных с исполнением обязательств по договору, моменты, которые не прописаны в настоящем соглашении будут регулироваться сторонами при использовании документов действующего законодательства Российской Федерации.";
                    worksheet.Cells[28, 1].Value = "5.2.         Договор составлен в двух экземплярах для каждой из сторон.";
                    worksheet.Cells[29, 1].Value = "Дата заключения " + DateOnly.FromDateTime(DateTime.Now);
                    worksheet.Cells[30, 1].Value = "Подпись сторон:  Арендатор:                   Арендодатель:         ";


                }
                excel.Visible = true;



            }



        }
    }
}
