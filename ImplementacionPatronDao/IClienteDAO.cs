// gquimbayo

using ImplementacionPatronDao;
using System.Collections.Generic;

public interface IClienteDAO
{
    void agregarCliente(Cliente cliente); // Agregar clientes a la tabla
    Cliente consultarCliente(int id);     // Consultar y obtener cliente
    List<Cliente> consultarTodos();  //     Consultar todos lo clientes
    void actualizarCliente(Cliente cliente); // Actualiza informacion cliente
    void eliminarCliente(int id);  // Eliminar cliente
}