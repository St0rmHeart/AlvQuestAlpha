namespace AlvQuestAlpha
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonGoToSF_Click(object sender, EventArgs e)
        {
            var sf = new SettingsForm();
            sf.Show();
            Hide();
        }
    }
}
