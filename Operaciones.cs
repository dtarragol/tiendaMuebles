using Ventas.objetos;
using System.Xml.Linq;
using System;
using System.Collections.Generic;


namespace Ventas
{
    public class Operaciones 
    {
        //CONSTRUCTOR
        public Operaciones()
        {

        }
        
        //CARGA DE DATOS INICIAL
        /*
        public List<Escritorio> DatosInicialesEscritorios()
        {
            List<Escritorio> lista= new List<Escritorio>();
            lista.Add(new Escritorio(600, "Escritorio bonito", "EscritorioIKEA",2,1,1));
            lista.Add(new Escritorio(400, "Escritorio grande", "EscritorioIKEA2",(decimal)2.5,(decimal)1.2,1));
            lista.Add(new Escritorio(100, "Escritorio pequeño", "EscritorioIKEA3",2,(decimal)0.5,1));
            return lista;
        }
        public List<Armario> DatosInicialesArmarios()
        {
            List<Armario> lista = new List<Armario>();
            lista.Add(new Armario(500, "Armario bonito", "ArmarioIKEA", 5));
            lista.Add(new Armario(1000, "Armario grande", "ArmarioIKEA2", 10));
            lista.Add(new Armario(90, "Armario pequeño", "ArmarioIKEA3", 2));
            return lista;
        }
        public List<SingleVenta> DatosInicialesVentas(List<Armario> listaArmarios,List<ClienteS> listaClientesE,List<ClienteVIP> listaClientesVIP )
        {
            List<SingleVenta> lista = new List<SingleVenta>();
            lista.Add(new SingleVenta(2, "Venta00", listaArmarios[0],listaClientesE[0]));
            lista.Add(new SingleVenta(3, "Venta01", listaArmarios[1],listaClientesVIP[0]));
            lista.Add(new SingleVenta(10, "Venta02", listaArmarios[2],listaClientesE[1]));
            return lista;
        }
        public List<ClienteS> DatosInicialesClientesEstandar()
        {
            List<ClienteS> lista = new List<ClienteS>();
            lista.Add(new ClienteS("19432310y","Dídac","Tarragó","López","Barcelona"));
            lista.Add(new ClienteS("49432310y","Pepe","Pepin","Pepon","Madrid"));
            lista.Add(new ClienteS("59432310y","Paula","Fernandez","Fernandez","Toledo"));
            return lista;
        }
        public List<ClienteVIP> DatosInicialesClientesVIP()
        {
            List<ClienteVIP> lista = new List<ClienteVIP>();
            lista.Add(new ClienteVIP("69432310y","Diego","Lopez","López","Bilbao",50));
            lista.Add(new ClienteVIP("79432310y","Antonia","Pepan","Pepon","Sabadell",25));
            lista.Add(new ClienteVIP("89432310y","Pablo","Duque","Fernandez","Terrasa",15));
            return lista;
        }*/

        public List<Tuple<string, object>> cargaDatosInicial()
        {
            List<Escritorio> listaEscritorios= new List<Escritorio>();
            listaEscritorios.Add(new Escritorio(600, "Escritorio bonito", "EscritorioIKEA",2,1,1));
            listaEscritorios.Add(new Escritorio(400, "Escritorio grande", "EscritorioIKEA2",(decimal)2.5,(decimal)1.2,1));
            listaEscritorios.Add(new Escritorio(100, "Escritorio pequeño", "EscritorioIKEA3",2,(decimal)0.5,1));
            List<Armario> listaArmarios = new List<Armario>();
            listaArmarios.Add(new Armario(500, "Armario bonito", "ArmarioIKEA", 5));
            listaArmarios.Add(new Armario(1000, "Armario grande", "ArmarioIKEA2", 10));
            listaArmarios.Add(new Armario(90, "Armario pequeño", "ArmarioIKEA3", 2));
            List<ClienteS> listaClientesEstandar = new List<ClienteS>();
            listaClientesEstandar.Add(new ClienteS("19432310y","Dídac","Tarragó","López","Barcelona"));
            listaClientesEstandar.Add(new ClienteS("49432310y","Pepe","Pepin","Pepon","Madrid"));
            listaClientesEstandar.Add(new ClienteS("59432310y","Paula","Fernandez","Fernandez","Toledo"));
            List<ClienteVIP> listaClientesVIP = new List<ClienteVIP>();
            listaClientesVIP.Add(new ClienteVIP("69432310y","Diego","Lopez","López","Bilbao",50));
            listaClientesVIP.Add(new ClienteVIP("79432310y","Antonia","Pepan","Pepon","Sabadell",25));
            listaClientesVIP.Add(new ClienteVIP("89432310y","Pablo","Duque","Fernandez","Terrasa",15));
            List<SingleVenta> listaVentas = new List<SingleVenta>();
            listaVentas.Add(new SingleVenta(2, "Venta00", listaArmarios[0],listaClientesEstandar[0]));
            listaVentas.Add(new SingleVenta(3, "Venta01", listaArmarios[1],listaClientesVIP[0]));
            listaVentas.Add(new SingleVenta(10, "Venta02", listaArmarios[2],listaClientesEstandar[1]));
            List<Tuple<string, object>> listaDeListas = new List<Tuple<string, object>>();
            listaDeListas.Add(new Tuple<string, object>("Ventas", listaVentas));
            listaDeListas.Add(new Tuple<string, object>("Armarios", listaArmarios));
            listaDeListas.Add(new Tuple<string, object>("Escritorios", listaEscritorios));
            listaDeListas.Add(new Tuple<string, object>("ClientesVIP", listaClientesVIP));
            listaDeListas.Add(new Tuple<string, object>("ClientesEstandar", listaClientesEstandar));
            
            return listaDeListas;
        }

