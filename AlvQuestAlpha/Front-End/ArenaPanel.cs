using AlvQuestCore;

namespace AlvQuestAlpha.FrontEnd
{
    public class ArenaPanel : Panel
    {
        private readonly CardPanel Player1Panel;
        private readonly CardPanel Player2Panel;
        private readonly StoneBoardPanel StoneBoardPanel;
        private readonly Label TurnCounterLabel;

        // Константы размеров и позиций панели и её элементов
        private const int ArenaWidth = 1914;
        private const int ArenaHeight = 1032;

        private readonly Point Player1PanelLocation = new(0, 0);
        private readonly Point Player2PanelLocation = new(1459, 0);
        private readonly Point StoneBoardPanelLocation = new(457, 0);

        private int TurnCounter = 0;

        public ArenaPanel()
        {
            Size = new Size(ArenaWidth, ArenaHeight);
            BackColor = Color.FromArgb(25, 23, 24);

            Player1Panel = new CardPanel();
            Player2Panel = new CardPanel();
            StoneBoardPanel = new StoneBoardPanel();

            Player1Panel.Location = Player1PanelLocation;
            Player2Panel.Location = Player2PanelLocation;
            StoneBoardPanel.Location = StoneBoardPanelLocation;

            Controls.Add(Player1Panel);
            Controls.Add(Player2Panel);
            Controls.Add(StoneBoardPanel);

            TurnCounterLabel = new Label
            {
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 204),
                ForeColor = SystemColors.AppWorkspace,
                BackColor = Color.FromArgb(25, 23, 24),
                Location = new Point(457, 1002),
                Size = new Size(1000, 30),
                Text = "Ход: 0",
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(TurnCounterLabel);
            var stoneboard = new StoneBoard();
            stoneboard.TurnFinished += UpdateCounter;
            StoneBoardPanel.InstallStoneBoard(stoneboard);

        }
        private void UpdateCounter(object sender, EventArgs e)
        {
            TurnCounter++;
            TurnCounterLabel.Text = $"Ход: {TurnCounter}";
        }
    }
}
