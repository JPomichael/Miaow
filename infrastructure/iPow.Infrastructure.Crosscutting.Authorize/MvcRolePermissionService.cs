using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public class MvcRolePermissionService : IMvcRolePermissionService
    {
        Domain.Repository.IMvcControllerRolePermissionRepository permissionRepository;

        Domain.Repository.IMvcControllerActionRepository actionRepository;

        Domain.Repository.IMvcControllerClassRepository controllerClassRepository;

        Domain.Repository.IMvcControllerRepository controllerRepository;

        Domain.Repository.IRolesRepository roleRepository;

        public MvcRolePermissionService(Domain.Repository.IMvcControllerRolePermissionRepository permission,
            Domain.Repository.IMvcControllerActionRepository action,
            Domain.Repository.IMvcControllerClassRepository controllerClass,
            Domain.Repository.IMvcControllerRepository controller,
            Domain.Repository.IRolesRepository role)
        {
            if (permission == null)
            {
                throw new ArgumentNullException("permissionService is null");
            }
            if (action == null)
            {
                throw new ArgumentNullException("actionRepository is null");
            }
            if (controllerClass == null)
            {
                throw new ArgumentNullException("controllerClassRepository is null");
            }
            if (controller == null)
            {
                throw new ArgumentNullException("controllerRepository is null");
            }
            if (role == null)
            {
                throw new ArgumentNullException("roleRepository is null");
            }
            permissionRepository = permission;
            actionRepository = action;
            controllerClassRepository = controllerClass;
            controllerRepository = controller;
            roleRepository = role;
        }

        public void Add(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission per)
        {
            permissionRepository.Add(per);
            permissionRepository.Uow.Commit();
        }

        public void Delete(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission per)
        {
            permissionRepository.Delete(per);
            permissionRepository.Uow.Commit();
        }

        public void Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission per)
        {
            permissionRepository.Modify(per);
            permissionRepository.Uow.Commit();
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> GetRolePermissionByRoleId(int roleId)
        {
            var res = permissionRepository.GetList(d => d.RoleId == roleId).AsQueryable();
            return res;
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> GetList()
        {
            var res = permissionRepository.GetList().AsQueryable();
            return res;
        }

        public List<iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcActionDto> GetAllPermissionFromDb()
        {
            var allPermission = new List<iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcActionDto>();
            var allController = controllerRepository.GetList();
            foreach (var item in allController)
            {
                var controllerAction = actionRepository.GetList().Where(e => e.ControllerId == item.Id);
                var controllerClass = controllerClassRepository.GetList().Where(e => e.Id == item.ClassId).FirstOrDefault();
                foreach (var action in controllerAction)
                {
                    var model = new iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcActionDto();
                    model.ActionId = action.Id;
                    model.ActionName = action.Name;
                    model.ActionRemark = action.Remark;
                    model.ControllerClassId = item.ClassId;
                    model.ControllerClassName = controllerClass != null ? controllerClass.Name : "控制器没有分类";
                    model.ControllerId = item.Id;
                    model.ControllerName = item.Name;
                    model.ControllerRemark = item.Remark;
                    allPermission.Add(model);
                }
            }
            return allPermission;
        }
    }
}
