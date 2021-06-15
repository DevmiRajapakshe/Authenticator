using ServiceProvider.Models;
using System.Web.Mvc;
using AuthenticatorInterface;

namespace ServiceProvider.Controllers
{
    //Done by R.W.A.D.U.Rajapakshe 20547312
    public class ADDThreeNumbersController : Controller
    {
        // GET: ADDThreeNumbers
        public ActionResult Index()
        {
            return View();
        }

        //Return the result of addition of two numbers only if the token is validated.
        public JsonResult AddThreeNumbers(int token, int num1, int num2, int num3)
        {
            Connection cn = new Connection();
            ServiceInterface si = cn.getConnection();
            if (si.validate(token).Equals("validated"))
            {
                ADDThreeNumbersModel add1 = new ADDThreeNumbersModel();
                add1.number1 = num1;
                add1.number2 = num2;
                add1.number3 = num3;
                add1.answer = num1 + num2 + num3;
                return Json(add1, JsonRequestBehavior.AllowGet);
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