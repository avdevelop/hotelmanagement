using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Helpers.CacheHelpers;
using HotelManagement.Web.UserTypeService;
using HotelManagement.DTO;

namespace HotelManagement.Helpers
{
    public class Authenticate : FilterAttribute, IAuthorizationFilter
    {
        private readonly List<UserTypeDTO> acceptedUsers;

        public Authenticate(params UserTypeEnum[] acceptedUserEnums)
        {
            List<UserTypeDTO> userTypes = new List<UserTypeDTO>();
            
            foreach (UserTypeEnum userType in acceptedUserEnums)
            {
                switch (userType)
                {
                    case UserTypeEnum.Admin:
                        userTypes.Add(new UserTypeDTO() { Id = 1, Name = "Admin" });
                        break;
                    case UserTypeEnum.Normal:
                        userTypes.Add(new UserTypeDTO() { Id = 2, Name = "Normal" });
                        break;
                }
            }

            this.acceptedUsers = userTypes;
        }
      
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            UserTypeDTO currentUserType = SessionCache.UserType;

            if (! acceptedUsers.Contains(currentUserType))
            {
                throw new Exception("UnAuthorised");
            }
        }
    }
}