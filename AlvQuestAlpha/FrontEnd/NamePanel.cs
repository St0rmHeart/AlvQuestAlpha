namespace AlvQuestAlpha.FrontEnd
{
    public class NamePanel : CustomPanel
    {
        private readonly Label NameLabel = new();
        private int _level = 0;
        private string _name = string.Empty;

        public NamePanel()
        {
            NameLabel.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            NameLabel.ForeColor = SystemColors.ControlLight;
            NameLabel.Location = new Point(1, 1);
            NameLabel.Size = new Size(283, 48);
            NameLabel.TextAlign = ContentAlignment.MiddleLeft;
            Panel.Controls.Add(NameLabel);
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                UpdateLabel();
            }
        }

        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                UpdateLabel();
            }
        }
        
        private void UpdateLabel()
        {
            NameLabel.Text = $"{_name} lvl.{_level}";
        }
    }
}
