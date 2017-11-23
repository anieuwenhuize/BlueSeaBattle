using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class AnimationLayer : ILayer
    {
        public const int NoValue = 0;
        public const int Missile = 31;
        public const int MissileTail = 32;
        public const int MissileHit = 33;

        private IList<IAnimation> Animations; 

        public AnimationLayer()
        {
            Animations = new List<IAnimation>();
        }

        public int GetDisplayValue(int x, int y)
        {
            IEnumerable<int> values = this.Animations
                .Select(a => a.GetDisplayValue(x, y))
                .Concat(new List<int> { 0 });

            return values.Max();
        }

        public void Add(IAnimation animation)
        {
            this.Animations.Add(animation);
        }

        public void PlayNewFrame()
        {
            foreach(IAnimation animation in this.Animations)
            {
                animation.CalculateNewFrame();
            }
        }

        public bool HasAnimations()
        {
            Recalculate();

            return this.Animations.Any();
        }

        public void Recalculate()
        {
            // Animaties opschonen
            IEnumerable<IAnimation> ToRemove = this.Animations
                .Where(x => x.IsDone())

                // Force execution
                .ToList();

            foreach(IAnimation remove in ToRemove)
            {
                this.Animations.Remove(remove);
            }
        }
    }
}
