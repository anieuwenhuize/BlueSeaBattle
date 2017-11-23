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

        private void SetNewMissilePosition()
        {
            int newX = (Missile.GetX() > To.GetX()) ? Missile.GetX() - 1 : Missile.GetX() + 1;
            int newY = (Missile.GetY() > To.GetY()) ? Missile.GetY() - 1 : Missile.GetY() + 1;

            this.Missile = new Coordinate(newX, newY);
        }

        public IEnumerable<ICoordinate> GetNextFrame()
        {
            if (IsDone())
            {
                return GetFinalFrame();
            }
            else
            {
                ICoordinate tail = this.Missile;

                SetNewMissilePosition();

                ICoordinate missile = this.Missile;

                return new List<ICoordinate>() { tail, missile };
            }
        }

        public bool IsDone()
        {
            return Coordinate.AreSame(this.Missile, this.To);
        }
    }
}
