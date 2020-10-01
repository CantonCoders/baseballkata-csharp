namespace Baseball.Tests
{
    internal class Score
    {
        public void AddRun()
        {
            this.Runs++;
        }
        public int Runs { get; private set; }
    }
}