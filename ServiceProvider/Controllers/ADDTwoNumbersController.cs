using ServiceProvider.Models;
using System.Web.Mvc;
using AuthenticatorInterface;

namespace ServiceProvider.Controllers
{
    //Done by R.W.A.D.U.Rajapakshe 20547312
    public class ADDTwoNumbersController : Controller
    {
        // GET: ADDTwoNumbers
        public ActionResult Index()
        {
            return View();
        }

        //Return the result of addition of three numbers only if the token is validated.
        public JsonResult AddTwoNumbers(int token, int num1, int num2) {
            Connection cn = new Connection();
            ServiceInterface si = cn.getConnection();
            if (si.validate(token).Equals("validated"))
            {
                ADDTwoNumbersModel add1 = new ADDTwoNumbersModel();
                add1.number1 = num1;
                add1.number2 = num2;
                add1.answer = num1 + num2;
                return Json(add1, JsonRequestBehavior.AllowGet);
            }
            else {
                UnSuccess unsuccess = new UnSuccess();
                unsuccess.Status = "Denied";
                unsuccess.Reason = "Authentication Error";
                return Json(unsuccess, JsonRequestBehavior.AllowGet);
            }
                
        }
    }
}