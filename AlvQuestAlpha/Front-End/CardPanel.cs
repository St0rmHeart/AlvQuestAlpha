namespace AlvQuestAlpha.FrontEnd
{
    public class CardPanel : Panel
    {
        private readonly Panel SpellPanel;
        private readonly Panel PerkPanel;
        private readonly Panel StatPanel;
        private readonly Panel EquipmentPanel;
        private readonly Panel GoldExpPanel;
        private readonly Panel ManaPanel;
        private readonly Panel IconPanel;

        // Константы размеров и позиций панели и её элементов
        private const int CardPanelWidth = 455;
        private const int CardPanelHeight = 1032;

        private readonly (Point Location, Size Size) IconPanelProps = (new Point(2, 2), new Size(287, 287));
        private readonly (Point Location, Size Size) ManaPanelProps = (new Point(291, 2), new Size(160, 287));
        private readonly (Point Location, Size Size) GoldExpPanelProps = (new Point(2, 291), new Size(449, 40));
        private readonly (Point Location, Size Size) EquipmentPanelProps = (new Point(2, 333), new Size(224, 224));
        private readonly (Point Location, Size Size) PerkPanelProps = (new Point(227, 333), new Size(224, 224));
        private readonly (Point Location, Size Size) StatPanelProps = (new Point(2, 559), new Size(224, 469));
        private readonly (Point Location, Size Size) SpellPanelProps = (new Point(227, 559), new Size(224, 469));

        public CardPanel()
        {
            // Установка размеров и положения панели
            Size = new Size(CardPanelWidth, CardPanelHeight);
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.FromArgb(25, 23, 24);

            // Создание и настройка элементов
            IconPanel = CreatePanel(IconPanelProps);
            ManaPanel = CreatePanel(ManaPanelProps);
            GoldExpPanel = CreatePanel(GoldExpPanelProps);
            EquipmentPanel = CreatePanel(EquipmentPanelProps);
            PerkPanel = CreatePanel(PerkPanelProps);
            StatPanel = CreatePanel(StatPanelProps);
            SpellPanel = CreatePanel(SpellPanelProps);

            // Добавление элементов в панель
            Controls.Add(IconPanel);
            Controls.Add(ManaPanel);
            Controls.Add(GoldExpPanel);
            Controls.Add(EquipmentPanel);
            Controls.Add(PerkPanel);
            Controls.Add(StatPanel);
            Controls.Add(SpellPanel);
        }

        private static Panel CreatePanel((Point Location, Size Size) properties)
        {
            return new Panel
            {
                Location = properties.Location,
                Size = properties.Size,
                BorderStyle = BorderStyle.FixedSingle
            };
        }
    }
}
