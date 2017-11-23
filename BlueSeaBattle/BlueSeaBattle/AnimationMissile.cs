using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class AnimationMissile: IAnimation
    {
        private ICoordinate From;
        private ICoordinate To;
        private ICoordinate Tail;
        private ICoordinate Missile;

        public AnimationMissile(ICoordinate from, ICoordinate to)
        {
            From = from;
            To = to;

            Missile = From;
            Tail = Missile;
        }

        private IEnumerable<ICoordinate> GetFinalFrame()
        {
            // TODO: surround with blocks
            return new List<ICoordinate>() { To };
        }

        private ICoordinate GetNewMissilePosition()
        {
            int newX = GetNewPosition(Missile.GetX(), To.GetX());
            int newY = GetNewPosition(Missile.GetY(), To.GetY());

            return new Coordinate(newX, newY);
        }

        private int GetNewPosition(int current, int to)
        {
            if (current == to) return to;

            if (current < to) return current + 1;

            return current - 1;
        }

        public bool IsDone()
        {
            return Coordinate.AreSame(this.Missile, this.To);
        }

        public int GetDisplayValue(int x, int y)
        {
            if(this.Missile.GetX() == x && this.Missile.GetY() == y)
            {
                return AnimationLayer.Missile;
            }

            if (this.Tail.GetX() == x && this.Tail.GetY() == y)
            {
                return AnimationLayer.MissileTail;
            }

            return 0;
        }

        public void CalculateNewFrame()
        {
            this.Tail = this.Missile;

            this.Missile = GetNewMissilePosition();
        }
    }
}
