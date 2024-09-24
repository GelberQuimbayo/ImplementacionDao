using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacionPatronDao
{

    [ApiController] // Indica que esta clase es un controlador de API
    [Route("api/Cliente")] 
    public class ClienteController : ControllerBase 
    {
        [HttpGet] // Indica que este método maneja solicitudes GET
        public ActionResult<IEnumerable<Cliente>> Get() // Método para obtener la lista de personas
        {
            List<Cliente> clientes = new List<Cliente>{};
            ClienteDAO clienteDAO = new ClienteDAO();
            clientes = clienteDAO.consultarTodos();

            return Ok(clientes); // Retorna un resultado 200 OK con la lista de personas
        }


        [HttpPost] // Indica que este método maneja solicitudes POST
        public ActionResult<Cliente> Post([FromBody] Cliente nuevoCliente) // Método para agregar un nuevo cliente
        {
            ClienteDAO clienteDAO = new ClienteDAO(); // Crea una instancia del DAO para manejar la lógica de negocio
            clienteDAO.agregarCliente(nuevoCliente); // Agrega el nuevo cliente

            // Retorna un resultado 201 Created con un mensaje y el objeto creado
            return CreatedAtAction(nameof(Get), new { id = nuevoCliente.Id }, nuevoCliente); // Asegúrate de que 'Id' sea la propiedad que identifica al cliente
        }

    }
}
