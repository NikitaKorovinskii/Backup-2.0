using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.Util.Collections;

namespace carrr
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void openTrip_Click(object sender, EventArgs e)
        {
           Hide();
            TripOpen tripNew = new TripOpen();
            tripNew.Show();
        }

        private void eventCar_Click(object sender, EventArgs e)
        {
            Hide();
            EventCar eventCar = new EventCar();
            eventCar.Show();
        }

        private void newTrip_Click(object sender, EventArgs e)
        {
            Hide();
            TripNew tripNew = new TripNew();
            tripNew.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
        }
    }
}
