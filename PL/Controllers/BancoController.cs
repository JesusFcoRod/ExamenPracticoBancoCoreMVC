using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class BancoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Banco banco= new ML.Banco();
            ML.Result result = BL.Banco.GetAll();

            if (result.Correct)
            {
                banco.Bancos = result.Objects;
                return View(banco); 
            }
            else
            {
                return View(banco);
            }
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View();
            
        }
    }
}
