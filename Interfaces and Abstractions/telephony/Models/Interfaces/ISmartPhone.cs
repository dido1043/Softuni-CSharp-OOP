using System;
using System.Collections.Generic;
using System.Text;

namespace telephony.Models.Interfaces
{
    interface ISmartPhone : IStationaryPhone
    {
        string Browsing(string url);
    }
}
