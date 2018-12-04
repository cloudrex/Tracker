using System;

namespace Tracker {
    public class ChangeTracker
    {
        protected event EventHandler<IterationEvent> OnIteration;
        protected event EventHandler OnEnd;

        protected Change buffer;

        protected readonly string content;
        protected readonly string comparison;

        public ChangeTracker(string content, string comparison)
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
        
        public Change[] Compare()
        {
            Change[] changes = new Change[] { };

            this.OnIteration += (object sender, IterationEvent e) => {
                // TODO
            };

            this.Iterate();
        }

        public void StartChange(int start)
        {
            this.buffer = new Change() { };

            StringBuilder content = new StringBuilder();

            this.OnIteration += (object sender, IterationEvent e) => {
                content.Append(e.Comparison);
            };
        }

        public Change StopChange()
        {
            // TODO
        }
    }
}