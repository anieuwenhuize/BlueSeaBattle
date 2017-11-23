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

        private MissileEffect Effect;

        private bool ShowFinalFrame;
        private bool FinalFrameShowed;

        public AnimationMissile(ICoordinate from, ICoordinate to, MissileEffect effect)
        {
            From = from;
            To = to;
            Effect = effect;

            Missile = From;
            Tail = Missile;

            ShowFinalFrame = false;
            FinalFrameShowed = false;
        }

        private int ShowSphere(int x, int y, int effect)
        {
            int minX = To.GetX() - 1;
            int maxX = To.GetX() + 1;

            int minY = To.GetY() - 1;
            int maxY = To.GetY() + 1;

            if (x >= minX && x <= maxX && y >= minY && y <= maxY)
            {
                return effect;
            }

            return 0;
         }

        private int GetFinalFrameDisplayValue(int x, int y)
        {
           
            if(Effect == MissileEffect.HitAndCatched)
            {
                ShowSphere(x, y, AnimationLayer.MissileCatched);
            }

            if(Effect == MissileEffect.HitAndDamage)
            {
                ShowSphere(x, y, AnimationLayer.MissileHit);
            }

            if (Effect == MissileEffect.HitAndDamage)
            {
                return AnimationLayer.MissileHit;
            }

            return 0;
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
            return Coordinate.AreSame(this.Missile, this.To) && FinalFrameShowed;
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

            if (Coordinate.AreSame(this.Missile, this.To) && this.ShowFinalFrame)
            {
                return GetFinalFrameDisplayValue(x, y);
            }

            return 0;
        }

        public void CalculateNewFrame()
        {
            this.Tail = this.Missile;

            this.Missile = GetNewMissilePosition();

            if (Coordinate.AreSame(this.Missile, this.To))
            {
                if (! ShowFinalFrame)
                {
                    ShowFinalFrame = true;
                }
                else
                {
                    this.FinalFrameShowed = true;
                }   
            }
        }
    }
}
