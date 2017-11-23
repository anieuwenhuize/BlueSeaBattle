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
        private ICoordinate CurrentState;

        public AnimationMissile()
        {

        }

        private IEnumerable<ICoordinate> GetFinalFrame()
        {
            // TODO: surround with blocks
            return new List<ICoordinate>() { To };
        }

        private void SetNewCurrentState()
        {

        }

        public IEnumerable<ICoordinate> GetNextFrame()
        {
            if (IsDone())
            {
                return GetFinalFrame();
                
            }
            else
            {
                ICoordinate tail = this.CurrentState;

                SetNewCurrentState();

                ICoordinate missile = this.CurrentState;

                return new List<ICoordinate>() { tail, missile };
            }
        }

        public bool IsDone()
        {
            return Coordinate.AreSame(this.CurrentState, this.To);
        }
    }
}
