using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Models;
using HotelManagement.Helpers.CacheHelpers;

namespace HotelManagement.Helpers
{
    public class Authenticate : FilterAttribute, IAuthorizationFilter
    {
        private readonly List<UserType> acceptedUsers;

        public Authenticate(params UserTypeEnum[] acceptedUserEnums)
        {
            List<UserType> userTypes = new List<UserType>();
            
            foreach (UserTypeEnum userType in acceptedUserEnums)
            {
                switch (userType)
                {
                    case UserTypeEnum.Admin:
                        userTypes.Add(new UserType(1, "Admin"));
                        break;
                    case UserTypeEnum.Normal:
                        userTypes.Add(new UserType(2, "Normal"));
                        break;
                }
            }

            this.acceptedUsers = userTypes;
        }
      
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            UserType currentUserType = SessionCache.UserType;

            if (! acceptedUsers.Contains(currentUserType))
            {
                throw new Exception("UnAuthorised");
            }
        }
    }
}