using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public enum OrderStates
    {
        New = 1,
        Pending = 2,
        Rejected = 3,
        Complete = 4
    }
}
