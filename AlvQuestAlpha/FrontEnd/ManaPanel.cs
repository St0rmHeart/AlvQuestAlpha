using AlvQuestCore;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace AlvQuestAlpha.FrontEnd
{
    public class ManaPanel : CustomPanel
    {
        private const int ColumnCount = 4;
        private const int HorPadding = 10; // Горизонтальный отступ
        private const int TopPadding = 6; // Верхний отступ
        private const int DownPadding = 60; // Нижний отступ
        private readonly Dictionary<EManaType, int> ManaOrder = new()
        {
            { EManaType.EarthStone, 1 },
            { EManaType.FireStone, 2 },
            { EManaType.AirStone, 3 },
            {EManaType.WaterStone, 4 }
        };


        private static readonly Dictionary<EStoneType, Image> StoneImages = new(
            Enum.GetValues(typeof(EStoneType))
                .Cast<EStoneType>()
                .Where(stoneType => stoneType != EStoneType.None)
                .ToDictionary(
                    stoneType => stoneType,
                    stoneType =>
                    {
                        string basePath = AppDomain.CurrentDomain.BaseDirectory;
                        string relativeAssetsPath = @"..\..\..\Assets\Stones";
                        string assetsPath = Path.GetFullPath(Path.Combine(basePath, relativeAssetsPath));
                        string fileName = $"{(int)stoneType}.png";
                        string filePath = Path.Combine(assetsPath, fileName);
                        return Image.FromFile(filePath);
                    }
                )
        );

        private readonly Label[] manaCounterLabeles  = new Label[ColumnCount];

        private readonly int ColWidth;
        private readonly int ColMaxHeight;

        // Используем readonly, так как это неизменяемые значения
        private readonly Panel manaColumnPanel = new();

        // Массивы для максимального и текущего маны. Выносим их в константы или настраиваемые значения
        private readonly float[] maxMana = [10, 20, 30, 40];
        private readonly float[] currentMana = [5, 10, 15, 20];

        // Индексатор для доступа к максимальной мане
        public float this[EManaType manaType, bool isMaxMana]
        {

            get
            {
                var manaIndex = ManaOrder[manaType];

                return isMaxMana ? maxMana[manaIndex] : currentMana[manaIndex];
            }
            set
            {
                if (value < 0)
                    throw new IndexOutOfRangeException("Value is out of range.");

                var reciver = isMaxMana? maxMana : currentMana;
                var manaIndex = ManaOrder[manaType];
                reciver[manaIndex] = value;
                manaCounterLabeles[manaIndex].Text = value.ToString();
                manaColumnPanel.Invalidate();
            }
        }

        // Массив цветов, чтобы избежать повторяющихся элементов
        private readonly (Color Current, Color Max)[] manaColors =
        [
            (Color.LightGreen, Color.Green),
            (Color.Red, Color.Red),
            (Color.Gold, Color.Goldenrod),
            (Color.SkyBlue, Color.DodgerBlue),
        ];
        private readonly Blend maxBlend = new()
        {
            Factors = [0.7f, 0.9f, 0.7f],
            Positions = [0.0f, 0.5f, 1.0f]
        };
        private readonly Blend currentBlend = new()
        {
            Factors = [0.7f, 0.0f, 0.7f],
            Positions = [0.0f, 0.5f, 1.0f]
        };

        public ManaPanel()
        {
            // Вынесена инициализация в метод
            InitializeManaPanel();
            // Изменены вычисления для ColWidth и ColMaxHeight для правильной обработки
            ColWidth = (manaColumnPanel.Width - HorPadding * (ColumnCount - 1)) / ColumnCount;
            ColMaxHeight = manaColumnPanel.Height;
            InitializeStonesImages();
            InitializeCounterLabeles();
        }

        private void InitializeManaPanel()
        {
            var workArea = new Size(Panel.Width - 2, Panel.Height - 2);
            manaColumnPanel.Size = new Size(workArea.Width - HorPadding * 2, workArea.Height - TopPadding - DownPadding);
            manaColumnPanel.Location = new Point(HorPadding, TopPadding);
            manaColumnPanel.BackColor = Color.FromArgb(25, 23, 24);
            manaColumnPanel.Paint += DrawColumns;
            Panel.Controls.Add(manaColumnPanel);
        }
        private void InitializeStonesImages()
        {
            EStoneType[] stoneOrder = [EStoneType.EarthStone, EStoneType.FireStone, EStoneType.AirStone, EStoneType.WaterStone];
            var size = new Size(ColWidth, ColWidth);
            int yPox = TopPadding * 2 + manaColumnPanel.Height;
            for (int i = 0; i < ColumnCount; i++)
            {
                int xPos = HorPadding + i * (ColWidth + HorPadding);

                var stonePictureBox = new PictureBox()
                {
                    Size = size,
                    Location = new Point(xPos, yPox),
                    Image = StoneImages[stoneOrder[i]],
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                Panel.Controls.Add(stonePictureBox);
            }
        }
        private void InitializeCounterLabeles()
        {
            int yPox = TopPadding * 2 + manaColumnPanel.Height + ColWidth +2;
            var size = new Size(ColWidth + HorPadding, Panel.Height - yPox);

            for (int i = 0; i < ColumnCount; i++)
            {
                int xPos = HorPadding / 2 + i * (ColWidth + HorPadding);

                var counterLabel = new Label
                {
                    Size = size,
                    Location = new Point(xPos, yPox),
                    Font = new Font("Century Gothic", 12F, FontStyle.Bold),
                    ForeColor = SystemColors.ControlLight,
                    Text = "999",
                    TextAlign = ContentAlignment.TopCenter,
                };
                Panel.Controls.Add(counterLabel);
                manaCounterLabeles[i] = counterLabel;
            }
        }


        private void DrawColumns(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Максимальное значение для нормализации высот
            float maxValue = maxMana.Max();

            // Рисуем столбцы
            for (int i = 0; i < ColumnCount; i++)
            {
                int currentManaHeight = (int)Math.Round(currentMana[i] / maxValue * ColMaxHeight);
                int maxManaHeight = (int)Math.Round(maxMana[i] / maxValue * ColMaxHeight);

                // Рисуем столбец с двумя уровнями (текущая и максимальная мана)

                // Определение цвета для текущего и максимального столбцов
                var currentColor = manaColors[i].Current;
                var maxColor = manaColors[i].Max;

                // Рисуем максимальный столбец
                DrawSingleColumn(graphics, i, maxManaHeight, maxColor, maxBlend);

                // Рисуем текущий столбец
                DrawSingleColumn(graphics, i, currentManaHeight, currentColor, currentBlend);
            }
        }
        private void DrawSingleColumn(Graphics graphics, int colIndex, int colHeight, Color centerColor, Blend blend)
        {
            // Вычисление координат
            int xPos = (ColWidth + HorPadding) * colIndex;
            int ellYPos = ColMaxHeight - colHeight;
            int recYPos = ellYPos + ColWidth / 2;

            // Рисование с использованием LinearGradientBrush
            using var gradientBrush = new LinearGradientBrush(
                new Point(xPos, ellYPos),
                new Point(xPos + ColWidth, ellYPos),
                centerColor,
                Color.FromArgb(25, 23, 24)
            )
            {
                Blend = blend
            };
            // Рисуем элипс и прямоугольник
            graphics.FillEllipse(gradientBrush, xPos, ellYPos, ColWidth, ColWidth);
            graphics.FillRectangle(gradientBrush, xPos, recYPos, ColWidth, colHeight);
        }
    }
}
