using System;
using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using TestowanieWebApi.Database;
using TestowanieWebApi.Models;
using TestowanieWebApi.Services;

namespace TestowanieWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {

        private readonly ClientService clientService;


        public ClientController()
        {
            this.clientService = new ClientService(new ClientContext());
        }


        [HttpPost("/AddClient")]
        public ActionResult<Client> AddClient([FromBody] ClientDTO clientDTO)
        {
            return Ok(clientService.AddClient(clientDTO));
        }

        [HttpGet("/GetClients")]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            return Ok(clientService.GetClients());
        }

        [HttpGet("/GetClient")]
        public ActionResult<Client> GetClient(int Id)
        {
            return Ok(clientService.GetClient(Id));
        }


        [HttpDelete("/DeleteClient")]
        public ActionResult<Client> DeleteClient(int Id)
        {
            return Ok(clientService.DeleteClient(Id));
        }


        [HttpPut("/EditClient")]
        public ActionResult<Client> EditClient(int Id, [FromBody] ClientDTO clientDTO)
        {
            return Ok(clientService.EditClient(Id, clientDTO));
        }



    }
}
