using ImplementacionPatronDao;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

class Program
{

    public static async Task Main(string[] args) // Método Main
    {
        IClienteDAO clienteDAO = new ClienteDAO();

        // Agregar un cliente
        //clienteDAO.agregarCliente(new Cliente { Nombre = "siguiente registro", Email = "siguiente@example.com" });

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



        var builder = WebApplication.CreateBuilder(args);


        // Agregar servicios al contenedor
        builder.Services.AddControllers();

        var app = builder.Build();

        // Configurar la canalización de solicitudes
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run("http://localhost:5001"); // se parametriza puerto 5001 se puede poner cualquiera

        Console.WriteLine("API corriendo en http://localhost:5001");
        app.RunAsync();


    }


}
