using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace TpFinalKofi.WebApi.Controllers
{
    [ApiController]
    [Route("Clientes")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [Route("GetClientes")]
        public IActionResult GetClientes()
        {
            var clientes = _clienteRepository.ObtenerTodos();
            return Ok(clientes);
        }

        [HttpPost]
        [Route("InsertarCliente")]
        public IActionResult InsertarCliente(Cliente cliente)
        {
            _clienteRepository.InsertarCliente(cliente);
            return Ok(cliente);
        }

        [HttpPut]
        [Route("ModificarCliente/{id}")]
        public IActionResult ModificarCliente(int id, Cliente cliente)
        {
            var clienteExistente = _clienteRepository.ObtenerPorId(id);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Apellido = cliente.Apellido;
            clienteExistente.Edad = cliente.Edad;
            clienteExistente.Ciudad = cliente.Ciudad;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Nacionalidad = cliente.Nacionalidad;
            clienteExistente.FechaDeNacimiento = cliente.FechaDeNacimiento;

            _clienteRepository.ModificarCliente(clienteExistente);

            return Ok(clienteExistente);
        }

        [HttpDelete]
        [Route("EliminarCliente/{id}")]
        public IActionResult EliminarCliente(int id)
        {
            var clienteExistente = _clienteRepository.ObtenerPorId(id);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            _clienteRepository.EliminarCliente(clienteExistente);

            return Ok();
        }
    }
}