﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.Models;

namespace HotelManagement.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SettingService : ISettingService
    {
        public IEnumerable<Setting> GetSettingByName()
        {
            return new List<Setting>();
        }
    }
}
