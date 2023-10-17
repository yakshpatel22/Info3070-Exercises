using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesDAL
{
    public enum UpdateStatus
    {
        Ok = 1,
        Failed = -1,
        Stale = -2
    };
}
