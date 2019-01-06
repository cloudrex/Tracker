using System;
using System.Text;

namespace Tracker {
    public class DeltaTracker
    {
        protected event EventHandler<IterationEvent> OnIteration;
        protected event EventHandler OnEnd;

        protected Delta buffer;

        protected readonly string content;
        protected readonly string comparison;

        public DeltaTracker(string content, string comparison)
        {
            if (content.Length != comparison.Length) {
                throw new Exception("Currently unable to compare contents with different lengths");
            }

            this.content = content;
            this.comparison = comparison;
        }

        protected void Iterate()
        {
            for (int i = 0; i < this.content.Length; i++) {
                this.OnIteration?.Invoke(this, new IterationEvent() {
                    Character = this.content[i],
                    Comparison = this.comparison[i]
                });
            }
            
            this.OnEnd?.Invoke(this, null);
        }
        
        public Delta[] Compare()
        {
            Delta[] changes = new Delta[] { };

            this.OnIteration += (object sender, IterationEvent e) => {
                // TODO
            };

            this.Iterate();

            // TODO
            throw new NotImplementedException();
        }

        public void StartChange(int start)
        {
            this.buffer = new Delta() { };

            StringBuilder content = new StringBuilder();

            this.OnIteration += (object sender, IterationEvent e) => {
                content.Append(e.Comparison);
            };
        }

        public Delta StopChange()
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}