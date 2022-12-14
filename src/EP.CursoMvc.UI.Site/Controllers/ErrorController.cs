using System.Web.Mvc;

namespace EP.CursoMvc.UI.Site.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.AlertaErro = "Ocorreu um erro";
            ViewBag.MensagemErro = "Ocorreu um erro, tente novamente ou contate um administrador";

            return View("Error");
        }

        public ActionResult NotFound()
        {
            ViewBag.AlertaErro = "Não encontrado";
            ViewBag.MensagemErro = "Não existe uma página para a URL informada";

            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            ViewBag.AlertaErro = "Acesso Negado!";
            ViewBag.MensagemErro = "Você não tem permissão para executar isso!";

            return View("Error");
        }
    }
}