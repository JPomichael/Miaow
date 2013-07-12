using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public class AssemblyControllerService
    {
        static readonly List<string> mvcActionResultTypeList = new List<string>()
        {
            "ActionResult","ContentResult","EmptyResult","HttpUnauthorizedResult",
            "JavaScriptResult","JsonResult","FileResult","FileContentResult",
            "FilePathResult","FileStreamResult","RedirectResult","RedirectToRouteResult",
            "ViewResultBase","ViewResult","PartialViewResult"
        };

        public List<Comm.Dto.ControllerInfoListDto> GetControllerInfoFromAssembly(Assembly assembly)
        {
            List<Comm.Dto.ControllerInfoListDto> controllerList = new List<Comm.Dto.ControllerInfoListDto>();
            var currentControllerList = assembly.GetTypes().Where(e => e.FullName.EndsWith("Controller"));
            Comm.Dto.ControllerInfoListDto temp = null;
            foreach (var controller in currentControllerList)
            {
                temp = new Comm.Dto.ControllerInfoListDto();
                temp.ActionNameList = new List<string>();
                foreach (var method in controller.GetMethods())
                {
                    //结尾是Result 并且是Public
                    if (IsMvcActionResult(method.ReturnType) && method.IsPublic)
                    {
                        if (!temp.ActionNameList.Contains(method.Name))
                        {
                            temp.ContorllerType = controller;
                            temp.ActionNameList.Add(method.Name);
                        }
                    }
                }
                controllerList.Add(temp);
            }
            return controllerList;
        }

        public List<Comm.Dto.ControllerInfoListDto> GetControllerInfoFromAssembly(string assemblyFullName)
        {
            Assembly currentAssembly = Assembly.Load(assemblyFullName);
            return GetControllerInfoFromAssembly(currentAssembly);
        }

        private bool IsMvcActionResult(Type target)
        {
            var res = false;
            if (mvcActionResultTypeList.Contains(target.Name))
            {
                res = true;
            }
            else
            {
                Type temp = target.BaseType;
                do
                {
                    var copy = temp;
                    if (temp != null)
                    {
                        if (mvcActionResultTypeList.Contains(temp.Name))
                        {
                            res = true; break;
                        }
                        temp = copy.BaseType;
                    }
                } while (temp != null);
            }
            return res;
        }
    }
}
