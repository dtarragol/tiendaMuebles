using System;
using Ventas.objetos;
using Ventas;



internal class Program
{
    
    private static void Main(string[] args)
    {   
       
        Operaciones operaciones = new Operaciones();
 /*     List<SingleVenta> lista= new List<SingleVenta>();
        List<Armario> listaArmarios = new List<Armario>();
        List<Escritorio> listaEscritorios = new List<Escritorio>();
        List<ClienteVIP> listaClienteVIP = new List<ClienteVIP>();
        List<ClienteS> listaClienteStandar = new List<ClienteS>();
*/
        List<Tuple<string, object>> listaDeListas = new List<Tuple<string, object>>();




        //CARGA DE DATOS INICIALES
            //ARTICULOS
        //armarios
        /*listaArmarios=operaciones.DatosInicialesArmarios();
        //escritorios
        listaEscritorios=operaciones.DatosInicialesEscritorios();
            //CLIENTES
        listaClienteStandar=operaciones.DatosInicialesClientesEstandar();
        listaClienteVIP=operaciones.DatosInicialesClientesVIP();
            //VENTAS
        lista=operaciones.DatosInicialesVentas(listaArmarios, listaClienteStandar,listaClienteVIP);
        */
        listaDeListas=operaciones.cargaDatosInicial();


        // logica del programa
        operaciones.LOGICA(listaDeListas);
    }
}
