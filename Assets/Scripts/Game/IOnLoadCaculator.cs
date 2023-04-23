using System;
using System.Collections.Generic;

namespace Assets.Scripts.Game
{
    internal interface IOnLoadCaculator
    {
        public List<DateTime> OfflineEvent();
    }
}
