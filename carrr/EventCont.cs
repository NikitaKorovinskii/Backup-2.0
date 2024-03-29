﻿using carrr.TableBd;
using System.Data;
using System.Text;

namespace carrr
{
    public partial class EventCont : Form
    {
        public EventCont()
        {
            InitializeComponent();
        }

        private void EventCont_Load(object sender, EventArgs e)
        {

            table.AllowUserToAddRows = false; //запрешаем пользователю самому добавлять строки
                                              //Добавляем строку, указывая значения колонок поочереди слева направо
            using (work100013Context db = new())
            {
                try
                {
                    var cars = from Event in db.Events
                               join Car in db.Cars on Event.IdCar equals Car.IdCar
                               where Event.Sum == null
                               select new
                               {
                                   idEvent = Event.IdEvents,
                                   decription = Event.Description,
                                   carName = Car.NameCar,
                                   numCar = Car.NumberCar
                               };
                    foreach (var u in cars)
                    {
                        table.Rows.Add($"{u.idEvent} ", $"{u.decription}", $"{u.carName}", $"{u.numCar}");

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
                        var idEvent = table.CurrentRow.Cells[i].Value.ToString();
                        Hide();
                        EventsUpdate eventsUpdate = new EventsUpdate(idEvent);
                        eventsUpdate.Show();
                    }

                }
            }
        }
    }
}
