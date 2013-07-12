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

        public bool Add(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    permissionRepository.Add(entity);
                    permissionRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Add(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                try
                {
                    foreach (var item in entity)
                    {
                        if (item != null)
                        {
                            permissionRepository.Add(item);
                        }
                    }
                    permissionRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(Data.DataSys.Sys_MvcControllerRolePermission entity, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    entity.State = false;
                    permissionRepository.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(IList<Data.DataSys.Sys_MvcControllerRolePermission> entity, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                try
                {
                    foreach (var item in entity)
                    {
                        if (item != null)
                        {
                            item.State = false;
                            permissionRepository.Modify(item);
                        }
                    }
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(IList<int> idList, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (idList != null && idList.Count > 0)
            {
                var delete = permissionRepository.GetList(e => idList.Contains(e.Id)).ToList();
                if (delete != null && delete.Count > 0)
                {
                    res = Delete(delete, operUser);
                }
            }
            return res;
        }

        public bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    permissionRepository.Delete(entity);
                    permissionRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool DeleteTrue(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                try
                {
                    foreach (var item in entity)
                    {
                        if (item != null)
                        {
                            permissionRepository.Delete(item);
                        }
                    }
                    permissionRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool DeleteTrue(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (idList != null && idList.Count > 0)
            {
                var delete = permissionRepository.GetList(e => idList.Contains(e.Id)).ToList();
                if (delete != null && delete.Count > 0)
                {
                    res = DeleteTrue(delete, operUser);
                }
            }
            return res;
        }

        public bool Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Id > 0)
            {
                try
                {
                    permissionRepository.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Modify(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                try
                {
                    foreach (var item in entity)
                    {
                        if (item != null)
                        {
                            permissionRepository.Modify(item);
                        }
                    }
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public Data.DataSys.Sys_MvcControllerRolePermission Get(int Id)
        {
            var data = permissionRepository.GetList(e => e.Id == Id).FirstOrDefault();
            return data;
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> GetList()
        {
            var res = permissionRepository.GetList().AsQueryable();
            return res;
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> GetRolePermissionByRoleId(int roleId)
        {
            var res = permissionRepository.GetList(d => d.RoleId == roleId).AsQueryable();
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
