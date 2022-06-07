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
    }
}
