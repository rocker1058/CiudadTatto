using CiudadTatto.Controllers;
using CiudadTatto.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiudadTatto.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private usuario oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                oUsuario = (usuario)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {
                    if (filterContext.Controller is LoginUsuarioController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/LoginUsuario/Login");
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

    }
} 