        static List<T> ObtenerListaPorTipo<T>(List<Tuple<string, object>> listaDeListas, string tipo)
        {
            var listaTuple = listaDeListas.Find(tuple => tuple.Item1 == tipo);

            if (listaTuple != null && listaTuple.Item2 is List<T> lista)
            {
                return lista;
            }
            else
            {
                Console.WriteLine($"La lista de {tipo} no se encontró.");
                return new List<T>();
            }
        }
        //MENU
        public int menuPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("==========================");
            Console.WriteLine("======MENU PRINCIPAL======");
            Console.WriteLine("1. Crear una venta.");
            Console.WriteLine("2. Checkear una venta.");
            Console.WriteLine("3. Cancelar una venta.");
            Console.WriteLine("4. Recalcular Tasas de una venta (IVA).");
            Console.WriteLine("5. IR AL MENU CLIENTES.");
            Console.WriteLine("--------------------------");
            Console.WriteLine("8. Ver Ventas");
            Console.WriteLine("9. Ver Armarios");
            Console.WriteLine("0. SALIR.");
            Console.WriteLine("==========================");

            Console.ResetColor();

            Console.WriteLine("Introduce una opcion: ");
            int optionSelected = int.Parse(Console.ReadLine());
            return optionSelected;
        }
        public int menuClientes()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("==========================");
            Console.WriteLine("=======MENU CLIENTES======");
            Console.WriteLine("1. Registrar cliente nuevo.");
            Console.WriteLine("2. Ver clientes standard.");
            Console.WriteLine("3. Ver clientes VIP.");
            Console.WriteLine("4. Modificar descuentos.");
            Console.WriteLine("--------------------------");
            Console.WriteLine("7. Mejorar cliente a VIP.");
            Console.WriteLine("8. Eliminar cliente standard.");
            Console.WriteLine("9. Eliminar cliente VIP.");
            Console.WriteLine("0. <<< VOLVER AL MENU PRINCIPAL.");
            Console.WriteLine("==========================");

            Console.ResetColor();

