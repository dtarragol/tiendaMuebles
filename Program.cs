using System;
using Ventas.objetos;
using Ventas;



internal class Program
{
    
    private static void Main(string[] args)
    {   
        Operaciones operaciones = new Operaciones();
        List<SingleVenta> lista= new List<SingleVenta>();
        List<Armario> listaArmarios = new List<Armario>();
        List<ClienteVIP> listaClienteVIP = new List<ClienteVIP>();
        List<ClienteS> listaClienteStandar = new List<ClienteS>();

        //CARGA DE DATOS INICIALES
        //carga inicial de armarios
        listaArmarios=operaciones.DatosInicialesArmarios();
        //carga inicial de clientes
        listaClienteStandar=operaciones.DatosInicialesClientesEstandar();
        listaClienteVIP=operaciones.DatosInicialesClientesVIP();
        //carga inicial de ventas
        lista=operaciones.DatosInicialesVentas(listaArmarios, listaClienteStandar,listaClienteVIP);
        
        // logica del programa
        operaciones.LOGICA(lista,listaArmarios,listaClienteVIP,listaClienteStandar);
    }
}
