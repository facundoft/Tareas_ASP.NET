using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController] //Esto es un atributo que es utilizada en tiempo de ejecución
                    //para agregar comportamiento a la clase (idem to anotacion en java)    
                    //Indica que el controlador responde a peticiones web
    
    [Route("api/tareas")]
    public class TareaController : Controller
    {
        private readonly ILogger<TareaController> _logger;
        private IList<Tarea> _tareaList;

        public TareaController(ILogger<TareaController> logger) {
            this._logger = logger;

            this._tareaList = new List<Tarea>();
            this._tareaList.Add(new Tarea(1,"tarea1","t1",1,"encargado"));
            this._tareaList.Add(new Tarea(2, "tarea2", "t2", 2, "encargado"));
            this._tareaList.Add(new Tarea(3, "tarea3", "t3", 3, "encargado"));
        }


        [HttpGet] // endpoit asociado al metodo GET
        public ActionResult<IList<Tarea>> GetAll()
        //ActionResult es la clase base de todos los tipos posibles de respuesta del endpoint
        //(ViewResult, PartialViewResult, ContentResult, EmptyResult, JsonResult)
        {
            _logger.LogInformation("Retorno lista de taraes");
            return Ok(_tareaList.ToList());
        }

        [HttpGet]
        [Route("{id}")] //obtengo parámetro desde la url
        public ActionResult<Tarea> GetById(int id)
        {
            _logger.LogInformation($"Retorno tarea en posicion {id}"); // formato de interpolación de cadenas
            return Ok(_tareaList[id]);
        }

        [HttpPost] //ejemplo de post
        public ActionResult Nuevo([FromBody] Tarea tarea) //notese el atributo FromBody
        {
            _logger.LogInformation("Nueva tarea");
            this._tareaList.Add(tarea);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Borrar(int id)
        {
            _logger.LogInformation("Borrar tarea");
            this._tareaList.RemoveAt(id);
            return Ok();
        }

    }
}
