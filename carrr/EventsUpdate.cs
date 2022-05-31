using System.Data;

namespace carrr
{
    public partial class EventsUpdate : Form
    {
        int idEventCar;
        public EventsUpdate(string? idEvent)
        {
            idEventCar = Int32.Parse(idEvent);
            InitializeComponent();
            using (work100013Context db = new())
            {
                try
                {
                    var cars = from Event in db.Events
                               join Car in db.Cars on Event.IdCar equals Car.IdCar
                               where Event.IdEvents == Int32.Parse(idEvent)
                               select new
                               {
                                   idEvent = Event.IdEvents,
                                   decription = Event.Description,
                                   carName = Car.NameCar,
                                   numCar = Car.NumberCar,

                               };
                    foreach (var u in cars)
                    {
                        idEvents.Text = u.idEvent.ToString();
                        description.Text = u.decription.ToString();
                        carName.Text = u.carName.ToString();
                        numCar.Text = u.numCar.ToString();


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
            EventCont eventCont = new EventCont();
            eventCont.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                using (work100013Context db = new())
                {
                    try
                    {
                        var cars = db.Events.Where(p => p.IdEvents == idEventCar);
                        foreach (var car in cars)
                        {
                            car.Sum = Int32.Parse(textBox1.Text);
                            car.DataEvent = DateOnly.Parse(textBox2.Text);
                        }
                        db.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                Hide();
                MainForm eventCar = new MainForm();
                eventCar.Show();
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }

        }

    }
}
