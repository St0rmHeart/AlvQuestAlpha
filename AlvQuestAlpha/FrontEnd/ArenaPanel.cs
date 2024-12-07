using AlvQuestCore;

namespace AlvQuestAlpha.FrontEnd
{
    public class ArenaPanel : CustomPanel
    {
        private readonly CardPanel Player1Panel = new();
        private readonly CardPanel Player2Panel = new();
        private readonly StoneBoardPanel StoneBoardPanel = new();
        private readonly Label TurnCounterLabel = new();

        private int TurnCounter = 0;

        public ArenaPanel()
        {
            Panel.BorderStyle = BorderStyle.None;
            Player1Panel.PanelLocation = new(0, 0);
            Player2Panel.PanelLocation = new(1459, 0);
            StoneBoardPanel.PanelLocation = new(457, 0);

            Player1Panel.AddPanelToControls(Panel);
            Player2Panel.AddPanelToControls(Panel);
            StoneBoardPanel.AddPanelToControls(Panel);

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
            Panel.Controls.Add(TurnCounterLabel);

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
