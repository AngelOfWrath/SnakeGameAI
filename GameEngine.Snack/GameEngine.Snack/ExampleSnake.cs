using PixelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Snack
{
    public class ExampleSnake : ISnake
    {
        private const int _width = 50;
        private const int _wallDistanceThreshold = 3;
        private Point _myHeadPosition;
        private Point _myFoodPosition;
        private string _map = "";
        public string Name => "Example Snake";

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection)
        {
            if (_myHeadPosition.X > 0 && _myHeadPosition.Y > 0 && _myHeadPosition.X < 49 && _myHeadPosition.X < 49)
            {
                if (_map == "")
                {
                    return currentDirection;
                }
                if ((_myHeadPosition.X == 48 || _myHeadPosition.X == 1 && (currentDirection == SnakeDirection.Left || currentDirection == SnakeDirection.Right)) ||
                    (_myHeadPosition.Y == 48 || _myHeadPosition.Y == 1 && (currentDirection == SnakeDirection.Down || currentDirection == SnakeDirection.Up)))
                {
                    return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
                }
                if (currentDirection == SnakeDirection.Up &&
                    (_map[(_myHeadPosition.Y - 2) * 50 + _myHeadPosition.X] == 'x' ||
                    _map[(_myHeadPosition.Y - 2) * 50 + _myHeadPosition.X] == '1') &&
                    _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] != '7' &&
                    (_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] != 'x' ||
                    _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] != '1')) 
                {
                    if ((_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 2] == 'x' ||
                    _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 2] == '1') &&
                    (_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 2] == 'x' ||
                    _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 2] == '1'))
                    {
                        if (Scan1(SnakeDirection.Down, _myHeadPosition.X - 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Right ||
                            Scan1(SnakeDirection.Down, _myHeadPosition.X - 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Up)
                        {
                            return SnakeDirection.Left;
                        }
                        if (Scan1(SnakeDirection.Down, _myHeadPosition.X + 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Left ||
                            Scan1(SnakeDirection.Down, _myHeadPosition.X + 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Up)
                        {
                            return SnakeDirection.Right;
                        }
                    }

                    if ((_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 1] == 'x' ||
                    _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 1] == '1') || 
                    (_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 1] == 'x' ||
                    _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 1] == '1'))
                    {
                        return currentDirection;
                    }
                    return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
                }
                if (currentDirection == SnakeDirection.Up && _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] == '1')
                {
                    return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
                }
                if (currentDirection == SnakeDirection.Down &&
                    (_map[(_myHeadPosition.Y + 2) * 50 + _myHeadPosition.X] == 'x' ||
                    _map[(_myHeadPosition.Y + 2) * 50 + _myHeadPosition.X] == '1') &&
                    _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] != '7' &&
                    (_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] != 'x' ||
                    _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] != '1'))
                {
                    if ((_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 2] == 'x' ||
                    _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 2] == '1') &&
                    (_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 2] == 'x' ||
                    _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 2] == '1'))
                    {
                        if (Scan1(SnakeDirection.Up, _myHeadPosition.X - 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Right ||
                            Scan1(SnakeDirection.Up, _myHeadPosition.X - 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Down)
                        {
                            return SnakeDirection.Left;
                        }
                        if (Scan1(SnakeDirection.Up, _myHeadPosition.X + 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Left ||
                            Scan1(SnakeDirection.Up, _myHeadPosition.X + 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Down)
                        {
                            return SnakeDirection.Right;
                        }
                    }

                    if ((_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 1] == 'x' ||
                    _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 1] == '1') ||
                    (_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 1] == 'x' ||
                    _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 1] == '1'))
                    {
                        return currentDirection;
                    }
                    return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
                }
                if (currentDirection == SnakeDirection.Down && _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] == '1')
                {
                    return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
                }
                if (currentDirection == SnakeDirection.Left &&
                    (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - 2] == 'x' ||
                    _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - 2] == '1') &&
                    _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - 1] != '7' &&
                    (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - 1] != 'x' ||
                    _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - 1] != '1'))
                {
                    if ((_map[(_myHeadPosition.Y + 2) * 50 + _myHeadPosition.X] == 'x' ||
                    _map[(_myHeadPosition.Y + 2) * 50 + _myHeadPosition.X] == '1') &&
                    (_map[(_myHeadPosition.Y - 2) * 50 + _myHeadPosition.X] == 'x' ||
                    _map[(_myHeadPosition.Y - 2) * 50 + _myHeadPosition.X] == '1'))
                    {
                        if (Scan1(SnakeDirection.Right, _myHeadPosition.X, _myHeadPosition.Y - 1, _map, 1) == SnakeDirection.Down ||
                            Scan1(SnakeDirection.Right, _myHeadPosition.X, _myHeadPosition.Y - 1, _map, 1) == SnakeDirection.Left)
                        {
                            return SnakeDirection.Up;
                        }
                        if (Scan1(SnakeDirection.Right, _myHeadPosition.X, _myHeadPosition.Y + 1, _map, 1) == SnakeDirection.Up ||
                            Scan1(SnakeDirection.Right, _myHeadPosition.X, _myHeadPosition.Y + 1, _map, 1) == SnakeDirection.Left)
                        {
                            return SnakeDirection.Down;
                        }
                    }
                    if ((_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] == 'x' ||
                    _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] == '1') ||
                    (_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] == 'x' ||
                    _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] == '1'))
                    {
                        return currentDirection;
                    }
                    return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
                }
                if (currentDirection == SnakeDirection.Left && _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - 1] == '1')
                {
                    return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
                }
                if (currentDirection == SnakeDirection.Right &&
                    (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + 2] == 'x' ||
                    _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + 2] == '1') &&
                    _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + 1] != '7' &&
                    (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + 1] != 'x' ||
                    _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + 1] != '1'))
                {
                    if ((_map[(_myHeadPosition.Y + 2) * 50 + _myHeadPosition.X] == 'x' ||
                    _map[(_myHeadPosition.Y + 2) * 50 + _myHeadPosition.X] == '1') &&
                    (_map[(_myHeadPosition.Y - 2) * 50 + _myHeadPosition.X] == 'x' ||
                    _map[(_myHeadPosition.Y - 2) * 50 + _myHeadPosition.X] == '1'))
                    {
                        if (Scan1(SnakeDirection.Left, _myHeadPosition.X, _myHeadPosition.Y - 1, _map, 1) == SnakeDirection.Down ||
                            Scan1(SnakeDirection.Left, _myHeadPosition.X, _myHeadPosition.Y - 1, _map, 1) == SnakeDirection.Right)
                        {
                            return SnakeDirection.Up;
                        }
                        if (Scan1(SnakeDirection.Left, _myHeadPosition.X, _myHeadPosition.Y + 1, _map, 1) == SnakeDirection.Up ||
                            Scan1(SnakeDirection.Left, _myHeadPosition.X, _myHeadPosition.Y + 1, _map, 1) == SnakeDirection.Right)
                        {
                            return SnakeDirection.Down;
                        }
                    }
                    if ((_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] == 'x' ||
                    _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] == '1') ||
                    (_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] == 'x' ||
                    _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] == '1'))
                    {
                        return currentDirection;
                    }
                    return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
                }
                if (currentDirection == SnakeDirection.Right && _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + 1] == '1')
                {
                    return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
                }
                if (_myHeadPosition.X == _myFoodPosition.X &&
                    (currentDirection == SnakeDirection.Right || currentDirection == SnakeDirection.Left))
                {
                    if (_myHeadPosition.Y < _myFoodPosition.Y)
                    {
                        return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1, SnakeDirection.Down);
                    }
                    else if (_myHeadPosition.Y > _myFoodPosition.Y)
                    {
                        return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1, SnakeDirection.Up);
                    }
                }
                if (_myHeadPosition.Y == 2 && _myFoodPosition.Y == 1) {
                    return SnakeDirection.Up;
                }
                if (_myHeadPosition.Y == 48 && _myFoodPosition.Y == 49)
                {
                    return SnakeDirection.Down;
                }
                if (_myHeadPosition.X == 2 && _myFoodPosition.X == 1)
                {
                    return SnakeDirection.Left;
                }
                if (_myHeadPosition.X == 48 && _myFoodPosition.X == 49)
                {
                    return SnakeDirection.Right;
                }
                if (_myHeadPosition.Y == _myFoodPosition.Y
                    && (currentDirection == SnakeDirection.Down || currentDirection == SnakeDirection.Up))
                {
                    if (_myHeadPosition.X < _myFoodPosition.X)
                    {
                        return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1, SnakeDirection.Right);
                    }
                    else if (_myHeadPosition.X > _myFoodPosition.X)
                    {
                        return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1, SnakeDirection.Left);
                    }
                }
            }
            return currentDirection;
        }
        public void UpdateMap(string map)
        {
            _myHeadPosition = getMyHeadPosition(map);
            _myFoodPosition = getMyFoodPosition(map);
            _map = map;
        }

        private Point getMyHeadPosition(string map)
        {
            var headIndex = map.IndexOf('*');
            return new Point(headIndex % _width, headIndex / _width);
        }
        private Point getMyFoodPosition(string map)
        {
            var headIndex = map.IndexOf('7');
            return new Point(headIndex % _width, headIndex / _width);
        }
        private SnakeDirection Scan(SnakeDirection currentDirection, int X, int Y, string map, int step)
        {
            if (currentDirection == SnakeDirection.Up || currentDirection == SnakeDirection.Down)
            {
                if (step==1 &&
                (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == 'x' ||
                _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == '1') &&
                (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == 'x' ||
                _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == '1')) {
                    return currentDirection;
                }
                if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == 'x' ||
                _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == '1' ||
                _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == '7')
                {
                    return SnakeDirection.Right;
                }

                if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == 'x' ||
                _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == '1' ||
                _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == '7')
                {
                    return SnakeDirection.Left;
                }
                return Scan(currentDirection, X, Y, map, step + 1);
            }

            if (currentDirection == SnakeDirection.Left || currentDirection == SnakeDirection.Right)
            {
                if (step == 1 &&
                (_map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == 'x' ||
                _map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == '1') &&
                (_map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == 'x' ||
                _map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == '1'))
                {
                    return currentDirection;
                }
                if (_map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == 'x' ||
                _map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == '1' ||
                _map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == '7')
                {
                    return SnakeDirection.Down;
                }

                if (_map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == 'x' ||
                _map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == '1' ||
                _map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == '7')
                {
                    return SnakeDirection.Up;
                }

                return Scan(currentDirection, X, Y, map, step + 1);
            }

            return currentDirection;
        }
        private SnakeDirection Scan(SnakeDirection currentDirection, int X, int Y, string map, int step, SnakeDirection scanDirection)
        {
            if (scanDirection == SnakeDirection.Left)
            {
                if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == 'x' ||
                _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == '1')
                {
                    return currentDirection;
                }
                else if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == '7')
                {
                    return SnakeDirection.Left;
                }
            }
            if (scanDirection == SnakeDirection.Right)
            {
                if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == 'x' ||
                _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == '1')
                {
                    return currentDirection;
                }
                else if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == '7')
                {
                    return SnakeDirection.Right;
                }
            }
            if (scanDirection == SnakeDirection.Up)
            {
                if (_map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == 'x' ||
                _map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == '1')
                {
                    return currentDirection;
                }
                else if (_map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == '7')
                {
                    return SnakeDirection.Up;
                }
            }
            if (scanDirection == SnakeDirection.Down)
            {
                if (_map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == 'x' ||
                _map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == '1')
                {
                    return currentDirection;
                }
                else if (_map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == '7')
                {
                    return SnakeDirection.Down;
                }
            }
            return Scan(currentDirection, X, Y, map, step + 1,scanDirection);
        }
        //private SnakeDirection snakeScan(SnakeDirection currentDirection, int X, int Y, string map, int step) {

        //    if (currentDirection == SnakeDirection.Up || currentDirection == SnakeDirection.Down)
        //    {
        //        if (step == 1 &&
        //        (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == 'x' ||
        //        _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == '1') &&
        //        (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == 'x' ||
        //        _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == '1'))
        //        {
        //            return currentDirection;
        //        }
        //        if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == 'x' ||
        //        _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == '1')
        //        {
        //            if ((_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X - step + 1] == 'x' ||
        //            _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X - step + 1] == '1') &&
        //            (_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X - step + 1] == 'x' ||
        //            _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X - step + 1] == '1'))
        //            {
        //                return SnakeDirection.Right;
        //            }
        //            else {
        //                return SnakeDirection.Left;
        //            }
        //        }

        //        if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == 'x' ||
        //        _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == '1')
        //        {
        //            if ((_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X + step - 1] == 'x' ||
        //            _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X + step - 1] == '1') &&
        //            (_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X + step - 1] == 'x' ||
        //            _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X + step - 1] == '1'))
        //            {
        //                return SnakeDirection.Left;
        //            }
        //            else
        //            {
        //                return SnakeDirection.Right;
        //            }
        //        }
        //        return Scan(currentDirection, X, Y, map, step + 1);
        //    }

        //    if (currentDirection == SnakeDirection.Left || currentDirection == SnakeDirection.Right)
        //    {
        //        if (step == 1 &&
        //        (_map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == 'x' ||
        //        _map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == '1') &&
        //        (_map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == 'x' ||
        //        _map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == '1'))
        //        {
        //            return currentDirection;
        //        }
        //        if (_map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == 'x' ||
        //        _map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == '1')
        //        {
        //            if ((_map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X - 1] == 'x' ||
        //            _map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X - 1] == '1') &&
        //            (_map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X + 1] == 'x' ||
        //            _map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X + 1] == '1'))
        //            {
        //                return SnakeDirection.Down;
        //            }
        //            else
        //            {
        //                return SnakeDirection.Up;
        //            }
        //        }

        //        if (_map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == 'x' ||
        //        _map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == '1')
        //        {
        //            if ((_map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X - 1] == 'x' ||
        //            _map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X - 1] == '1') &&
        //            (_map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X + 1] == 'x' ||
        //            _map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X + 1] == '1'))
        //            {
        //                return SnakeDirection.Up;
        //            }
        //            else
        //            {
        //                return SnakeDirection.Down;
        //            }
        //        }

        //        return Scan(currentDirection, X, Y, map, step + 1);
        //    }

        //    return currentDirection;
        //}
        private SnakeDirection Scan1(SnakeDirection currentDirection, int X, int Y, string map, int step)
        {
            if (currentDirection == SnakeDirection.Left)
            {
                if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == 'x' ||
                _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == '1')
                {
                    if ((_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X - step + 1] == 'x' ||
                    _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X - step + 1] == '1') &&
                    (_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X - step + 1] == 'x' ||
                    _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X - step + 1] == '1')){
                        return currentDirection;   
                    }
                    if (_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X - step + 1] == 'x' ||
                    _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X - step + 1] == '1')
                    {
                        return SnakeDirection.Up;
                    }
                    if(_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X - step + 1] == 'x' ||
                    _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X - step + 1] == '1')
                    {
                        return SnakeDirection.Down;
                    }
                    if (currentDirection == SnakeDirection.Right) {
                        return SnakeDirection.Left;
                    }
                    if (currentDirection == SnakeDirection.Left)
                    {
                        return SnakeDirection.Right;
                    }
                    if (currentDirection == SnakeDirection.Up)
                    {
                        return SnakeDirection.Down;
                    }
                    if (currentDirection == SnakeDirection.Down)
                    {
                        return SnakeDirection.Up;
                    }
                }

                return Scan1(currentDirection, X, Y, map, step + 1);
            }
            if (currentDirection == SnakeDirection.Right)
            {
                if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == 'x' ||
                _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == '1')
                {
                    if ((_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X + step - 1] == 'x' ||
                    _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X + step - 1] == '1') &&
                    (_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X + step - 1] == 'x' ||
                    _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X + step - 1] == '1'))
                    {
                        return currentDirection;
                    }
                    if (_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X + step - 1] == 'x' ||
                    _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X + step - 1] == '1')
                    {
                        return SnakeDirection.Up;
                    }
                    if (_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X + step - 1] == 'x' ||
                    _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X + step - 1] == '1')
                    {
                        return SnakeDirection.Down;
                    }
                    if (currentDirection == SnakeDirection.Right)
                    {
                        return SnakeDirection.Left;
                    }
                    if (currentDirection == SnakeDirection.Left)
                    {
                        return SnakeDirection.Right;
                    }
                    if (currentDirection == SnakeDirection.Up)
                    {
                        return SnakeDirection.Down;
                    }
                    if (currentDirection == SnakeDirection.Down)
                    {
                        return SnakeDirection.Up;
                    }
                }

                return Scan1(currentDirection, X, Y, map, step + 1);
            }
            

            if (currentDirection == SnakeDirection.Up)
            {
                if (_map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == 'x' ||
                _map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == '1')
                {
                    if ((_map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X + 1] == 'x' ||
                    _map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X + 1] == '1') &&
                    (_map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X - 1] == 'x' ||
                    _map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X -  1] == '1'))
                    {
                        return currentDirection;
                    }
                    if (_map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X + 1] == 'x' ||
                    _map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X + 1] == '1')
                    {
                        return SnakeDirection.Left;
                    }
                    if(_map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X - 1] == 'x' ||
                    _map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X - 1] == '1')
                    {
                        return SnakeDirection.Right;
                    }
                    if (currentDirection == SnakeDirection.Right)
                    {
                        return SnakeDirection.Left;
                    }
                    if (currentDirection == SnakeDirection.Left)
                    {
                        return SnakeDirection.Right;
                    }
                    if (currentDirection == SnakeDirection.Up)
                    {
                        return SnakeDirection.Down;
                    }
                    if (currentDirection == SnakeDirection.Down)
                    {
                        return SnakeDirection.Up;
                    }
                }

                return Scan1(currentDirection, X, Y, map, step + 1);
            }
            if (currentDirection == SnakeDirection.Down)
            {
                if (_map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == 'x' ||
                _map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == '1')
                {
                    if ((_map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X + 1] == 'x' ||
                    _map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X + 1] == '1') &&
                    (_map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X - 1] == 'x' ||
                    _map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X - 1] == '1'))
                    {
                        return currentDirection;
                    }
                    if (_map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X + 1] == 'x' ||
                    _map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X + 1] == '1')
                    {
                        return SnakeDirection.Left;
                    }
                    if (_map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X - 1] == 'x' ||
                    _map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X - 1] == '1')
                    {
                        return SnakeDirection.Right;
                    }
                    if (currentDirection == SnakeDirection.Right)
                    {
                        return SnakeDirection.Left;
                    }
                    if (currentDirection == SnakeDirection.Left)
                    {
                        return SnakeDirection.Right;
                    }
                    if (currentDirection == SnakeDirection.Up)
                    {
                        return SnakeDirection.Down;
                    }
                    if (currentDirection == SnakeDirection.Down)
                    {
                        return SnakeDirection.Up;
                    }
                }

                return Scan1(currentDirection, X, Y, map, step + 1);
            }

            return currentDirection;
        }
    }
}