using AlvQuestAlpha.FrontEnd;

namespace AlvQuestAlpha
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            //var cardPanel = new CardPanel(10, 10);
            var areaPanel = new ArenaPanel();
            areaPanel.Location = new Point(10, 10);
            Controls.Add(areaPanel);
        }
    }
}
