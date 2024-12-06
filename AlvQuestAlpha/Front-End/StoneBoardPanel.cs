using AlvQuestCore;

namespace AlvQuestAlpha.FrontEnd
{
    public class StoneBoardPanel : Panel
    {
        public class CellPictureBox : PictureBox
        {
            public int Row { get; set; } = -1;
            public int Col { get; set; } = -1;
            public int StoneId { get; set; } = -1;
        }

        private const int SleepTime = 500;
        private void InitAnimationStep()
        {
            Update();
            Thread.Sleep(SleepTime);
        }

        private const int PanelSize = 1000;
        private const int GridSize = 8;
        private const int CellSize = PanelSize / GridSize;

        private static readonly Color BaseColor = Color.FromArgb(25, 23, 24);
        private static readonly Color CelectedColor = Color.Gray;
        private static readonly Color DestroyedColor = Color.LightGray;
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

        private readonly CellPictureBox[,] Grid = new CellPictureBox[GridSize, GridSize]; // Двумерный массив для хранения ссылок на PictureBox

        private StoneBoard StoneBoard;

        public StoneBoardPanel()
        {
            Size = new Size(PanelSize, PanelSize);
            FillGrid();
        }

        

        private void FillGrid()
        {
            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    CellPictureBox pictureBox = new CellPictureBox
                    {
                        Size = new Size(CellSize, CellSize),
                        Location = new Point(col * CellSize, row * CellSize),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = BaseColor,
                        Row = row,
                        Col = col,
                    };
                    pictureBox.MouseDown += CellPictureBox_MouseClick;
                    Grid[row, col] = pictureBox;
                    Controls.Add(pictureBox);
                }
            }
        }

        public void InstallStoneBoard(StoneBoard stoneBoard)
        {
            StoneBoard = stoneBoard;
            StoneBoard.StoneSelectionChanged += OnStoneSelectionChanged;
            StoneBoard.StonesPositionsChanged += UpdateStonesPositions;
            StoneBoard.StonesDestroyed += MarkCombinedStones;
            StoneBoard.StonePairSwapped += SwapCombinedStones;
            StoneBoard.TurnFinished += ResetCellsBackColors;
            StoneBoard.ResetStoneGrid();
        }

        private void CellPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is CellPictureBox stonePictureBox)
            {
                int row = stonePictureBox.Row;
                int col = stonePictureBox.Col;
                StoneBoard.StoneClick(row, col);
            }
        }

        private void OnStoneSelectionChanged(object sender, (int X, int Y, bool IsSelected) e)
        {
            (int row, int col, bool isSelected) = e;
            if (row >= 0 && row < GridSize && col >= 0 && col < GridSize)
            {
                Grid[row, col].BackColor = isSelected ? CelectedColor : BaseColor;
                Grid[row, col].Update();
            }
        }

        private void UpdateStonesPositions(object sender, EventArgs e)
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    UpdateStonePictureBox(i, j);
                }
            }
            InitAnimationStep();
        }

        private void UpdateStonePictureBox(int row, int col)
        {
            EStoneType stoneType = StoneBoard.StoneGrid[row, col];
            var pictureBox = Grid[row, col];

            if (pictureBox.StoneId != (int)stoneType)
            {
                pictureBox.Image = StoneImages[stoneType];
                pictureBox.StoneId = (int)stoneType;
            }
        }

        private void SwapCombinedStones(object sender, ((int X, int Y) a, (int X, int Y) b) pair)
        {
            // Деконструкция на переменные
            var ((aX, aY), (bX, bY)) = pair;
            var a = Grid[aX, aY];
            var b = Grid[bX, bY];

            InitAnimationStep();
            UpdateStonePictureBox(aX, aY);
            UpdateStonePictureBox(bX, bY);
            a.BackColor = BaseColor;
            b.BackColor = BaseColor;
            Update();
        }

        private void MarkCombinedStones(object sender, (int X, int Y)[] e)
        {
            foreach (var (x, y) in e)
            {
                Grid[x, y].BackColor = DestroyedColor;
            }
            InitAnimationStep();
            foreach (var (x, y) in e)
            {
                Grid[x, y].Image = null;
                Grid[x, y].StoneId = -1;
            }
            InitAnimationStep();
        }

        private void ResetCellsBackColors(object sender, EventArgs e)
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Grid[i, j].BackColor = BaseColor;
                }
            }
        }
    }
}
