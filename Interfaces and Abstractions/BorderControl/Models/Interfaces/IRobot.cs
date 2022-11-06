using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models.Interfaces
{
    public interface IRobot:IIdentify
    {
        string Model { get; }
    }
}
