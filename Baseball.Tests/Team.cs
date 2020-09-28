namespace Baseball.Tests
{
    internal class Team
    {
        public void AddRun()
        {
            this.Score++;
        }
        public int Score { get; private set; }
    }
}