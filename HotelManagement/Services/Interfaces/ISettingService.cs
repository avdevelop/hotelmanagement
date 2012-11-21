﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.Services.Interfaces
{
    public interface ISettingService : IServiceBase
    {
        T Get<T>(string name);
    }
}