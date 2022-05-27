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
    public partial class EventsUpdate : Form
    {
        int idEventCar;
        public EventsUpdate(string? idEvent )
        {
            idEventCar = Int32.Parse(idEvent);
            InitializeComponent();
            using (work100013Context db = new())
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            EventCont eventCont = new EventCont();
            eventCont.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (work100013Context db = new())
            {
                var cars = db.Events.Where(p => p.IdEvents == idEventCar);
                foreach (var car in cars)
                {
                    car.Sum = Int32.Parse(textBox1.Text);
                    car.DataEvent = DateOnly.Parse(textBox2.Text);
                }
                db.SaveChanges();
            }
            Hide();
            MainForm eventCar = new MainForm();
            eventCar.Show();
        }

    }
}
