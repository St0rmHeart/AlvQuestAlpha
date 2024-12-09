using System.Drawing.Drawing2D;
using AlvQuestCore;
namespace AlvQuestAlpha.FrontEnd
{
    public class StatPanel : CustomPanel
    {
        private const int StatsNum = 7;
        // Статические объекты для переиспользования
        private static readonly LinearGradientBrush GradientBrush;
        private static readonly ColorBlend ColorBlend;
        // Статический конструктор для инициализации статических объектов
        static StatPanel()
        {
            // Цвета для градиента
            Color leftColor = Color.FromArgb(23, 24, 25);
            Color centerColor = Color.FromArgb(100, 100, 100);
            Color rightColor = Color.FromArgb(23, 24, 25);

            // Создаем кисть с линейным градиентом
            GradientBrush = new LinearGradientBrush(
                new Rectangle(0, 0, LayoutStorage.GetSize("StatPanel").Width, 1), // Временные размеры, будут обновлены при рисовании
                leftColor, rightColor,
                LinearGradientMode.Horizontal);

            // Настроим градиент
            ColorBlend = new ColorBlend
            {
                Colors = [leftColor, centerColor, rightColor],
                Positions = [0f, 0.5f, 1f]
            };
            GradientBrush.InterpolationColors = ColorBlend;
        }

        private readonly Dictionary<ECharacteristic, StatElementPanel> Stats = new()
        {
            {
                ECharacteristic.Endurance,
                new StatElementPanel(false)
                {
                    PanelLocation = new Point(0, 3 + 66 * 0),
                    StatName = "Выносливость",
                }
            },
            {
                ECharacteristic.Dexterity,
                new StatElementPanel(false) {
                    PanelLocation = new Point(0, 3 + 66 * 1),
                    StatName = "Ловкость",
                }
            },
            {
                ECharacteristic.Strength,
                new StatElementPanel {
                    PanelLocation = new Point(0, 3 + 66 * 2),
                    StatName = "Сила",
                }
            },
            {
                ECharacteristic.Fire,
                new StatElementPanel {
                    PanelLocation = new Point(0, 3 + 66 * 3),
                    StatName = "Мастерство огня",
                }
            },
            {
                ECharacteristic.Water,
                new StatElementPanel {
                    PanelLocation = new Point(0, 3 + 66 * 4),
                    StatName = "Мастерство воды ",
                }
            },
            {
                ECharacteristic.Air,
                new StatElementPanel {
                    PanelLocation = new Point(0, 3 + 66 * 5),
                    StatName = "Мастерство воздуха",
                }
            },
            {
                ECharacteristic.Earth,
                new StatElementPanel {
                    PanelLocation = new Point(0, 3 + 66 * 6),
                    StatName = "Мастерство земли",
                }
            },
        };

        public StatPanel()
        {
            // Регистрируем обработчик события Paint
            Panel.Paint += (s, e) => DrawGradientLines(e.Graphics, Panel, StatsNum); // 7 секторов

            Stats[ECharacteristic.Endurance].AddPanelToControls(Panel);
            Stats[ECharacteristic.Dexterity].AddPanelToControls(Panel);
            Stats[ECharacteristic.Strength].AddPanelToControls(Panel);
            Stats[ECharacteristic.Fire].AddPanelToControls(Panel);
            Stats[ECharacteristic.Water].AddPanelToControls(Panel);
            Stats[ECharacteristic.Air].AddPanelToControls(Panel);
            Stats[ECharacteristic.Earth].AddPanelToControls(Panel);
        }

        private static void DrawGradientLines(Graphics graphics, Panel panel, int sectors)
        {
            if (sectors < 2) return; // Для корректности должно быть хотя бы два сектора (одна линия)

            // Вычисляем высоту каждого сектора
            int sectorHeight = panel.Height / sectors;

            // Рисуем n-1 линий
            for (int i = 1; i < sectors; i++)
            {
                int yPosition = i * sectorHeight;
                graphics.FillRectangle(GradientBrush, 0, yPosition, panel.Width, 1); // Толщина линии всегда 1 пиксель
            }
        }
    }
}
