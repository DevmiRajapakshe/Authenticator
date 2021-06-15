using ServiceProvider.Models;
using System.Web.Mvc;
using AuthenticatorInterface;

//Done by R.W.A.D.U.Rajapakshe 20547312

namespace ServiceProvider.Controllers
{
    public class MulTwoNumbersController : Controller
    {
        // GET: MulTwoNumbers
        public ActionResult Index()
        {
            return View();
        }

        //Multiplication of two numbers after checking whether the token is valid
        public JsonResult mulTwoNumbers(int token, int num1, int num2)
        {
            Connection cn = new Connection();
            ServiceInterface si = cn.getConnection();
            if (si.validate(token).Equals("validated"))
            {
                MulTwoNumbers mul1 = new MulTwoNumbers();
                mul1.number1 = num1;
                mul1.number2 = num2;
                mul1.answer = num1 * num2;
                return Json(mul1, JsonRequestBehavior.AllowGet);
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