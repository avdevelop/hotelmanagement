using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.DTO;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISettingService" in both code and config file together.
    [ServiceContract]
    public interface ISettingService
    {
        [OperationContract]
        IEnumerable<SettingDTO> GetAll();

        [OperationContract]
        SettingDTO GetSetting(int id);

        [OperationContract]
        void Save(SettingDTO obj);

        [OperationContract]
        void Delete(SettingDTO obj);

        [OperationContract]
        SettingDTO GetByName(string name);
    }
}
