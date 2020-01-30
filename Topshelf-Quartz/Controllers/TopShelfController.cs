using System.Web.Http;

namespace TopshelfQuartz.Controllers
{
    public class TopShelfController : ApiController
    {
        [HttpGet]
        public string Get() {

            return "Hola mundo TopShelfController";
        }
    }
}
