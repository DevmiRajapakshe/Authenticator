using ServiceProvider.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AuthenticatorInterface;

namespace ServiceProvider.Controllers
{
    //Done by R.W.A.D.U.Rajapakshe 20547312
    public class GeneratePrimeNumbersInRangeController : Controller
    {
        // GET: GeneratePrimeNumbersInRange
        public ActionResult Index()
        {
            return View();
        }
        //Generate prime numbers within a particular range(Including the start and end numbers) only if the login of the user is successful
        public JsonResult generatePrimeNumberInRange(int token, int startNumber, int endNumber) {
            Connection cn = new Connection();
            ServiceInterface si = cn.getConnection();
            if (si.validate(token).Equals("validated"))
            {
                Boolean flag;
                List<int> answer = new List<int>();

                for (int i = startNumber; i <= endNumber; i++)
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
                        answer.Add(i);
                    }

                }
                GeneratePrimeNumbersInRange prime = new GeneratePrimeNumbersInRange();
                prime.startNumber = startNumber;
                prime.endNumber = endNumber;
                prime.answer = answer;
                return Json(prime, JsonRequestBehavior.AllowGet);
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