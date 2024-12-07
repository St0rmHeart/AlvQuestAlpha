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
            areaPanel.AddPanelToControls(this);
        }
    }
}
