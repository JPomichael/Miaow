using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace iPow.Presentation.account
{
    public static class iPowPreAccountUiExtension
    {
        //public static MvcHtmlString Label(this HtmlHelper html, string expression)
        //{ 

        //}

        // public static void AddRuleViolations(this ModelStateDictionary modelState,
        //IEnumerable<RuleViolation> errors)
        // {
        //     foreach (RuleViolation issue in errors)
        //     {
        //         modelState.AddModelError(issue.PropertyName, issue.ErrorMessage);
        //     }
        // }

    }

    public static class iPowPreAccountExtension
    {
        public static IList<int> ToIntList(this IList<string> scource)
        {
            var idList = new List<int>();
            foreach (var item in scource)
            {
                var id = -1;
                int.TryParse(item, out id);
                if (id > 0)
                {
                    idList.Add(id);
                }
            }
            return idList;
        }
    }
}