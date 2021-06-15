using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using AuthenticatorInterface;
using Registry.Models;

namespace Registry.Controllers
{
    //Done by R.W.A.D.U.Rajapakshe 20547312
    public class UnpublishController : Controller
    {
        // GET: Unpublish
        public ActionResult Index()
        {
            return View();
        }

        //Unpublish data after validating the token.
        public JsonResult unpublishData(int token, Uri val)
        {
            Connection cn = new Connection();
            ServiceInterface si = cn.getConnection();
            if (si.validate(token).Equals("validated"))
            {
                List<string> details = System.IO.File.ReadAllLines("C:\\Users\\devmi\\source\\repos\\Authenticator\\Registry\\bin\\publish.txt").ToList();

                List<string> values = new List<string>();

                foreach (string serviceDetails in details)
                {
                    if (!serviceDetails.Contains(val.ToString()))
                    {
                        values.Add(serviceDetails);

                    }
                }

                System.IO.File.WriteAllText("C:\\Users\\devmi\\source\\repos\\Authenticator\\Registry\\bin\\publish.txt", string.Empty);

                foreach (string v in values)
                {
                    try
                    {
                        using (StreamWriter file = new StreamWriter("C:\\Users\\devmi\\source\\repos\\Authenticator\\Registry\\bin\\publish.txt", true))
                        {
                            file.WriteLine(v);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                return Json(values, JsonRequestBehavior.AllowGet);
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