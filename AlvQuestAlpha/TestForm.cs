namespace AlvQuestAlpha
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            var cardPanel = new CardPanel(10, 10);
            Controls.Add(cardPanel);
        }
    }
}
