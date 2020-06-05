using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Elementary2Life
{
    public class Algorithm : IDisposable
    {
        private readonly int _boardWidth;

        private readonly int _boardHeight;

        private readonly Bitmap _screen;

        private readonly Bitmap _render;

        private readonly int[] _pixels;

        private GCHandle _handle;

        private int _color;

        private bool[,] _current;

        private bool[,] _previous;

        public Algorithm(int boardWidth, int boardHeight, int cellSize)
        {
            if (boardWidth < 3)
                throw new ArgumentOutOfRangeException(nameof(boardWidth));
            if (boardHeight < 3)
                throw new ArgumentOutOfRangeException(nameof(boardHeight));
            
            _boardWidth = boardWidth;
            _boardHeight = boardHeight;

            _screen = new Bitmap(_boardWidth * cellSize, _boardHeight * cellSize);
            
            _pixels = new int[_boardWidth * _boardHeight];
            _handle = GCHandle.Alloc(_pixels, GCHandleType.Pinned);
            _render = new Bitmap(_boardWidth, _boardHeight, _boardWidth * 4, PixelFormat.Format32bppArgb, _handle.AddrOfPinnedObject());

            _color = -7357301;
            Rule = 30;
            Init();
        }

        public int Rule { get; private set; }

        public Image Screen => _screen;

        public Color Color => Color.FromArgb(_color);

        public void Dispose()
        {
            _screen.Dispose();
            _render.Dispose();
            _handle.Free();
        }

        public void ChangeRule(int rule)
        {
            if ((uint)rule > 255)
                throw new ArgumentOutOfRangeException(nameof(rule));
            Rule = rule;
            Init();
        }

        public void ChangeColor(Color color)
        {
            _color = color.ToArgb();
            Init();
        }

        public void Transform()
        {
            var flip = _current;
            _current = _previous;
            _previous = flip;

            Parallel.For(0, _boardHeight - 1, y =>
              {
                  for (var x = 0; x < _boardWidth; x++)
                  {
                      _current[y, x] = LifeCellState(_previous, y, x);
                  }
              });

            for (var x = 0; x < _boardWidth; x++)
            {
                _current[_boardHeight - 1, x] = ElementaryCellState(_previous, Rule, _boardHeight - 1, x);
            }

            for (var y = 0; y < _boardHeight; y++)
            {
                for (var x = 0; x < _boardWidth; x++)
                {
                    _pixels[y * _boardWidth + x] = _current[y, x] ? _color : 83886080;
                }
            }

            using (var graphics = Graphics.FromImage(_screen))
            {
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.DrawImage(_render, 0, 0, _screen.Width, _screen.Height);
            }
        }

        private static bool LifeCellState(bool[,] state, int y, int x)
        {
            var left = x == 0 ? state.GetLength(1) - 1 : x - 1;
            var right = x == state.GetLength(1) - 1 ? 0 : x + 1;

            var count = 0;

            if (y != 0)
            {
                if (state[y - 1, left]) count++;
                if (state[y - 1, x]) count++;
                if (state[y - 1, right]) count++;
            }

            if (y != state.GetLength(0) - 1)
            {
                if (state[y + 1, left]) count++;
                if (state[y + 1, x]) count++;
                if (state[y + 1, right]) count++;
            }

            if (state[y, left]) count++;
            if (state[y, right]) count++;

            return state[y, x] ? count == 2 || count == 3 : count == 3;
        }

        private static bool ElementaryCellState(bool[,] state, int rule, int y, int x)
        {
            var left = x == 0 ? state.GetLength(1) - 1 : x - 1;
            var right = x == state.GetLength(1) - 1 ? 0 : x + 1;
            var i = 0;
            if (state[y, left])
                i |= 1 << 2;
            if (state[y, x])
                i |= 1 << 1;
            if (state[y, right])
                i |= 1;
            return (rule & (1 << i)) != 0;
        }

        private void Init()
        {
            _current = new bool[_boardHeight, _boardWidth];
            _previous = new bool[_boardHeight, _boardWidth];
            _current[_boardHeight - 1, _boardWidth / 2] = true;
            using (var graphics = Graphics.FromImage(_screen))
            {
                graphics.Clear(Color);
            }
        }
    }
}