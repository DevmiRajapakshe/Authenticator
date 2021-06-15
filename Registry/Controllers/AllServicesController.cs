using System.Collections.Generic;
using System.Web.Mvc;
using System.IO;
using AuthenticatorInterface;
using Registry.Models;

namespace Registry.Controllers
{
    //Done by R.W.A.D.U.Rajapakshe 20547312
    public class AllServicesController : Controller
    {
        // GET: AllServices
        public ActionResult Index()
        {
            return View();
        }

        //All Services (With Validation)
        public JsonResult getAllServices(int token)
        {
            Connection cn = new Connection();
            ServiceInterface sInterface = cn.getConnection();
            if (sInterface.validate(token).Equals("validated"))
            {
                List<string> results = new List<string>();
                using (StreamReader s = new StreamReader("C:\\Users\\devmi\\source\\repos\\Authenticator\\Registry\\bin\\publish.txt"))
                {
                    string data;
                    while ((data = s.ReadLine()) != null)
                    {
                        results.Add(data + " ");
                    }
                }
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            else
            {
                UnSuccess unsuccess = new UnSuccess();
                unsuccess.Status = "Denied";
                unsuccess.Reason = "Authentication Error";
                return Json(unsuccess, JsonRequestBehavior.AllowGet);
            }
        }
    }
}