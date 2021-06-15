using ServiceProvider.Models;
using System.Web.Mvc;
using AuthenticatorInterface;

//Done by R.W.A.D.U.Rajapakshe 20547312

namespace ServiceProvider.Controllers
{
    public class MulThreeNumbersController : Controller
    {
        // GET: MulThreeNumbers
        public ActionResult Index()
        {
            return View();
        }

        //Multiplication of three numbers after the successful login
        public JsonResult mulThreeNumbers(int token, int num1, int num2, int num3)
        {
            Connection cn = new Connection();
            ServiceInterface si = cn.getConnection();
            if (si.validate(token).Equals("validated"))
            {
                MulThreeNumbers mul1 = new MulThreeNumbers();
                mul1.number1 = num1;
                mul1.number2 = num2;
                mul1.number3 = num3;
                mul1.answer = num1 * num2 * num3;
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