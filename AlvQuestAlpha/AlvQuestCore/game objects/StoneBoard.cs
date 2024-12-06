using System.Diagnostics;

namespace AlvQuestCore
{
    public class StoneGridData
    {
        /// <summary>
        /// Список всех комбинаций на сетке камней <see cref='StoneBoard.StoneGrid'/>, где:
        /// <para><see cref='EStoneType'/> - тип камней комбинации,</para>
        /// <para><see cref='int'/> - длина комбинации.</para>
        /// </summary>
        public List<(EStoneType StoneType, int Length)> OnFieldCombinations { get; } = new();

        /// <summary>
        /// Координаты каждого камня комбинаций.
        /// </summary>
        public Dictionary<(int X, int Y), EStoneType> OnFieldCombinedStones { get; } = new();

        public Dictionary<EStoneType, int> AmountOfCombinedStones = new()
        {
            { EStoneType.Gold, 0 },
            { EStoneType.Experience, 0 },
            { EStoneType.FireStone, 0 },
            { EStoneType.WaterStone, 0 },
            { EStoneType.EarthStone, 0 },
            { EStoneType.AirStone, 0 },
            { EStoneType.Skull, 0 },
        };
    }

    /// <summary>
    /// Доска камней.
    /// </summary>
    public class StoneBoard  
    {
        #region События
        private void InvokeEvent<T>(EventHandler<T> eventHandler, T args) // Метод для событий типа EventHandler<T>
        {
            eventHandler?.Invoke(this, args);
        }
        private void InvokeEvent(EventHandler eventHandler) // Метод для событий типа EventHandler
        {
            eventHandler?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Вызывается при установке состояния "выбран" для камня.
        /// </summary>
        public event EventHandler<(int X, int Y, bool IsSelected)> StoneSelectionChanged;
        /// <summary>
        /// Вызывается при обновлении состояния доски камней.
        /// </summary>
        public event EventHandler StonesPositionsChanged;
        /// <summary>
        /// Вызывается при уничтожении набора камней на доске.
        /// </summary>
        public event EventHandler<(int X, int Y)[]> StonesDestroyed;
        /// <summary>
        /// Вызывается, когда игрок вызвал обмен двух сосдених камней местами
        /// </summary>
        public event EventHandler<((int X, int Y) a, (int X, int Y) b)> StonePairSwapped;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler TurnFinished;
        #endregion

        #region Поля
        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private readonly Random _random = new(1);

        /// <summary>
        /// Координаты первого выбранного камня
        /// </summary>
        private (int X, int Y) _firstPos = (-1, -1);

        /// <summary>
        /// Координаты второго выбранного камня
        /// </summary>
        private (int X, int Y) _secondPos = (-1, -1);

        /// <summary>
        /// Статистические данные по текущему состояния сетки камней.
        /// </summary>
        public StoneGridData StoneGridData { get; set; }

        /// <summary>
        /// Сетка на которой расположены камни из набора <see cref='EStoneType'/>.
        /// </summary>
        public EStoneType[,] StoneGrid { get; private set; }
        #endregion

        #region Методы
        /// <summary>
        /// Установка нового стартового состояния сетки камней из набора <see cref='EStoneType'/>.
        /// </summary>
        public void ResetStoneGrid()
        {
            var gridSize = AlvQuestStatic.STONE_GRID_SIZE;
            do
            {
                // Выделяем память
                StoneGrid = new EStoneType[gridSize, gridSize];
                // Генерируем поле камней
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        StoneGrid[i, j] = GetNewStartStone(i, j);
                    }
                }
                // Если поле сгенерировалось так, что на нём нет комбинаций - генерируем заново.
            } while (!CheckCombinationCreationPossibility());

            InvokeEvent(StonesPositionsChanged);
        }

