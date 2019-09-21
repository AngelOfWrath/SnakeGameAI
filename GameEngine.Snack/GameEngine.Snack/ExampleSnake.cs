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
        private Point _myHeadPosition;
        private Point _myFoodPosition;
        private string _map = "";
        private char[,] _arrayMap = new char[50,50];
        public string Name => "Example Snake";

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection) {
            if (_myHeadPosition.Y == 0 || _map == "" ||
                checkFoodOnNextPlace(currentDirection))
            {
                return currentDirection;
            }
            if (currentDirection == SnakeDirection.Up && CheckUpDistance() < 2)
            {
                if (CheckLeftDistance() == 0 && CheckRightDistance() == 0)
                {
                    return currentDirection;
                }
                if (CheckLeftDistance() == 1 && CheckRightDistance() == 1)
                {
                    return CheckDownDistance(new Point(_myHeadPosition.X - 1, _myHeadPosition.Y)) > CheckDownDistance(new Point(_myHeadPosition.X + 1, _myHeadPosition.Y)) ? SnakeDirection.Left : SnakeDirection.Right;
                }
                return CheckLeftDistance() > CheckRightDistance() ? SnakeDirection.Left : SnakeDirection.Right;
            }
            if (currentDirection == SnakeDirection.Down && CheckDownDistance() < 2)
            {
                if (CheckLeftDistance() == 0 && CheckRightDistance() == 0)
                {
                    return currentDirection;
                }
                if (CheckLeftDistance() == 1 && CheckRightDistance() == 1)
                {
                    return CheckUpDistance(new Point(_myHeadPosition.X - 1, _myHeadPosition.Y)) > CheckUpDistance(new Point(_myHeadPosition.X + 1, _myHeadPosition.Y)) ? SnakeDirection.Left : SnakeDirection.Right;
                }
                return CheckLeftDistance() > CheckRightDistance() ? SnakeDirection.Left : SnakeDirection.Right;
            }
            if (currentDirection == SnakeDirection.Right && CheckRightDistance() < 2)
            {
                if (CheckUpDistance() == 0 && CheckDownDistance() == 0)
                {
                    return currentDirection;
                }
                if (CheckUpDistance() == 1 && CheckDownDistance() == 1)
                {
                    return CheckLeftDistance(new Point(_myHeadPosition.X, _myHeadPosition.Y - 1)) > CheckLeftDistance(new Point(_myHeadPosition.X, _myHeadPosition.Y + 1)) ? SnakeDirection.Up : SnakeDirection.Down;
                }
                return CheckUpDistance() > CheckDownDistance() ? SnakeDirection.Up : SnakeDirection.Down;
            }
            if (currentDirection == SnakeDirection.Left && CheckLeftDistance() < 2)
            {
                if (CheckUpDistance() == 0 && CheckDownDistance() == 0)
                {
                    return currentDirection;
                }
                if (CheckUpDistance() == 1 && CheckDownDistance() == 1)
                {
                    return CheckRightDistance(new Point(_myHeadPosition.X, _myHeadPosition.Y - 1)) > CheckRightDistance(new Point(_myHeadPosition.X, _myHeadPosition.Y + 1)) ? SnakeDirection.Up : SnakeDirection.Down;
                }
                return CheckUpDistance() > CheckDownDistance() ? SnakeDirection.Up : SnakeDirection.Down;
            }
            if (_myHeadPosition.X == _myFoodPosition.X)
            {
                if (_myHeadPosition.Y > _myFoodPosition.Y)
                {
                    return CheckUpDistance() > _myHeadPosition.Y - _myFoodPosition.Y - 1 ? SnakeDirection.Up : currentDirection;
                }
                if (_myHeadPosition.Y < _myFoodPosition.Y)
                {
                    return CheckDownDistance() > _myFoodPosition.Y - _myHeadPosition.Y - 1 ? SnakeDirection.Down : currentDirection;
                }
                return  currentDirection;
            }
            if (_myHeadPosition.Y == _myFoodPosition.Y)
            {
                if (_myHeadPosition.X > _myFoodPosition.X)
                {
                    return CheckLeftDistance() > _myHeadPosition.X - _myFoodPosition.X - 1 ? SnakeDirection.Left : currentDirection;
                }
                if (_myHeadPosition.X < _myFoodPosition.X)
                {
                    return CheckRightDistance() > _myFoodPosition.X - _myHeadPosition.X - 1 ? SnakeDirection.Right : currentDirection;
                }
                return currentDirection;
            }
            if (_myFoodPosition.X == 1 && _myHeadPosition.X == 2 && CheckLeftDistance() > 0) {
                return SnakeDirection.Left;
            }
            if (_myFoodPosition.X == 48 && _myHeadPosition.X == 47 && CheckRightDistance() > 0)
            {
                return SnakeDirection.Right;
            }
            if (_myFoodPosition.Y == 1 && _myHeadPosition.Y == 2 && CheckUpDistance() > 0)
            {
                return SnakeDirection.Up;
            }
            if (_myFoodPosition.Y == 48 && _myHeadPosition.Y == 47 && CheckDownDistance() > 0)
            {
                return SnakeDirection.Down;
            }
            return currentDirection;
        }

        #region CheckersForDistance
        public int CheckRightDistance() {
            int counter=0;
            while (checkBarrier(_arrayMap[_myHeadPosition.Y,_myHeadPosition.X + counter + 1],false)) {
                counter++;
            }
            return counter;
        }
        public int CheckRightDistance(Point certainPosition)
        {
            int counter = 0;
            while (checkBarrier(_arrayMap[certainPosition.Y, certainPosition.X + counter + 1], false))
            {
                counter++;
            }
            return counter;
        }
        public int CheckLeftDistance()
        {
            int counter = 0;
            while (checkBarrier(_arrayMap[_myHeadPosition.Y, _myHeadPosition.X - counter - 1], false))
            {
                counter++;
            }
            return counter;
        }
        public int CheckLeftDistance(Point certainPosition)
        {
            int counter = 0;
            while (checkBarrier(_arrayMap[certainPosition.Y, certainPosition.X - counter - 1], false))
            {
                counter++;
            }
            return counter;
        }
        public int CheckUpDistance()
        {
            int counter = 0;
            while (checkBarrier(_arrayMap[_myHeadPosition.Y - counter - 1, _myHeadPosition.X], false))
            {
                counter++;
            }
            return counter;
        }
        public int CheckUpDistance(Point certainPosition)
        {
            int counter = 0;
            while (checkBarrier(_arrayMap[certainPosition.Y - counter - 1, certainPosition.X], false))
            {
                counter++;
            }
            return counter;
        }
        public int CheckDownDistance()
        {
            int counter = 0;
            while (checkBarrier(_arrayMap[_myHeadPosition.Y + counter + 1, _myHeadPosition.X], false))
            {
                counter++;
            }
            return counter;
        }
        public int CheckDownDistance(Point certainPosition)
        {
            int counter = 0;
            while (checkBarrier(_arrayMap[certainPosition.Y + counter + 1, certainPosition.X], false))
            {
                counter++;
            }
            return counter;
        }
        #endregion
        #region CheckersForItems
        public bool checkBarrier(char item, bool state) {
            if (state)
            {
                if (item == 'x' || item == '1')
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (item != 'x' && item != '1')
                {
                    return true;
                }
                return false;
            }
        }
        public bool checkFood(char item, bool state)
        {
            if (state)
            {
                if (item == '7')
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (item != '7')
                {
                    return true;
                }
                return false;
            }
        }
        public bool checkFoodOnNextPlace(SnakeDirection currentDirection)
        {
            if (currentDirection == SnakeDirection.Up && _myHeadPosition.X == _myFoodPosition.X && _myHeadPosition.Y - 1 == _myFoodPosition.Y)
            {
                return true;
            }
            if (currentDirection == SnakeDirection.Down && _myHeadPosition.X == _myFoodPosition.X && _myHeadPosition.Y + 1 == _myFoodPosition.Y)
            {
                return true;
            }
            if (currentDirection == SnakeDirection.Left && _myHeadPosition.Y == _myFoodPosition.Y && _myHeadPosition.X - 1 == _myFoodPosition.X)
            {
                return true;
            }
            if (currentDirection == SnakeDirection.Right && _myHeadPosition.Y == _myFoodPosition.Y && _myHeadPosition.X + 1 == _myFoodPosition.X)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region UpdateFunctions
        public void UpdateMap(string map)
        {
            _myHeadPosition = getMyHeadPosition(map);
            _myFoodPosition = getMyFoodPosition(map);
            _map = map;
            if (map != "")
            {
                for (int i = 0; i < map.Length; i++)
                {
                    if (map[i] != _arrayMap[i / 50, i % 50])
                    {
                        _arrayMap[i / 50, i % 50] = map[i];
                    }
                }
            }
        }

        private Point getMyHeadPosition(string map)
        {
            var headIndex = map.IndexOf('*');
            return new Point(headIndex % 50, headIndex / 50);
        }

        private Point getMyFoodPosition(string map)
        {
            var headIndex = map.IndexOf('7');
            return new Point(headIndex % 50, headIndex / 50);
        }

        #endregion
        #region UselessVersion
        //private Point _myHeadPosition;
        //private Point _myFoodPosition;
        //private string _map = "";
        //public string Name => "Example Snake";

        //public SnakeDirection GetNextDirection(SnakeDirection currentDirection)
        //{
        //    if (_myHeadPosition.X > 0 && _myHeadPosition.Y > 0 && _myHeadPosition.X < 49 && _myHeadPosition.X < 49)
        //    {
        //        if (_map == "")
        //        {
        //            return currentDirection;
        //        }
        //        if ((_myHeadPosition.X == 48 || _myHeadPosition.X == 1 && (currentDirection == SnakeDirection.Left || currentDirection == SnakeDirection.Right)) ||
        //            (_myHeadPosition.Y == 48 || _myHeadPosition.Y == 1 && (currentDirection == SnakeDirection.Down || currentDirection == SnakeDirection.Up)))
        //        {
        //            return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
        //        }
        //        if (currentDirection == SnakeDirection.Up &&
        //            (_map[(_myHeadPosition.Y - 2) * 50 + _myHeadPosition.X] == 'x' ||
        //            _map[(_myHeadPosition.Y - 2) * 50 + _myHeadPosition.X] == '1') &&
        //            _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] != '7' &&
        //            (_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] != 'x' ||
        //            _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] != '1')) 
        //        {
        //            if ((_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 2] == 'x' ||
        //            _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 2] == '1') &&
        //            (_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 2] == 'x' ||
        //            _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 2] == '1'))
        //            {
        //                if (Scan1(SnakeDirection.Down, _myHeadPosition.X - 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Right ||
        //                    Scan1(SnakeDirection.Down, _myHeadPosition.X - 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Up)
        //                {
        //                    return SnakeDirection.Left;
        //                }
        //                if (Scan1(SnakeDirection.Down, _myHeadPosition.X + 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Left ||
        //                    Scan1(SnakeDirection.Down, _myHeadPosition.X + 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Up)
        //                {
        //                    return SnakeDirection.Right;
        //                }
        //            }

        //            if ((_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 1] == 'x' ||
        //            _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 1] == '1') || 
        //            (_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 1] == 'x' ||
        //            _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 1] == '1'))
        //            {
        //                return currentDirection;
        //            }
        //            return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
        //        }
        //        if (currentDirection == SnakeDirection.Up && _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] == '1')
        //        {
        //            return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
        //        }
        //        if (currentDirection == SnakeDirection.Down &&
        //            (_map[(_myHeadPosition.Y + 2) * 50 + _myHeadPosition.X] == 'x' ||
        //            _map[(_myHeadPosition.Y + 2) * 50 + _myHeadPosition.X] == '1') &&
        //            _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] != '7' &&
        //            (_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] != 'x' ||
        //            _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] != '1'))
        //        {
        //            if ((_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 2] == 'x' ||
        //            _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 2] == '1') &&
        //            (_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 2] == 'x' ||
        //            _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 2] == '1'))
        //            {
        //                if (Scan1(SnakeDirection.Up, _myHeadPosition.X - 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Right ||
        //                    Scan1(SnakeDirection.Up, _myHeadPosition.X - 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Down)
        //                {
        //                    return SnakeDirection.Left;
        //                }
        //                if (Scan1(SnakeDirection.Up, _myHeadPosition.X + 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Left ||
        //                    Scan1(SnakeDirection.Up, _myHeadPosition.X + 1, _myHeadPosition.Y, _map, 1) == SnakeDirection.Down)
        //                {
        //                    return SnakeDirection.Right;
        //                }
        //            }

        //            if ((_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 1] == 'x' ||
        //            _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X + 1] == '1') ||
        //            (_map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 1] == 'x' ||
        //            _map[(_myHeadPosition.Y) * 50 + _myHeadPosition.X - 1] == '1'))
        //            {
        //                return currentDirection;
        //            }
        //            return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
        //        }
        //        if (currentDirection == SnakeDirection.Down && _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] == '1')
        //        {
        //            return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
        //        }
        //        if (currentDirection == SnakeDirection.Left &&
        //            (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - 2] == 'x' ||
        //            _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - 2] == '1') &&
        //            _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - 1] != '7' &&
        //            (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - 1] != 'x' ||
        //            _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - 1] != '1'))
        //        {
        //            if ((_map[(_myHeadPosition.Y + 2) * 50 + _myHeadPosition.X] == 'x' ||
        //            _map[(_myHeadPosition.Y + 2) * 50 + _myHeadPosition.X] == '1') &&
        //            (_map[(_myHeadPosition.Y - 2) * 50 + _myHeadPosition.X] == 'x' ||
        //            _map[(_myHeadPosition.Y - 2) * 50 + _myHeadPosition.X] == '1'))
        //            {
        //                if (Scan1(SnakeDirection.Right, _myHeadPosition.X, _myHeadPosition.Y - 1, _map, 1) == SnakeDirection.Down ||
        //                    Scan1(SnakeDirection.Right, _myHeadPosition.X, _myHeadPosition.Y - 1, _map, 1) == SnakeDirection.Left)
        //                {
        //                    return SnakeDirection.Up;
        //                }
        //                if (Scan1(SnakeDirection.Right, _myHeadPosition.X, _myHeadPosition.Y + 1, _map, 1) == SnakeDirection.Up ||
        //                    Scan1(SnakeDirection.Right, _myHeadPosition.X, _myHeadPosition.Y + 1, _map, 1) == SnakeDirection.Left)
        //                {
        //                    return SnakeDirection.Down;
        //                }
        //            }
        //            if ((_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] == 'x' ||
        //            _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] == '1') ||
        //            (_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] == 'x' ||
        //            _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] == '1'))
        //            {
        //                return currentDirection;
        //            }
        //            return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
        //        }
        //        if (currentDirection == SnakeDirection.Left && _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - 1] == '1')
        //        {
        //            return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
        //        }
        //        if (currentDirection == SnakeDirection.Right &&
        //            (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + 2] == 'x' ||
        //            _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + 2] == '1') &&
        //            _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + 1] != '7' &&
        //            (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + 1] != 'x' ||
        //            _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + 1] != '1'))
        //        {
        //            if ((_map[(_myHeadPosition.Y + 2) * 50 + _myHeadPosition.X] == 'x' ||
        //            _map[(_myHeadPosition.Y + 2) * 50 + _myHeadPosition.X] == '1') &&
        //            (_map[(_myHeadPosition.Y - 2) * 50 + _myHeadPosition.X] == 'x' ||
        //            _map[(_myHeadPosition.Y - 2) * 50 + _myHeadPosition.X] == '1'))
        //            {
        //                if (Scan1(SnakeDirection.Left, _myHeadPosition.X, _myHeadPosition.Y - 1, _map, 1) == SnakeDirection.Down ||
        //                    Scan1(SnakeDirection.Left, _myHeadPosition.X, _myHeadPosition.Y - 1, _map, 1) == SnakeDirection.Right)
        //                {
        //                    return SnakeDirection.Up;
        //                }
        //                if (Scan1(SnakeDirection.Left, _myHeadPosition.X, _myHeadPosition.Y + 1, _map, 1) == SnakeDirection.Up ||
        //                    Scan1(SnakeDirection.Left, _myHeadPosition.X, _myHeadPosition.Y + 1, _map, 1) == SnakeDirection.Right)
        //                {
        //                    return SnakeDirection.Down;
        //                }
        //            }
        //            if ((_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] == 'x' ||
        //            _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X] == '1') ||
        //            (_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] == 'x' ||
        //            _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X] == '1'))
        //            {
        //                return currentDirection;
        //            }
        //            return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
        //        }
        //        if (currentDirection == SnakeDirection.Right && _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + 1] == '1')
        //        {
        //            return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1);
        //        }
        //        if (_myHeadPosition.X == _myFoodPosition.X &&
        //            (currentDirection == SnakeDirection.Right || currentDirection == SnakeDirection.Left))
        //        {
        //            if (_myHeadPosition.Y < _myFoodPosition.Y)
        //            {
        //                return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1, SnakeDirection.Down);
        //            }
        //            else if (_myHeadPosition.Y > _myFoodPosition.Y)
        //            {
        //                return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1, SnakeDirection.Up);
        //            }
        //        }
        //        if (_myHeadPosition.Y == 2 && _myFoodPosition.Y == 1) {
        //            return SnakeDirection.Up;
        //        }
        //        if (_myHeadPosition.Y == 48 && _myFoodPosition.Y == 49)
        //        {
        //            return SnakeDirection.Down;
        //        }
        //        if (_myHeadPosition.X == 2 && _myFoodPosition.X == 1)
        //        {
        //            return SnakeDirection.Left;
        //        }
        //        if (_myHeadPosition.X == 48 && _myFoodPosition.X == 49)
        //        {
        //            return SnakeDirection.Right;
        //        }
        //        if (_myHeadPosition.Y == _myFoodPosition.Y
        //            && (currentDirection == SnakeDirection.Down || currentDirection == SnakeDirection.Up))
        //        {
        //            if (_myHeadPosition.X < _myFoodPosition.X)
        //            {
        //                return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1, SnakeDirection.Right);
        //            }
        //            else if (_myHeadPosition.X > _myFoodPosition.X)
        //            {
        //                return Scan(currentDirection, _myHeadPosition.X, _myHeadPosition.Y, _map, 1, SnakeDirection.Left);
        //            }
        //        }
        //    }
        //    return currentDirection;
        //}
        //public void UpdateMap(string map)
        //{
        //    _myHeadPosition = getMyHeadPosition(map);
        //    _myFoodPosition = getMyFoodPosition(map);
        //    _map = map;
        //}

        //private Point getMyHeadPosition(string map)
        //{
        //    var headIndex = map.IndexOf('*');
        //    return new Point(headIndex % 50, headIndex / 50);
        //}
        //private Point getMyFoodPosition(string map)
        //{
        //    var headIndex = map.IndexOf('7');
        //    return new Point(headIndex % 50, headIndex / 50);
        //}
        //private SnakeDirection Scan(SnakeDirection currentDirection, int X, int Y, string map, int step)
        //{
        //    if (currentDirection == SnakeDirection.Up || currentDirection == SnakeDirection.Down)
        //    {
        //        if (step==1 &&
        //        (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == 'x' ||
        //        _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == '1') &&
        //        (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == 'x' ||
        //        _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == '1')) {
        //            return currentDirection;
        //        }
        //        if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == 'x' ||
        //        _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == '1' ||
        //        _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == '7')
        //        {
        //            return SnakeDirection.Right;
        //        }

        //        if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == 'x' ||
        //        _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == '1' ||
        //        _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == '7')
        //        {
        //            return SnakeDirection.Left;
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
        //        _map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == '1' ||
        //        _map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == '7')
        //        {
        //            return SnakeDirection.Down;
        //        }

        //        if (_map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == 'x' ||
        //        _map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == '1' ||
        //        _map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == '7')
        //        {
        //            return SnakeDirection.Up;
        //        }

        //        return Scan(currentDirection, X, Y, map, step + 1);
        //    }

        //    return currentDirection;
        //}
        //private SnakeDirection Scan(SnakeDirection currentDirection, int X, int Y, string map, int step, SnakeDirection scanDirection)
        //{
        //    if (scanDirection == SnakeDirection.Left)
        //    {
        //        if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == 'x' ||
        //        _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == '1')
        //        {
        //            return currentDirection;
        //        }
        //        else if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == '7')
        //        {
        //            return SnakeDirection.Left;
        //        }
        //    }
        //    if (scanDirection == SnakeDirection.Right)
        //    {
        //        if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == 'x' ||
        //        _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == '1')
        //        {
        //            return currentDirection;
        //        }
        //        else if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == '7')
        //        {
        //            return SnakeDirection.Right;
        //        }
        //    }
        //    if (scanDirection == SnakeDirection.Up)
        //    {
        //        if (_map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == 'x' ||
        //        _map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == '1')
        //        {
        //            return currentDirection;
        //        }
        //        else if (_map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == '7')
        //        {
        //            return SnakeDirection.Up;
        //        }
        //    }
        //    if (scanDirection == SnakeDirection.Down)
        //    {
        //        if (_map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == 'x' ||
        //        _map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == '1')
        //        {
        //            return currentDirection;
        //        }
        //        else if (_map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == '7')
        //        {
        //            return SnakeDirection.Down;
        //        }
        //    }
        //    return Scan(currentDirection, X, Y, map, step + 1,scanDirection);
        //}

        //private SnakeDirection Scan1(SnakeDirection currentDirection, int X, int Y, string map, int step)
        //{
        //    if (currentDirection == SnakeDirection.Left)
        //    {
        //        if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == 'x' ||
        //        _map[_myHeadPosition.Y * 50 + _myHeadPosition.X - step] == '1')
        //        {
        //            if ((_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X - step + 1] == 'x' ||
        //            _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X - step + 1] == '1') &&
        //            (_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X - step + 1] == 'x' ||
        //            _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X - step + 1] == '1')){
        //                return currentDirection;   
        //            }
        //            if (_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X - step + 1] == 'x' ||
        //            _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X - step + 1] == '1')
        //            {
        //                return SnakeDirection.Up;
        //            }
        //            if(_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X - step + 1] == 'x' ||
        //            _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X - step + 1] == '1')
        //            {
        //                return SnakeDirection.Down;
        //            }
        //            if (currentDirection == SnakeDirection.Right) {
        //                return SnakeDirection.Left;
        //            }
        //            if (currentDirection == SnakeDirection.Left)
        //            {
        //                return SnakeDirection.Right;
        //            }
        //            if (currentDirection == SnakeDirection.Up)
        //            {
        //                return SnakeDirection.Down;
        //            }
        //            if (currentDirection == SnakeDirection.Down)
        //            {
        //                return SnakeDirection.Up;
        //            }
        //        }

        //        return Scan1(currentDirection, X, Y, map, step + 1);
        //    }
        //    if (currentDirection == SnakeDirection.Right)
        //    {
        //        if (_map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == 'x' ||
        //        _map[_myHeadPosition.Y * 50 + _myHeadPosition.X + step] == '1')
        //        {
        //            if ((_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X + step - 1] == 'x' ||
        //            _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X + step - 1] == '1') &&
        //            (_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X + step - 1] == 'x' ||
        //            _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X + step - 1] == '1'))
        //            {
        //                return currentDirection;
        //            }
        //            if (_map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X + step - 1] == 'x' ||
        //            _map[(_myHeadPosition.Y + 1) * 50 + _myHeadPosition.X + step - 1] == '1')
        //            {
        //                return SnakeDirection.Up;
        //            }
        //            if (_map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X + step - 1] == 'x' ||
        //            _map[(_myHeadPosition.Y - 1) * 50 + _myHeadPosition.X + step - 1] == '1')
        //            {
        //                return SnakeDirection.Down;
        //            }
        //            if (currentDirection == SnakeDirection.Right)
        //            {
        //                return SnakeDirection.Left;
        //            }
        //            if (currentDirection == SnakeDirection.Left)
        //            {
        //                return SnakeDirection.Right;
        //            }
        //            if (currentDirection == SnakeDirection.Up)
        //            {
        //                return SnakeDirection.Down;
        //            }
        //            if (currentDirection == SnakeDirection.Down)
        //            {
        //                return SnakeDirection.Up;
        //            }
        //        }

        //        return Scan1(currentDirection, X, Y, map, step + 1);
        //    }


        //    if (currentDirection == SnakeDirection.Up)
        //    {
        //        if (_map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == 'x' ||
        //        _map[(_myHeadPosition.Y - step) * 50 + _myHeadPosition.X] == '1')
        //        {
        //            if ((_map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X + 1] == 'x' ||
        //            _map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X + 1] == '1') &&
        //            (_map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X - 1] == 'x' ||
        //            _map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X -  1] == '1'))
        //            {
        //                return currentDirection;
        //            }
        //            if (_map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X + 1] == 'x' ||
        //            _map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X + 1] == '1')
        //            {
        //                return SnakeDirection.Left;
        //            }
        //            if(_map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X - 1] == 'x' ||
        //            _map[(_myHeadPosition.Y - step + 1) * 50 + _myHeadPosition.X - 1] == '1')
        //            {
        //                return SnakeDirection.Right;
        //            }
        //            if (currentDirection == SnakeDirection.Right)
        //            {
        //                return SnakeDirection.Left;
        //            }
        //            if (currentDirection == SnakeDirection.Left)
        //            {
        //                return SnakeDirection.Right;
        //            }
        //            if (currentDirection == SnakeDirection.Up)
        //            {
        //                return SnakeDirection.Down;
        //            }
        //            if (currentDirection == SnakeDirection.Down)
        //            {
        //                return SnakeDirection.Up;
        //            }
        //        }

        //        return Scan1(currentDirection, X, Y, map, step + 1);
        //    }
        //    if (currentDirection == SnakeDirection.Down)
        //    {
        //        if (_map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == 'x' ||
        //        _map[(_myHeadPosition.Y + step) * 50 + _myHeadPosition.X] == '1')
        //        {
        //            if ((_map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X + 1] == 'x' ||
        //            _map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X + 1] == '1') &&
        //            (_map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X - 1] == 'x' ||
        //            _map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X - 1] == '1'))
        //            {
        //                return currentDirection;
        //            }
        //            if (_map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X + 1] == 'x' ||
        //            _map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X + 1] == '1')
        //            {
        //                return SnakeDirection.Left;
        //            }
        //            if (_map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X - 1] == 'x' ||
        //            _map[(_myHeadPosition.Y + step - 1) * 50 + _myHeadPosition.X - 1] == '1')
        //            {
        //                return SnakeDirection.Right;
        //            }
        //            if (currentDirection == SnakeDirection.Right)
        //            {
        //                return SnakeDirection.Left;
        //            }
        //            if (currentDirection == SnakeDirection.Left)
        //            {
        //                return SnakeDirection.Right;
        //            }
        //            if (currentDirection == SnakeDirection.Up)
        //            {
        //                return SnakeDirection.Down;
        //            }
        //            if (currentDirection == SnakeDirection.Down)
        //            {
        //                return SnakeDirection.Up;
        //            }
        //        }

        //        return Scan1(currentDirection, X, Y, map, step + 1);
        //    }

        //    return currentDirection;
        //}
        #endregion

    }
}