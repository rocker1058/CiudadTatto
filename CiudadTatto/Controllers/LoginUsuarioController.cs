using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiudadTatto.Controllers
{
    public class LoginUsuarioController : Controller
    {
        // GET: LoginUsuario
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User,string Password)
        {
            try
            {   

                using (Models.DB.TattooCityDBEntities1 db = new Models.DB.TattooCityDBEntities1())
                {
                    var oUser = (from d in db.usuario
                                 where d.email == User && d.password == Password.Trim()
                                 select d).FirstOrDefault();
                    if(oUser == null)
                    {
                        ViewBag.Error = "Usuario o contraseña invalido";
                        return View();

                    }

                    Session["User"] = oUser;


                }

                return RedirectToAction("Index", "Home");


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();

                
            }

        }
    }
}