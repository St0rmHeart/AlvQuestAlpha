namespace AlvQuestAlpha.FrontEnd
{
    // Статический класс-хранилище разметки
    public static class LayoutStorage
    {
        // Словарь для хранения данных о разметке
        private static readonly Dictionary<string, (Point Location, Size Size)> Layouts = new()
        {
            //Основные панели
            { "ArenaPanel", new (new Point(10, 10), new Size(1914, 1032)) },
                { "StoneBoardPanel", new (new Point(2, 2), new Size(1000, 1000)) },
                { "CardPanel", new (new Point(-1, -1), new Size(455, 1032)) }, //Расположение зависит от того, чья это карта
                    { "NamePanel", new (new Point(2, 2), new Size(287, 52)) },
                    { "HealthPanel", new (new Point(291, 2), new Size(160, 52)) },
                    { "IconPanel", new (new Point(2, 56), new Size(287, 287)) },
                    { "ManaPanel", new (new Point(291, 56), new Size(160, 287)) },
                    { "ManaPanel2", new (new Point(291, 56), new Size(160, 287)) },
                    { "GoldExpPanel", new (new Point(2, 345), new Size(449, 30)) },
                    { "EquipmentPanel", new (new Point(2, 377), new Size(224, 182)) },
                    { "PerkPanel", new (new Point(227, 377), new Size(224, 182)) },
                        { "PerkEquipmentPanel", new (new Point(-1, -1), new Size(222, 30)) },
                    { "StatPanel", new (new Point(2, 561), new Size(224, 467)) },
                        { "StatElementPanel", new (new Point(2, 561), new Size(222, 60)) },
                    { "SpellPanel", new (new Point(227, 561), new Size(224, 467)) },
        };

        // Метод для получения местоположения панели
        public static Point GetLocation(string className)
        {
            if (Layouts.TryGetValue(className, out var layout))
            {
                return layout.Location;
            }

            throw new KeyNotFoundException($"Layout for class '{className}' not found.");
        }

        // Метод для получения размера панели
        public static Size GetSize(string className)
        {
            if (Layouts.TryGetValue(className, out var layout))
            {
                return layout.Size;
            }

            throw new KeyNotFoundException($"Layout for class '{className}' not found.");
        }
    }
}
