using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Tarea_03_a_SignalR.Model;
namespace Tarea_03_a_SignalR.Hubs

{
    public class LoginHub : Hub
    {
        private readonly ILogger<LoginHub> _logger;
        public LoginHub(ILogger<LoginHub> logger)
        {
            _logger = logger;
        }

        public void LoginF(string email, string pass) {
            _logger.LogInformation(" SignalR identificacion del usuario: " + Context.ConnectionId);
            _logger.LogInformation(" Loading ....");
              
                    //Simulo el envio de un mail al cliente
                    string usrId = Context.ConnectionId;
                    _logger.LogInformation($"**************** Url para acceder a verificacion *************************");
                   
                    //Si bien la misma viaja encriptada, la url queda en el historial del browser
                    _logger.LogInformation($"\n");
                    _logger.LogInformation($"curl https://localhost:7136/verificar/usuario/{usrId}");
        }
        public void EnviarVerificacionOk()
        {
            Clients.User(Context.UserIdentifier).SendAsync("VerificacionOk", "");
        }
    }
}
