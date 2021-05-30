﻿using System.Collections.Generic;
using System.Drawing;
using static TetrisLogic.SystemProperty;

namespace TetrisLogic
{
    public class Block
    {
        public BlockType BlockType { get; private set; }

        public Point Location { get { return _location; } }

        // 現在ブロック
        private int[,] _block;
        private Point _location;

        public Block(BlockType bt)
        {
            BlockType = bt;
            switch(bt)
            {
                case BlockType.O:
                    _block = CreateBlockO();
                    break;
                case BlockType.I:
                    _block = CreateBlockI();
                    break;
                case BlockType.T:
                    _block = CreateBlockT();
                    break;
                case BlockType.J:
                    _block = CreateBlockJ();
                    break;
                case BlockType.L:
                    _block = CreateBlockL();
                    break;
                case BlockType.Z:
                    _block = CreateBlockZ();
                    break;
                case BlockType.S:
                    _block = CreateBlockS();
                    break;
                default:
                    _block = new int[SystemProperty.BlockWidth, SystemProperty.BlockHeight];
                    break;
            }
            _location = BlockType == BlockType.I ? new Point(3, 0) : new Point(3, -1);
        }

        public void ResetLocation()
        {
            _location = new Point(3, 0);
        }

        public void MoveLocation(int x,int y)
        {
            _location = new Point(_location.X + x, _location.Y + y);
        }

        public void Rotate(int rad)
        {
            var a = rad;
            _block = new int[_block.GetLength(0), _block.GetLength(1)];
        }

        public List<Point> GetBlockPoints()
        {
            var points = new List<Point>();
            for (var y = 0; y < BlockHeight; y++)
            {
                for (int x = 0; x < BlockWidth; x++)
                {
                    if (_block[x, y] == 1)
                    {
                        points.Add(new Point(x + _location.X, y + _location.Y));
                    }
                }
            }

            return points;
        }

        public List<Point> GetBlockBottomPoints()
        {
            var points = new List<Point>();
            for (int x = 0; x < BlockWidth; x++)
            {
                for (var y = BlockHeight - 1; y >= 0; y--)
                {
                    if (_block[x, y] == 1)
                    {
                        points.Add(new Point(x + _location.X, y + _location.Y));
                        break;
                    }
                }
            }

            return points;
        }

        public Point GetLocation_BlockTop()
        {
            for (var y = 0; y < SystemProperty.BlockHeight; y++)
            {
                for (int x = 0; x < SystemProperty.BlockWidth; x++)
                {
                    if (_block[x, y] == 1)
                    {
                        return new Point(x + _location.X, y + _location.Y);
                    }
                }
            }

            return new Point(-1, -1);
        }

        public Point GetGetLocation_BlockBottom()
        {
            for (var y = BlockHeight - 1; y >= 0; y--)
            {
                for (int x = 0; x < BlockWidth; x++)
                {
                    if (_block[x, y] == 1)
                    {
                        return new Point(x + _location.X, y + _location.Y);
                    }
                }
            }

            return new Point(-1, -1);
        }

        public Point GetLocation_BlockLeft()
        {
            for (int x = 0; x < SystemProperty.BlockWidth; x++)
            {
                for (var y = 0; y < SystemProperty.BlockHeight; y++)
                {
                    if (_block[x, y] == 1)
                    {
                        return new Point(x + _location.X, y + _location.Y);
                    }
                }
            }

            return new Point(-1, -1);
        }

        public Point GetLocation_BlockRight()
        {
            for (int x = SystemProperty.BlockWidth - 1; x >= 0; x--)
            {
                for (var y = 0; y < SystemProperty.BlockHeight; y++)
                {
                    if (_block[x, y] == 1)
                    {
                        return new Point(x + _location.X, y + _location.Y);
                    }
                }
            }

            return new Point(-1, -1);
        }

        /// <summary>
        /// □□□□
        /// □■■□ 
        /// □■■□ 
        /// □□□□ 
        /// </summary>
        /// <returns></returns>
        private int[,] CreateBlockO()
        {
            var rect = new int[SystemProperty.BlockWidth, SystemProperty.BlockHeight];
            rect[1, 1] = 1;
            rect[1, 2] = 1;
            rect[2, 1] = 1;
            rect[2, 2] = 1;
            return rect;
        }

        /// <summary>
        /// □■□□
        /// □■□□
        /// □■□□ 
        /// □■□□
        /// </summary>
        /// <returns></returns>
        private int[,] CreateBlockI()
        {
            var rect = new int[SystemProperty.BlockWidth, SystemProperty.BlockHeight];
            rect[1, 0] = 1;
            rect[1, 1] = 1;
            rect[1, 2] = 1;
            rect[1, 3] = 1;
            return rect;
        }

        /// <summary>
        ///□□□□
        ///□■□□
        ///□■■□
        ///□■□□
        /// </summary>
        /// <returns></returns>
        private int[,] CreateBlockT()
        {
            var rect = new int[SystemProperty.BlockWidth, SystemProperty.BlockHeight];
            rect[1, 1] = 1;
            rect[1, 2] = 1;
            rect[2, 2] = 1;
            rect[1, 3] = 1;
            return rect;
        }

        /// <summary>
        ///□□□□ 
        ///□■■□ 
        ///□■□□ 
        ///□■□□ 
        /// </summary>
        /// <returns></returns>
        private int[,] CreateBlockJ()
        {
            var rect = new int[SystemProperty.BlockWidth, SystemProperty.BlockHeight];
            rect[1, 1] = 1;
            rect[2, 1] = 1;
            rect[1, 2] = 1;
            rect[1, 3] = 1;
            return rect;
        }

        /// <summary>
        ///□□□□ 
        ///□■■□ 
        ///□□■□ 
        ///□□■□ 
        /// </summary>
        /// <returns></returns>
        private int[,] CreateBlockL()
        {
            var rect = new int[SystemProperty.BlockWidth, SystemProperty.BlockHeight];
            rect[1, 1] = 1;
            rect[2, 1] = 1;
            rect[2, 2] = 1;
            rect[2, 3] = 1;
            return rect;
        }

        /// <summary>
        ///□□□□ 
        ///□□■□ 
        ///□■■□ 
        ///□■□□ 
        /// </summary>
        /// <returns></returns>
        private int[,] CreateBlockZ()
        {
            var rect = new int[SystemProperty.BlockWidth, SystemProperty.BlockHeight];
            rect[1, 2] = 1;
            rect[2, 1] = 1;
            rect[2, 2] = 1;
            rect[1, 3] = 1;
            return rect;
        }

        /// <summary>
        ///□□□□ 
        ///□■□□ 
        ///□■■□ 
        ///□□■□ 
        /// </summary>
        /// <returns></returns>
        private int[,] CreateBlockS()
        {
            var rect = new int[SystemProperty.BlockWidth, SystemProperty.BlockHeight];
            rect[1, 1] = 1;
            rect[1, 2] = 1;
            rect[2, 2] = 1;
            rect[2, 3] = 1;
            return rect;
        }
    }
}
