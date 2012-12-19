using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Helpers.CacheHelpers;
using HotelManagement.Web.UserTypeService;

namespace HotelManagement.Helpers
{
    public class Authenticate : FilterAttribute, IAuthorizationFilter
    {
        private readonly List<HotelManagement.Web.UserService.UserTypeDTO> acceptedUsers;

        public Authenticate(params UserTypeEnum[] acceptedUserEnums)
        {
            List<HotelManagement.Web.UserService.UserTypeDTO> userTypes = new List<HotelManagement.Web.UserService.UserTypeDTO>();
            
            foreach (UserTypeEnum userType in acceptedUserEnums)
            {
                switch (userType)
                {
                    case UserTypeEnum.Admin:
                        userTypes.Add(new HotelManagement.Web.UserService.UserTypeDTO() { Id = 1, Name = "Admin" });
                        break;
                    case UserTypeEnum.Normal:
                        userTypes.Add(new HotelManagement.Web.UserService.UserTypeDTO() { Id = 2, Name = "Normal" });
                        break;
                }
            }

            this.acceptedUsers = userTypes;
        }
      
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            HotelManagement.Web.UserService.UserTypeDTO currentUserType = SessionCache.UserType;

            if (! acceptedUsers.Contains(currentUserType))
            {
                throw new Exception("UnAuthorised");
            }
        }
    }
}