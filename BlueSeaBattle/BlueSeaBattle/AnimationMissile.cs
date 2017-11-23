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
            int newX = (Missile.GetX() > To.GetX()) ? Missile.GetX() - 1 : Missile.GetX() + 1;
            int newY = (Missile.GetY() > To.GetY()) ? Missile.GetY() - 1 : Missile.GetY() + 1;

            return new Coordinate(newX, newY);
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
