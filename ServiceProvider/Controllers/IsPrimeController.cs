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
    public class IsPrimeController : Controller
    {
        // GET: IsPrime
        public ActionResult Index()
        {
            return View();
        }

        //Check if a number is prime or not after checking whether the token is valid
        public JsonResult isPrime(int token, int number) {
            Connection cn = new Connection();
            ServiceInterface si = cn.getConnection();
            if (si.validate(token).Equals("validated"))
            {
                bool flag = false;
                String isPrime;

                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                        flag = true;
                }

                if (number <= 1)
                    flag = true;

                if (flag == true)
                    isPrime = "Number is not prime";
                else
                    isPrime = "Number is prime";

                IsPrime prime = new IsPrime();
                prime.number = number;

                prime.isPrime = isPrime;

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