            Console.WriteLine("Introduce una opcion: ");
            int optionSelected = int.Parse(Console.ReadLine());
            return optionSelected;
        }
        public void LOGICA(List<Tuple<string, object>> lista)
        {
            while(true)
            {
                int optionSelected = menuPrincipal();

                switch (optionSelected)
                {
                    case 1: 
                        crearVenta(lista);
                        break;  
                    case 2:
                        facturarVenta(lista);
                        break;
                    case 3:
                        cancelarVenta(lista);
                        break;
                    case 4:
                        UsandoTax(lista);
                        break;
                    case 5:
                        LOGICA_CLIENTES(lista);
                        break;
                    case 8:
                        ListarVentas(lista);
                        break;
                    case 9:
                        Console.WriteLine("===LISTA DE ARMARIOS===");
                        ListarArmarios(lista);
                        Console.WriteLine("=======================");
                        break;
                    case 0:
                        Console.WriteLine("Presiona una tecla para cerrar la aplicación...");
                        Console.ReadKey();
                        // Cierra la aplicación con un código de salida 0 (éxito).
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }    
                Console.WriteLine("");
                Console.WriteLine("");    
            }
        }
        public void LOGICA_CLIENTES(List<Tuple<string, object>> lista)
        {
            while(true)
            {
                int optionSelected = menuClientes();

                switch (optionSelected)
                {
                    case 1: 
                        int opcion=0;
                        do
                        {
                            Console.WriteLine("1- Cliente VIP(CON DESCUENTO).\n2- Cliente Normal(SIN DESCUENTO).\nIntroduce la opcion 1 o 2:");    
                            opcion= int.Parse(Console.ReadLine());
                            if(opcion==1)
                            {
                                //REGISTRAR CLIENTE VIP
                                crearClienteVIP(lista);
                                break;
                            }else if(opcion==2)
                            {
                                //REGISTRAR CLIENTE STANDARD
                                crearClienteStandar(lista);
                                break;
                            }else{
                                Console.WriteLine("Opcion incorrecta.\n");
                            }
                        }while(opcion!=1&&opcion!=2);
                        break;  
                    case 2:
                        //VER CLIENTES STANDARD
                        ListarClientesEstandar(lista);
                        break;
                    case 3:
                        //VER CLIENTES VIP
                        ListarClientesVIP(lista);
                        break;
                    case 4:
                        //MODIFICAR DESCUENTOS
                        modificarDescuentoVIP(lista);
                        break;
                    case 7:
                        //MEJORAR CLIENTE
                        break;
                    case 8:
                        //ELIMINAR CLIENTE STANDARD
                        break;
                    case 9:
                        //ELIMINAR CLIENTE VIP
                        break;
                    case 0:
                        LOGICA(lista);
                        break;
                    default:
                        break;
                }    
                Console.WriteLine("");
                Console.WriteLine("");    
            }
        }




        //CREAR CLIENTES
        public void crearClienteVIP(List<Tuple<string, object>> lista)
        {
            string nombre, apellido, apellido2, identificacion, direccion;
            int descuento;

            Console.WriteLine("Introduce el nombre del cliente: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Apellido: ");
            apellido = Console.ReadLine();
            Console.WriteLine("Segundo apellido: ");
            apellido2 = Console.ReadLine();
            Console.WriteLine("DNI / NIE o CIF: ");
            identificacion = Console.ReadLine();
            Console.WriteLine("Direccion: ");
            direccion = Console.ReadLine();
            Console.WriteLine("Descuento (%): ");
            descuento = int.Parse(Console.ReadLine());

            ClienteVIP clienteVIP = new ClienteVIP(identificacion,nombre,apellido,apellido2,direccion,descuento);
            
            var clientesTuple = lista.Find(tuple => tuple.Item1 == "ClientesVIP");

            if (clientesTuple != null && clientesTuple.Item2 is List<ClienteVIP> lCliente)
            {
                //GUARDANDO
                lCliente.Add(clienteVIP);
                Console.WriteLine("");
                Console.WriteLine($"Sr./Sra. {clienteVIP._apellido} registrado/a.");
                Console.WriteLine("");
            }
            

        }
        public void crearClienteStandar(List<Tuple<string, object>> lista)
        {
            string nombre, apellido, apellido2, identificacion, direccion;
            
            Console.WriteLine("Introduce el nombre del cliente: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Apellido: ");
            apellido = Console.ReadLine();
            Console.WriteLine("Segundo apellido: ");
            apellido2 = Console.ReadLine();
            Console.WriteLine("DNI / NIE o CIF: ");
            identificacion = Console.ReadLine();
            Console.WriteLine("Direccion: ");
            direccion = Console.ReadLine();

            ClienteS clienteS = new ClienteS(identificacion,nombre,apellido,apellido2,direccion);
            
            var clientesTuple = lista.Find(tuple => tuple.Item1 == "ClientesEstandar");

            if (clientesTuple != null && clientesTuple.Item2 is List<ClienteS> lCliente)
            {
                //GUARDANDO
                lCliente.Add(clienteS);
                Console.WriteLine("");
                Console.WriteLine($"Sr./Sra. {clienteS._apellido} registrado/a.");
                Console.WriteLine("");
            }
        }




        //CREAR VENTA
        public void crearVenta(List<Tuple<string, object>> lista)
        {

            List<Armario> listaArmarios= new List<Armario>();
            listaArmarios=ObtenerListaPorTipo<Armario>(lista,"Armarios");
            
            Console.WriteLine("");

            Console.WriteLine("Escoge el articulo del pedido:");
            ListarArmarios(lista);
            int numeroArticulo =int.Parse(Console.ReadLine());
            Armario armario = listaArmarios[numeroArticulo-1];

            Console.WriteLine("Introduce la cantidad de articulos: ");
            int cantidadArticulos=int.Parse(Console.ReadLine());

            Console.WriteLine("Introduce el nombre de la venta: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Cliente que realiza el pedido:");
            int opcion=0;
            do
            {
                Cliente cliente;
                Console.WriteLine("1- Cliente VIP(CON DESCUENTO).\n2- Cliente Normal(SIN DESCUENTO).\nIntroduce la opcion 1 o 2:");    
                opcion= int.Parse(Console.ReadLine());
                if(opcion==1)
                {
                    //CLIENTE VIP
                    List<ClienteVIP> listaClientesVIP= new List<ClienteVIP>();
                    listaClientesVIP=ObtenerListaPorTipo<ClienteVIP>(lista,"ClientesVIP");
                    ListarClientesVIP(lista);
                    Console.WriteLine("Introduce el numero del cliente (posicion):");
                    int posicionCliente = int.Parse(Console.ReadLine());
                    cliente = listaClientesVIP[posicionCliente-1];
                    SingleVenta venta = new SingleVenta(cantidadArticulos,nombre,armario,cliente);
                    var ventaTuple = lista.Find(tuple => tuple.Item1 == "Ventas");
                    if (ventaTuple != null && ventaTuple.Item2 is List<SingleVenta> listaVentas)
                    {
                        listaVentas.Add(venta);
                        Console.WriteLine("");
                        Console.WriteLine("Venta generada.");
                        Console.WriteLine("");
                        ListarVentas(lista);
                    }

                }else if(opcion==2)
                {
                    //REGISTRAR CLIENTE STANDARD
                    List<ClienteS> listaClientes= new List<ClienteS>();
                    listaClientes=ObtenerListaPorTipo<ClienteS>(lista,"ClientesEstandar");
                    ListarClientesEstandar(lista);
                    Console.WriteLine("Introduce el numero del cliente (posicion):");
                    int posicionCliente = int.Parse(Console.ReadLine());
                    cliente = listaClientes[posicionCliente-1];
                    SingleVenta venta = new SingleVenta(cantidadArticulos,nombre,armario,cliente);
                    var clientesTuple = lista.Find(tuple => tuple.Item1 == "ClientesEstandar");
                    if (clientesTuple != null && clientesTuple.Item2 is List<SingleVenta> listaVentas)
                    {
                        listaVentas.Add(venta);
                        Console.WriteLine("");
                        Console.WriteLine("Venta generada.");
                        Console.WriteLine("");
                        ListarVentas(lista);
                    }
                }else{
                    Console.WriteLine("Opcion incorrecta.\n");
                }
            }while(opcion!=1&&opcion!=2);
        }



        
        //LISTAR
        public void ListarVentas(List<Tuple<string, object>> lista)
        {
            var ventasTuple = lista.Find(tuple => tuple.Item1 == "Ventas");
            if (ventasTuple != null && ventasTuple.Item2 is List<SingleVenta> listaVentas)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=============================");
                Console.WriteLine("=======LISTA DE VENTAS=======");
                Console.ResetColor();
                int i = 1;
                foreach(var venta in listaVentas)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{i}-");
                    Console.ResetColor();
                    Console.WriteLine($"{listaVentas[i-1]}");
                    Console.WriteLine("");
                    i++;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=============================");
                Console.ResetColor();
            }
            
        }
        public void ListarArmarios(List<Tuple<string, object>> lista)
        {
            var armariosTuple = lista.Find(tuple => tuple.Item1 == "Armarios");
            int i = 1;
            if (armariosTuple != null && armariosTuple.Item2 is List<Armario> listaArmarios)
            {
                foreach(var articulo in listaArmarios)
                {
                    Console.WriteLine($"{i}- {articulo._precio} € ({articulo._nombre}) - {articulo._descripcion}");
                    i++;
                }
            }
        }
        public void ListarEscritorios(List<Tuple<string, object>> lista)
        {
            var escritoriosTuple = lista.Find(tuple => tuple.Item1 == "Escritorios");
            int i = 1;
            if (escritoriosTuple != null && escritoriosTuple.Item2 is List<Escritorio> listaEscritorios)
            {
                foreach(var articulo in listaEscritorios)
                {
                    Console.WriteLine($"{i}- {articulo._precio} € ({articulo._nombre}) - {articulo._descripcion}");
                    i++;
                }
            }
        }
        public void ListarClientesVIP(List<Tuple<string, object>> lista)
        {
            var clientesVIPTuple = lista.Find(tuple => tuple.Item1 == "ClientesVIP");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===LISTA CLIENTES VIP===");
            Console.ResetColor();

            int i = 1;
            if (clientesVIPTuple != null && clientesVIPTuple.Item2 is List<ClienteVIP> listaClientesVIP)
            {
                foreach(var venta in listaClientesVIP)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{i}-");
                    Console.ResetColor();
                    Console.WriteLine($"{listaClientesVIP[i-1]}");
                    Console.WriteLine("");
                    i++;
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=========================");
            Console.ResetColor();
        }
        public void ListarClientesEstandar(List<Tuple<string, object>> lista)
        {
            var clientesEstandarTuple = lista.Find(tuple => tuple.Item1 == "ClientesEstandar");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=============================");
            Console.WriteLine("===LISTA CLIENTES ESTANDAR===");
            Console.ResetColor();
            int i = 1;
            if (clientesEstandarTuple != null && clientesEstandarTuple.Item2 is List<ClienteS> listaClientesEstandar)
            {
                foreach(var venta in listaClientesEstandar)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{i}-");
                    Console.ResetColor();
                    Console.WriteLine($"{listaClientesEstandar[i-1]}");
                    Console.WriteLine("");
                    i++;
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("==============================");
            Console.ResetColor();
        }




        //CLIENTES
        public void modificarDescuentoVIP(List<Tuple<string, object>> lista)
        {
            ListarClientesVIP(lista);

            Console.WriteLine("Que cliente deseas modificar (posicion nº cliente): ");
            int posicionCliente = int.Parse(Console.ReadLine());
            List<ClienteVIP> listaClienteVIP= ObtenerListaPorTipo<ClienteVIP>(lista,"ClientesVIP");
            Console.WriteLine($"Actual descuento: {listaClienteVIP[posicionCliente-1]._descuento} %\n"
            +"¿Que descuento quieres aplicar a este cliente?");
            int descuentoNuevo = int.Parse(Console.ReadLine());
            listaClienteVIP[posicionCliente-1]._descuento=descuentoNuevo;
            var clientesTuple = lista.Find(tuple => tuple.Item1 == "ClientesVIP");

            if (clientesTuple != null)
            {
                // Reemplaza la lista de clientes en la tupla
                clientesTuple = new Tuple<string, object>("ClientesVIP", listaClienteVIP);
                Console.WriteLine("Descuento modificado correctamente.\n");
            }
            
        }




        //USOS DE VENTAS
        public void facturarVenta(List<Tuple<string, object>> lista) 
        {
            ListarVentas(lista);
            Console.WriteLine("Introduce el numero de la venta: ");
            int numeroEntero=int.Parse(Console.ReadLine());
            
            List<SingleVenta> listaVentas= ObtenerListaPorTipo<SingleVenta>(lista,"Ventas");
            listaVentas[numeroEntero-1].Check();
            
            Console.WriteLine("");
        }
        public void cancelarVenta(List<Tuple<string, object>> lista) 
        {
            ListarVentas(lista);
            Console.WriteLine("Introduce el numero de la venta: ");
            int numeroEntero=int.Parse(Console.ReadLine());

            List<SingleVenta> listaVentas= ObtenerListaPorTipo<SingleVenta>(lista,"Ventas");

            listaVentas[numeroEntero-1].Cancel(listaVentas,numeroEntero-1);
            var VentasTuple = lista.Find(tuple => tuple.Item1 == "Ventas");

            if (VentasTuple != null)
            {
                // Reemplaza la lista de clientes en la tupla
                VentasTuple = new Tuple<string, object>("Ventas", listaVentas);
                Console.WriteLine("Venta cancelada.\n");
            }
            Console.WriteLine("");
        }
        public void UsandoTax(List<Tuple<string, object>> lista)
        {
            ListarVentas(lista);
            
            Console.WriteLine("Introduce el numero de la venta: ");    
            int numeroEntero=int.Parse(Console.ReadLine());

            List<SingleVenta> listaVentas= ObtenerListaPorTipo<SingleVenta>(lista,"Ventas");

            Console.WriteLine($"La venta que ha seleccionado tiene un IVA del {(listaVentas[numeroEntero-1]._iva)/10}.\n"
            +$"In troduce el numero valor: ");
            int IVA=int.Parse(Console.ReadLine());

            listaVentas[numeroEntero-1].Tax(IVA);

            var VentasTuple = lista.Find(tuple => tuple.Item1 == "Ventas");

            if (VentasTuple != null)
            {
                // Reemplaza la lista de clientes en la tupla
                VentasTuple = new Tuple<string, object>("Ventas", listaVentas);
                Console.WriteLine("IVA modificado correctamente.\n");
            }
            Console.WriteLine("");
        }
    }
}
