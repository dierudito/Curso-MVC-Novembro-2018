using System.Web.Mvc;

namespace EP.CursoMvc.Infra.CrossCutting.Filters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // LOG de Auditoria

            if (filterContext.Exception != null)
            {
                // Manipular a EX
                // Injetar alguma LIB de tratamento de erro
                //  -> Gravar log do erro no BD
                //  -> Email para o admin
                //  -> Retornar cod de erro amigavel

                // SEMPRE USE ASYNC AQUI DENTRO

                filterContext.ExceptionHandled = true;
                filterContext.Result = new HttpStatusCodeResult(500);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}