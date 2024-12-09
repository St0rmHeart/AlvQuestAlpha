namespace AlvQuestAlpha.FrontEnd
{
    public class StatElementPanel : MoveableCustomPanel
    {
        private readonly Label StatLabel = new();
        private readonly bool HasResistance;

        private string _statName = string.Empty;
        private int _statLevel = 0;
        private double _matchingBonus = 0.0;
        private double _additionalTurnChance = 0.0;
        private double _resistance = 0.0;

        public string StatName
        {
            get => _statName;
            set {  _statName = value; UpdateLabel(); }
        }
        public int StatLevel
        {
            get => _statLevel;
            set { _statLevel = value; UpdateLabel(); }
        }
        public double MatchingBonus
        {
            get => _matchingBonus;
            set { _matchingBonus = value; UpdateLabel(); }
        }
        public double AdditionalTurnChance
        {
            get => _additionalTurnChance;
            set { _additionalTurnChance = value; UpdateLabel(); }
        }
        public double Resistance
        {
            get => _resistance;
            set { _resistance = value; UpdateLabel(); }
        }

        public StatElementPanel(bool hasResistance = true)
        {
            Panel.BorderStyle = BorderStyle.None;
            HasResistance = hasResistance;
            StatLabel.Font = new Font("Century Gothic", 12F);
            StatLabel.ForeColor = SystemColors.ControlLight;
            StatLabel.Location = new Point(0, 0);
            StatLabel.Size = new Size(222, 60);
            StatLabel.Text = "Мастерство огня: 55\r\nБс.999% Дх.999% Сп.999%";
            StatLabel.TextAlign = ContentAlignment.MiddleCenter;
            Panel.Controls.Add(StatLabel);
        }

        private void UpdateLabel()
        {
            string res = HasResistance ? $" Сп.{_resistance}%" : string.Empty;
            StatLabel.Text = $"{_statName}: {_statLevel}\r\nБс.{_matchingBonus}% Дх.{_additionalTurnChance}%{res}";
        }
    }
}
