﻿using System;

namespace Baseball.Tests
{
    internal class Diamond
    {
        private Base[] bases = new Base[4];
        private ScoreBoard inning;

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

        internal void RunBases(AtBatResult atBat)
        {
            if (atBat == AtBatResult.SINGLE)
            {
                RunToFirst();
                return;
            }

            if (atBat == AtBatResult.HOMERUN)
            {
                inning.AddRun();
            }

            if (atBat == AtBatResult.DOUBLE)
            {
                if (IsSecondBaseLoaded)
                {
                    inning.AddRun();
                }
                IsSecondBaseLoaded = true;
                return;
            }

            if (atBat == AtBatResult.TRIPLE)
            {
                RunTriple();
                return;
            }
        }

        private void RunTriple()
        {
            if (IsFirstBaseLoaded)
            {
                inning.AddRun();
            }
            if (IsSecondBaseLoaded)
            {
                inning.AddRun();
            }
            if (IsThirdBaseLoaded)
            {
                inning.AddRun();
            }
            else if (!IsThirdBaseLoaded)
            {
                IsThirdBaseLoaded = true;
            }
        }
        
        private void RunToFirst()
        {
            if (IsFirstBaseLoaded)
            {
                RunToSecond();
            }
            IsFirstBaseLoaded = true;
        }
        private void RunToThird()
        {
            if (IsThirdBaseLoaded)
            {
                inning.AddRun();
            }
            IsThirdBaseLoaded = true;
        }
        private void RunToSecond()
        {
            if(IsSecondBaseLoaded)
            {
                RunToThird();
            }
            IsSecondBaseLoaded = true;
        }
        public Diamond(ScoreBoard inning)
        {
            for (int i = 0; i < 4; i++)
            {
                bases[i] = new Base();
            }
            this.inning = inning;
        }
    }
}