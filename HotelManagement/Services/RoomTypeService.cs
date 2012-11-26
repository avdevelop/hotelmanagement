using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Services.Interfaces;
using NHibernate;
using HotelManagement.Models.Mappings;
using HotelManagement.Models;
using HotelManagement.Helpers.ModelHelpers;

namespace HotelManagement.Services
{
    public class RoomTypeService : ServiceBase, IRoomTypeService
    {
        public IEnumerable<RoomType> Get<T>(string nameFormat)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ICriteria criteria = session.CreateCriteria(typeof(T).Name);

            List<RoomType> roomTypes = new List<RoomType>();

            foreach (RoomType roomType in criteria.List().OfType<RoomType>())
            { 
                roomTypes.Add(roomType.Instance(nameFormat));
            }
            
            return roomTypes;
        }        
    }
}