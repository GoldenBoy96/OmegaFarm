using System;
using System.Collections.Generic;

namespace Assets.Scripts.Game
{
    internal interface IPredictEvent
    {
        public List<DateTime> GetPredictEvent(DateTime time);
    }
}
