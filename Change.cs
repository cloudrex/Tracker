namespace Tracker {
    public struct Delta {
        public int Start { get; set; }

        public string Content { get; set; }

        public int End => this.Start + this.Content.Length;
    }
}