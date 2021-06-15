using ServiceProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthenticatorInterface;

//Done by R.W.A.D.U.Rajapakshe 20547312

namespace ServiceProvider.Controllers
{
    public class GeneratePrimeNumbersToValueController : Controller
    {
        // GET: GeneratePrimeNumbersToValue
        public ActionResult Index()
        {
            return View();
        }

        //Generate prime numbers upto a value after the successful login of the user
        public JsonResult generatePrimeNumbersToValue(int token, int number1)
        {
            Connection cn = new Connection();
            ServiceInterface si = cn.getConnection();
            if (si.validate(token).Equals("validated"))
            {
                Boolean flag;
                List<int> answer1 = new List<int>();

                for (int i = 2; i <= number1; i++)
                {
                    flag = false;
                    for (int j = 2; j <= i - 1; j++)
                    {
                        if (i % j == 0)
                        {
                            flag = true;
                        }
                    }
                    if (flag == false)
                    {
                        answer1.Add(i);
                    }

                }
                GeneratePrimeNumbersToValue val = new GeneratePrimeNumbersToValue();
                val.endNumber = number1;
                val.answer = answer1;

                return Json(val, JsonRequestBehavior.AllowGet);
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