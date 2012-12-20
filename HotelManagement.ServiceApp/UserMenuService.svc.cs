using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.DTO;
using HotelManagement.Models;
using AutoMapper;
using HotelManagement.Repository;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserMenuService" in code, svc and config file together.
    public class UserMenuService : IUserMenuService
    {
        private IRepository<UserMenu> userMenuRepository;
        private IRepository<Menu> menuRepository;

        public UserMenuService(IRepository<UserMenu> userMenuRepository,
            IRepository<Menu> menuRepository)
        {
            this.userMenuRepository = userMenuRepository;
            this.menuRepository = menuRepository;
        }

        public IEnumerable<UserMenuDTO> GetAll()
        {
            IEnumerable<UserMenu> userMenus = userMenuRepository.Get().ToList();
            return Mapper.Map<IEnumerable<UserMenu>, IEnumerable<UserMenuDTO>>(userMenus);
        }

        public UserMenuDTO GetUserMenu(int id)
        {
            return Mapper.Map<UserMenu, UserMenuDTO>(userMenuRepository.Get(id));
        }

        public void Save(UserMenuDTO obj)
        {
            userMenuRepository.Save(Mapper.Map<UserMenuDTO, UserMenu>(obj));
        }

        public void Delete(UserMenuDTO obj)
        {
            userMenuRepository.Delete(Mapper.Map<UserMenuDTO, UserMenu>(obj));
        }

        public IEnumerable<UserMenuDTO> GetByUser(int userId)
        {
            IEnumerable<UserMenu> userMenus = userMenuRepository.Get().Where(um => um.User.Id == userId);
            return Mapper.Map<IEnumerable<UserMenu>, IEnumerable<UserMenuDTO>>(userMenus);
        }
    }
}
