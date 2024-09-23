﻿using ImplementacionPatronDao;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        IClienteDAO clienteDAO = new ClienteDAO();

        // Agregar un cliente
        clienteDAO.agregarCliente(new Cliente { Nombre = "siguiente registro", Email = "siguiente@example.com" });

        // Obtener un cliente
        Cliente cliente = clienteDAO.consultarCliente(1);
        if (cliente != null)
        {
            Console.WriteLine($"Cliente: {cliente.Nombre}, Email: {cliente.Email}");
        }

        // Obtener todos los clientes
        List<Cliente> clientes = clienteDAO.consultarTodos();
        foreach (var cli in clientes)
        {
            Console.WriteLine($"Id: {cli.Id}, Nombre: {cli.Nombre}, Email: {cli.Email}");
        }

        // Actualizar un cliente
        if (cliente != null)
        {
            cliente.Nombre = "Juan Actualizado";
            clienteDAO.actualizarCliente(cliente);
        }

        // Eliminar un cliente
        clienteDAO.eliminarCliente(1);
    }
}
