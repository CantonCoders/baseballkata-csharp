namespace Baseball.Tests
{
    internal class Diamond
    {
        private Base[] bases = new Base[4];
        internal bool IsThirdBaseLoaded
        {
            get { return this.bases[3].IsLoaded; }
            set { this.bases[3].IsLoaded = value; }
        }

        internal bool IsSecondBaseLoaded
        {
            get { return this.bases[2].IsLoaded; }
            set { this.bases[2].IsLoaded = value; }
        }

        internal bool IsFirstBaseLoaded
        {
            get { return this.bases[0].IsLoaded; }
            set { this.bases[0].IsLoaded = value; }
        }

        internal bool AreBasesLoaded()
        {
            return IsFirstBaseLoaded
                                   && this.IsSecondBaseLoaded
                                   && this.IsThirdBaseLoaded;
        }
        public Diamond()
        {
            for (int i = 0; i < 4; i++)
            {
                bases[i] = new Base();
            }
        }
    }
}