        /// <summary>
        /// Возвращает новый камень для очередной клетки во время работы <see cref='ResetStoneGrid()'/>.
        /// </summary>n
        /// <param name="x">X координата камня в сетке <see cref='StoneGrid'/>.</param>
        /// <param name="y">Y координата камня в сетке <see cref='StoneGrid'/>.</param>
        /// <returns>Тип очередного камня из набора <see cref='EStoneType'/>,
        /// гарантирующий отсутвие комбинаций на стартовом состоянии <see cref='StoneGrid'/>.</returns>
        private EStoneType GetNewStartStone(int x, int y)
        {
            EStoneType newStone;

            do
            {
                newStone = GetRandomStone();
            }
            while ((y > 1 && newStone == StoneGrid[x, y - 1] && newStone == StoneGrid[x, y - 2]) ||
                   (x > 1 && newStone == StoneGrid[x - 1, y] && newStone == StoneGrid[x - 2, y]));

            return newStone;
        }

        /// <summary>
        /// Возвращает случайный камень из набора <see cref='EStoneType'/>.
        /// </summary>
        /// <returns>Тип камня.</returns>
        private EStoneType GetRandomStone()
        {
            return (EStoneType)_random.Next(1, 8);
        }

        /// <summary>
        /// Проверяет наличие хотя бы одного возможного хода для составления комбинации на поле.</summary>
        /// <returns><see cref="bool"/> <c>true</c>, если существует хотя бы однин ход, иначе <see cref="bool"/> <c>false</c>.</returns>
        private bool CheckCombinationCreationPossibility()
        {
            var gridSize = AlvQuestStatic.STONE_GRID_SIZE;

            // Координаты смещений для получения соседей камня
            int[] offsetX = [-1, 0, 0, 1];
            int[] offsetY = [0, 1, -1, 0];

            // Выбираем камни в шахматном порядке.
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = i % 2; j < gridSize; j += 2)
                {
                    // Для каждого возможного соседа:
                    for (int k = 0; k < 4; k++)
                    {
                        // Вычисляем координаты
                        int x = i + offsetX[k];
                        int y = j + offsetY[k];

                        // Если координаты не выходят за границы сетки:
                        if (x >= 0 && x < gridSize && y >= 0 && y < gridSize)
                        {
                            if (CanCreateCombinationAfterSwap(i, j, x, y))
                            {
                                return true; // Если комбинация найдена, выходим
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Проверяет, можно ли создать комбинацию после обмена камней на указанных позициях.
        /// </summary>
        /// <param name="x1">Индекс строки исходной клетки для первого камня.</param>
        /// <param name="y1">Индекс столбца исходной клетки для первого камня.</param>
        /// <param name="x2">Индекс строки соседней клетки, с которой будет происходить обмен.</param>
        /// <param name="y2">Индекс столбца соседней клетки, с которой будет происходить обмен.</param>
        /// <returns>
        /// <see cref="bool"/> <c>true</c>, если после обмена камней образуется хотя бы одна комбинация (горизонтальная или вертикальная), 
        /// иначе <see cref="bool"/> <c>false</c>.
        /// </returns>
        /// <remarks>
        /// Метод меняет местами камни в клетках (x1, y1) и (x2, y2), проверяет наличие комбинации в горизонтальном и вертикальном направлении для обеих клеток,
        /// и затем возвращает камни на исходные позиции. Если после обмена комбинация обнаружена, метод возвращает <c>true</c>, иначе <c>false</c>.
        /// </remarks>
        private bool CanCreateCombinationAfterSwap(int x1, int y1, int x2, int y2)
        {
            SwapStones(x1, y1, x2, y2, StoneGrid); // Меняем камни местами
            bool matchFound = CheckCombinations(x1, y1) || CheckCombinations(x2, y2);
            SwapStones(x1, y1, x2, y2, StoneGrid); // Возвращаем камни обратно
            return matchFound;
        }

        /*/// <summary>
        /// Проверяет, есть ли комбинации камней в вертикальном и горизонтальном направлениях для заданной клетки.
        /// </summary>
        /// <param name="x">Индекс по оси X для текущей клетки.</param>
        /// <param name="y">Индекс по оси Y для текущей клетки.</param>
        /// <param name="markCombinedStones">Флаг, указывающий, нужно ли помечать камни, участвующие в комбинации.</param>
        /// <returns>Возвращает <c>true</c>, если комбинация камней найдена, иначе <c>false</c>.</returns>
        private bool CheckCombinationsLegacy(int x, int y, bool markCombinedStones = false)
        {
            EStoneType stoneType = StoneGrid[x, y];
            int offset;
            int leftBorder = x;
            int rightBorder = x;
            int upBorder = y;
            int bottomBorder = y;

            // Проверяем камни слева
            offset = x - 1;
            while (offset >= 0 && StoneGrid[offset, y] == stoneType)
            {
                leftBorder = offset;
                offset--;
            }
            // Проверяем камни справа
            offset = x + 1;
            while (offset < AlvQuestStatic.STONE_GRID_SIZE && StoneGrid[offset, y] == stoneType)
            {
                rightBorder = offset;
                offset--;
            }
            // Проверяем камни сверху
            offset = y - 1;
            while (offset >= 0 && StoneGrid[x, offset] == stoneType)
            {
                upBorder = offset;
                offset--;
            }
            // Проверяем камни снизу
            offset = y + 1;
            while (offset < AlvQuestStatic.STONE_GRID_SIZE && StoneGrid[x, offset] == stoneType)
            {
                bottomBorder = offset;
                offset++;
            }

            int horizontalCombinationLength = Math.Abs(rightBorder - leftBorder) + 1;
            int verticalCombinationLength = Math.Abs(upBorder - bottomBorder) + 1;

            if(markCombinedStones) // Если требуется записать камни, участвующие в комбинации
            {
                if (horizontalCombinationLength > 2)
                {
                    for (int i = leftBorder; i <= rightBorder; i++)
                    {
                        StoneGridData.OnFieldCombinedStones.TryAdd((i, y), stoneType);
                    }
                    StoneGridData.OnFieldCombinations.Add((stoneType, horizontalCombinationLength));
                }
                if (verticalCombinationLength > 2)
                {
                    for (int i = upBorder; i <= bottomBorder; i++)
                    {
                        StoneGridData.OnFieldCombinedStones.TryAdd((x, i), stoneType);
                    }
                    StoneGridData.OnFieldCombinations.Add((stoneType, verticalCombinationLength));
                }
            }
            return horizontalCombinationLength > 2 || verticalCombinationLength > 2;
        }*/

        /// <summary>
        /// Проверяет, есть ли комбинации камней в вертикальном и горизонтальном направлениях для заданной клетки.
        /// </summary>
        /// <param name="x">Индекс по оси X для текущей клетки.</param>
        /// <param name="y">Индекс по оси Y для текущей клетки.</param>
        /// <param name="markCombinedStones">Флаг, указывающий, нужно ли помечать камни, участвующие в комбинации.</param>
        /// <returns>Возвращает <c>true</c>, если комбинация камней найдена, иначе <c>false</c>.</returns>
        private bool CheckCombinations(int x, int y, bool markCombinedStones = false)
        {
            EStoneType stoneType = StoneGrid[x, y];

            if (stoneType == EStoneType.None) return false;

            var horizontalMatches = GetLineMatches(x, y, -1, 0).Concat(GetLineMatches(x, y, 1, 0)).Distinct().ToList();
            var verticalMatches = GetLineMatches(x, y, 0, -1).Concat(GetLineMatches(x, y, 0, 1)).Distinct().ToList();

            bool hasCombination = horizontalMatches.Count >= 3 || verticalMatches.Count >= 3;

            if (markCombinedStones && hasCombination)
            {
                if (horizontalMatches.Count >= 3)
                    MarkStones(horizontalMatches, stoneType);

                if (verticalMatches.Count >= 3)
                    MarkStones(verticalMatches, stoneType);
            }

            return hasCombination;
        }

        /// <summary>
        /// Ищет границы совпадений камней в заданном направлении относительно текущей клетки.
        /// </summary>
        /// <param name="x">Индекс по оси X для текущей клетки.</param>
        /// <param name="y">Индекс по оси Y для текущей клетки.</param>
        /// <param name="dx">Изменение по оси X для направления поиска.</param>
        /// <param name="dy">Изменение по оси Y для направления поиска.</param>
        /// <returns>Возвращает список позиций совпадающих камней в заданном направлении.</returns>
        private List<(int, int)> GetLineMatches(int x, int y, int dx, int dy)
        {
            List<(int, int)> matches = [(x, y)];
            int newX = x + dx, newY = y + dy;

            while (IsValid(newX, newY) && StoneGrid[newX, newY] == StoneGrid[x, y])
            {
                matches.Add((newX, newY));
                newX += dx;
                newY += dy;
            }

            return matches;
        }

        /// <summary>
        /// Помечает камни, участвующие в комбинации, в соответствии с их позицией и типом.
        /// </summary>
        /// <param name="positions">Список позиций камней, которые входят в комбинацию.</param>
        /// <param name="stoneType">Тип камня, участвующего в комбинации.</param>
        private void MarkStones(List<(int, int)> positions, EStoneType stoneType)
        {
            foreach (var (x, y) in positions)
            {
                if (StoneGridData.OnFieldCombinedStones.TryAdd((x, y), stoneType))
                {
                    StoneGridData.AmountOfCombinedStones[stoneType]++;
                }
            }
            StoneGridData.OnFieldCombinations.Add((stoneType, positions.Count));
        }

        /// <summary>
        /// Проверяет, являются ли заданные координаты валидными в пределах игрового поля.
        /// </summary>
        /// <param name="x">Индекс по оси X, который нужно проверить.</param>
        /// <param name="y">Индекс по оси Y, который нужно проверить.</param>
        /// <returns>Возвращает <c>true</c>, если координаты находятся в пределах допустимого диапазона, иначе <c>false</c>.</returns>
        private static bool IsValid(int x, int y)
        {
            return x >= 0 && x < AlvQuestStatic.STONE_GRID_SIZE && y >= 0 && y < AlvQuestStatic.STONE_GRID_SIZE;
        }

        /// <summary>
        /// Точка входа в подсистему доски камней. Реализует клик игрока по камню.
        /// </summary>
        /// <param name="x">X координата выбранного камня в сетке <see cref='StoneGrid'/>.</param>
        /// <param name="y">Y координата выбранного камня в сетке <see cref='StoneGrid'/>.</param>
        public void StoneClick(int x, int y)
        {
            // Координаты новой выбранной точки
            (int X, int Y) newPos = (x, y);
            // Если первая позиция не была выбрана.
            if (_firstPos.X == -1)
            {
                // Выбранная позиция становится первой
                SelectStone(x, y, ref _firstPos);
            } // Если новая позиция отлична от первой 
            else if (newPos != _firstPos)
            {
                // Вычисляем Манхэттенское расстояние между камнями
                var distance = Math.Abs(_firstPos.X - newPos.X) + Math.Abs(_firstPos.Y - newPos.Y);

                //Если камни соседние 
                if (distance == 1)
                {
                    // Выбранная позиция становится второй
                    SelectStone(x, y, ref _secondPos);
                    // Производится ход
                    ExecuteStoneSwappingTurn();
                }
                else
                {
                    //Выбранная точка становится новой первой
                    SelectStone(x, y, ref _firstPos);
                }
            }
        }

        /// <summary>
        /// Логика выбора камня.
        /// </summary>
        private void SelectStone(int x, int y, ref (int X, int Y) pos)
        {
            // Если камень был выбран ранее , снимаем выделение с предыдущего
            if (pos.X != -1)
            {
                InvokeEvent(StoneSelectionChanged, (pos.X, pos.Y, IsSelected: false));
            }

            // Обновляем позицию выбранного камня
            pos = (x, y);

            // Устанавливаем новый камень как выбранный
            InvokeEvent(StoneSelectionChanged, (x, y, IsSelected: true));
        }

        /// <summary>
        /// Обмен двух соседних камней местами.
        /// </summary>
        /// <param name="x1">X координата первого камня.</param>
        /// <param name="y1">Y координата первого камня.</param>
        /// <param name="x2">X координата второго камня.</param>
        /// <param name="y2">Y координата второго камня.</param>
        /// <param name="stoneGrid">Сетка, на которой расположены камни</param>
        private static void SwapStones(int x1, int y1, int x2, int y2, EStoneType[,] stoneGrid)
        {
            (stoneGrid[x1, y1], stoneGrid[x2, y2]) = (stoneGrid[x2, y2], stoneGrid[x1, y1]);
        }

        /// <summary>
        /// Реализация хода игрока.
        /// </summary>
        private void ExecuteStoneSwappingTurn()
        {
            // Реализуем обмен двух выбранных камней местами
            InitStoneSwapping();

            // Пока на доске существует хотя бы одна комбинация:
            while (TryFindStoneCombinations())
            {
                // Уничтожем скомбинированные камни
                DestroyCombinedStones();

                // Вызываем событие об уничтожении камней
                InvokeEvent(StonesDestroyed, [.. StoneGridData.OnFieldCombinedStones.Keys]);

                // Вызываем падение камней под силой гравитации
                StonesFreeFall();

                // Вызываем событие об обновлении состояния доски
                InvokeEvent(StonesPositionsChanged);
            }
            InvokeEvent(TurnFinished);

            // Если после выпадения камней на поле не осталось комбинаций
            if (!CheckCombinationCreationPossibility())
            {
                // Сбасываем состояние доски
                ResetStoneGrid();
            }
        }
        
        /// <summary>
        /// Меняет два выбранных камня местами и сбрасывает запомненные точки
        /// </summary>
        private void InitStoneSwapping()
        {
            // Меняем выбранные камни местами
            SwapStones(_firstPos.X, _firstPos.Y, _secondPos.X, _secondPos.Y, StoneGrid);
            InvokeEvent(StonePairSwapped, (_firstPos, _secondPos));
            // Сбрасываем запомненные координаты
            _firstPos = (-1, -1);
            _secondPos = (-1, -1);
        }

        /// <summary>
        /// Пробует записать в <see cref='StoneGridData'/> все комбинации камней и координаты составляющих их камней в сетке <see cref='StoneGrid'/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c>, если была записана хотя бы одна комбинация, иначе <see cref="bool"/> <c>false</c>.</returns>
        public bool TryFindStoneCombinations()
        {
            StoneGridData = new();
            bool isAnyMatches = false;
            for (int i = 0; i < AlvQuestStatic.STONE_GRID_SIZE; i++)
            {
                for (int j = 0; j < AlvQuestStatic.STONE_GRID_SIZE; j++)
                {
                    if (!StoneGridData.OnFieldCombinedStones.ContainsKey((i, j)))
                    {
                        if (CheckCombinations(i, j, markCombinedStones: true))
                        {
                            isAnyMatches = true;
                        }
                    }
                }
            }
            return isAnyMatches;
        }

        /// <summary>
        /// Помечает все камни, являющиеся элементами комбинаций, как уничтоженные.
        /// </summary>
        private void DestroyCombinedStones()
        {
            var combinedStones = StoneGridData.OnFieldCombinedStones.Keys.ToArray();
            foreach (var (x, y) in combinedStones)
            {
                StoneGrid[x,y] = EStoneType.None;
            }
        }

        /// <summary>
        /// Реализует падение камней вниз, а так же выпадение новых камней в освободившиеся верхние ячейки.
        /// </summary>
        private void StonesFreeFall()
        {
            int gridSize = AlvQuestStatic.STONE_GRID_SIZE;

            // Идём по столбцам слева направо
            for (int i = 0; i < gridSize; i++)
            {
                // Новое состояние столбца
                // currentColumn[0] соответствует самому нижнему камню столбца
                EStoneType[] currentColumn = new EStoneType[gridSize];
                int counter = 0;

                // Идём по столбцу снизу вверх
                for (int j = gridSize - 1; j >= 0; j--)
                {
                    var currentStone = StoneGrid[j, i];
                    // "Прижимаем" все существующие камни вниз столбца
                    if (currentStone != EStoneType.None)
                    {
                        currentColumn[counter] = currentStone;
                        counter++;
                    }
                }

                // Генерируем новые случайные камни в освободившиеся верхние ячейки
                for (int k = counter; k < gridSize; k++)
                {
                    currentColumn[k] = GetRandomStone();
                }

                // Обновляем игровой массив столбца
                for (int j = 0; j < gridSize; j++)
                {
                    StoneGrid[j, i] = currentColumn[gridSize - 1 - j];
                }
            }
        }
        #endregion
    }
}
