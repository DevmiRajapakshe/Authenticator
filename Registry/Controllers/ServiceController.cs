using System;
using System.Web.Mvc;
using Registry.Models;
using System.IO;
using System.ServiceModel;
using AuthenticatorInterface;

namespace Registry.Controllers
{
    //Done by R.W.A.D.U.Rajapakshe 20547312
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }


        //publish details after validation of the token.
        public JsonResult getDetails(int token, String result) {

            Connection cn = new Connection();
            ServiceInterface si = cn.getConnection();
            if (si.validate(token).Equals("validated"))
            {
                try
                {
                    using (StreamWriter file = new StreamWriter("C:\\Users\\devmi\\source\\repos\\Authenticator\\Registry\\bin\\publish.txt", true))
                    {
                        file.WriteLine(result + "\n");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return Json(result, JsonRequestBehavior.AllowGet);
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