namespace AlvQuestAlpha.FrontEnd
{
    public abstract class CustomPanel
    {
        /// <summary>
        /// Панель для отображения графики
        /// </summary>
        protected readonly Panel Panel = new();

        public CustomPanel()
        {
            // Устанавливаем стандартный задний фон и границу контейнера
            Panel.BackColor = Color.FromArgb(25, 23, 24);
            Panel.BorderStyle = BorderStyle.FixedSingle;

            // Получаем имя класса, который наследует CustomPanel
            string className = GetType().Name;

            // Получаем расположение и размер из LayoutStorage для этого имени
            Point location = LayoutStorage.GetLocation(className);
            Size size = LayoutStorage.GetSize(className);

            // Устанавливаем расположение и размер панели
            Panel.Location = location;
            Panel.Size = size;
        }

        /// <summary>
        /// Добавляет внутреннюю панель на указанный элемент управления.
        /// </summary>
        /// <param name="parentControl">Элемент управления, к которому нужно добавить панель.</param>
        public void AddPanelToControls(Control parentControl)
        {
            if (parentControl == null)
            {
                throw new ArgumentNullException(nameof(parentControl), "Parent control cannot be null.");
            }

            parentControl.Controls.Add(Panel);
        }
    }

    public abstract class MoveableCustomPanel : CustomPanel
    {
        public Point PanelLocation
        {
            get => Panel.Location;
            set => Panel.Location = value;
        }
    }
}
