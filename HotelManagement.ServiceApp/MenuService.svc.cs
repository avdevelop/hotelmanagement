using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AutoMapper;
using HotelManagement.Repository;
using HotelManagement.Models;
using HotelManagement.ServiceApp.DTO;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MenuService" in code, svc and config file together.
    public class MenuService : IMenuService
    {
        private IRepository<Menu> menuRepository;

        public MenuService(IRepository<Menu> menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public IEnumerable<MenuDTO> GetAll()
        {
            IEnumerable<Menu> menus = menuRepository.Get().ToList();
            IEnumerable<MenuDTO> a = Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuDTO>>(menus);
            
            return a;
        }

        public MenuDTO GetMenu(int id)
        {
            return Mapper.Map<Menu, MenuDTO>(menuRepository.Get(id));
        }

        public void Save(MenuDTO obj)
        {
            menuRepository.Save(Mapper.Map<MenuDTO, Menu>(obj));
        }

        public void Delete(MenuDTO obj)
        {
            menuRepository.Delete(Mapper.Map<MenuDTO, Menu>(obj));
        }
    }
}
