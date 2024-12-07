namespace AlvQuestAlpha.FrontEnd
{
    public class HealthPanel : CustomPanel
    {
        private readonly Label HealthLabel = new();
        private int _currentHealth = 0;
        private int _maxHealth = 0;

        public HealthPanel()
        {
            HealthLabel.Font = new Font("Century Gothic", 14F);
            HealthLabel.ForeColor = SystemColors.ControlLight;
            HealthLabel.Location = new Point(1, 1);
            HealthLabel.Size = new Size(156, 18);
            HealthLabel.TextAlign = ContentAlignment.TopCenter;
            Panel.Controls.Add(HealthLabel);
        }

        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                UpdateLabel();
            }
        }
        public int MaxHealth
        {
            get => _maxHealth;
            set
            {
                _maxHealth = value;
                UpdateLabel();
            }
        }

        private void UpdateLabel()
        {
            HealthLabel.Text = $"{_currentHealth} / {_maxHealth}";
        }
    }
}
