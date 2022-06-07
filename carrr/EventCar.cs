namespace carrr
{
    public partial class EventCar : Form
    {
        public EventCar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm frm = new MainForm();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            EventCont eventCont = new EventCont();
            eventCont.Show();

        }

        private void Technical_Click(object sender, EventArgs e)
        {
            Hide();
            TO technicalInspection = new TO();
            technicalInspection.Show();
        }
    }
}
