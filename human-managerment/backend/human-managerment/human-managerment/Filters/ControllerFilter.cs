using HumanManagermentBackend.Contants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Filters
{
    public class ControllerFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string reqMethod = context.HttpContext.Request.Method;
            string path = context.HttpContext.Request.Path.Value;

            if (!path.Equals("/users/login")) {
                var identity = context.HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    string userResources = identity.FindFirst(SecurityContant.USER_RESOURCE_CLAIMS).Value;
                    bool havePassing = IsPassing(path, reqMethod, userResources);
                    if (!havePassing)
                        throw new Exception(SecurityContant.NOT_AUTHORIZE);
                }
            }

           // bool boo = pathName.Contains("employees");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }

        private bool IsPassing(string path, string reqMethod, string userResources)
        {

            bool result = false;

            // kiem tra action
            string[] actions = userResources.Split(SecurityContant.ACTION_SEPARATOR);
            foreach (var act in actions.ToList()) {
                // remove "/" ra khoi path
                if (act.Contains(path.Substring(1)))
                {
                    // tach action vs request method
                    string[] parts = act.Split(SecurityContant.ACTION_REQUESTMETHOD_SEPARATOR);
                    // kiem tra request method
                    string[]  reqMethods = parts[1].Split(SecurityContant.REQUESTMETHOD_SEPARATOR);
                    foreach (var ele in reqMethods)
                    {
                        if (ele.Equals(reqMethod.ToLower()))
                        {
                            result = true;
                            break;
                        }
                    }  
                }
            }

            return result;
        }
    }
}
