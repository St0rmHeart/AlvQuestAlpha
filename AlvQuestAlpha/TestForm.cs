using AlvQuestAlpha.FrontEnd;

namespace AlvQuestAlpha
{
    public partial class TestForm : Form
    {
        private Panel panel;

        public TestForm()
        {
            var areaPanel = new ArenaPanel();
            areaPanel.AddPanelToControls(this);

            InitializeComponent();
            //CreateTestPanel();

            
        }

        private void CreateTestPanel()
        {
            // Создаём панель
            panel = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(1000, 1000),
                BackColor = Color.FromArgb(25, 23, 24),
            };

            // Подписываем панель на событие Paint
            panel.Paint += Panel_Paint;

            // Добавляем панель на форму
            Controls.Add(panel);
        }

        // Метод, который будет отрабатывать при Paint
        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            // Получаем объект Graphics для рисования
            var graphics = e.Graphics;

            // Рисуем светло-серый прямоугольник
            graphics.FillRectangle(new SolidBrush(Color.LightGray), 100, 100, 800, 400);

            // Рисуем серую полуокружность
            graphics.FillPie(new SolidBrush(Color.Gray), 100, 100, 800, 400, 180, 180);
        }
    }
}
