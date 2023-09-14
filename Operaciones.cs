using Ventas.objetos;
using System.Xml.Linq;

namespace Ventas
{
    public class Operaciones 
    {
        //CONSTRUCTOR
        public Operaciones()
        {

        }
        
        //CARGA DE DATOS INICIAL
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
        public void LOGICA(List<SingleVenta> lista,List<Armario> listaArmarios, List<ClienteVIP> listaVIP, List<ClienteS> listaClienteStandar)
        {
            while(true)
            {
                int optionSelected = menuPrincipal();

                switch (optionSelected)
                {
                    case 1: 
                        lista= crearVenta(lista,listaArmarios,listaClienteStandar,listaVIP);
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
                        LOGICA_CLIENTES(lista,listaArmarios,listaVIP, listaClienteStandar);
                        break;
                    case 8:
                        ListarVentas(lista);
                        break;
                    case 9:
                        Console.WriteLine("===LISTA DE ARMARIOS===");
                        ListarArmarios(listaArmarios);
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
        public void LOGICA_CLIENTES(List<SingleVenta> lista,List<Armario> listaArmarios, List<ClienteVIP> listaVIP,List<ClienteS> listaClienteStandar)
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
                                listaVIP=crearClienteVIP(listaVIP);
                                break;
                            }else if(opcion==2)
                            {
                                //REGISTRAR CLIENTE STANDARD
                                listaClienteStandar=crearClienteStandar(listaClienteStandar);
                                break;
                            }else{
                                Console.WriteLine("Opcion incorrecta.\n");
                            }
                        }while(opcion!=1&&opcion!=2);
                        break;  
                    case 2:
                        //VER CLIENTES STANDARD
                        ListarClientesEstandar(listaClienteStandar);
                        break;
                    case 3:
                        //VER CLIENTES VIP
                        ListarClientesVIP(listaVIP);
                        break;
                    case 4:
                        //MODIFICAR DESCUENTOS
                        modificarDescuentoVIP(listaVIP);
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
                        LOGICA(lista,listaArmarios,listaVIP,listaClienteStandar);
                        break;
                    default:
                        break;
                }    
                Console.WriteLine("");
                Console.WriteLine("");    
            }
        }




        //CREAR CLIENTES
        public List<ClienteVIP> crearClienteVIP(List<ClienteVIP> lCliente)
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
            lCliente.Add(clienteVIP);
            
            Console.WriteLine("");
            Console.WriteLine($"Sr. {clienteVIP._apellido} registrado.");
            Console.WriteLine("");

            return lCliente;
        }
        public List<ClienteS> crearClienteStandar(List<ClienteS> listaClienteStandar)
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
            listaClienteStandar.Add(clienteS);
            
            Console.WriteLine("");
            Console.WriteLine($"Sr. {clienteS._apellido} registrado.");
            Console.WriteLine("");

            return listaClienteStandar;
        }




        //CREAR VENTA
        public List<SingleVenta> crearVenta(List<SingleVenta> l, List<Armario> l2,List<ClienteS> listaClienteStandar,List<ClienteVIP> listaClientesVIP)
        {
            Console.WriteLine("");

            Console.WriteLine("Escoge el articulo del pedido:");
            ListarArmarios(l2);
            int numeroArticulo =int.Parse(Console.ReadLine());
            Armario armario = l2[numeroArticulo-1];

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
                    ListarClientesVIP(listaClientesVIP);
                    Console.WriteLine("Introduce el numero del cliente (posicion):");
                    int posicionCliente = int.Parse(Console.ReadLine());
                    cliente = listaClientesVIP[posicionCliente-1];
                    SingleVenta venta = new SingleVenta(cantidadArticulos,nombre,armario,cliente);
                    l.Add(venta);
                }else if(opcion==2)
                {
                    //REGISTRAR CLIENTE STANDARD
                    ListarClientesEstandar(listaClienteStandar);
                    Console.WriteLine("Introduce el numero del cliente (posicion):");
                    int posicionCliente = int.Parse(Console.ReadLine());
                    cliente = listaClienteStandar[posicionCliente-1];
                    SingleVenta venta = new SingleVenta(cantidadArticulos,nombre,armario,cliente);
                    l.Add(venta);
                }else{
                    Console.WriteLine("Opcion incorrecta.\n");
                }
            }while(opcion!=1&&opcion!=2);
            Console.WriteLine("");
            Console.WriteLine("Venta generada.");
            Console.WriteLine("");
            ListarVentas(l);
            return l;
        }



        
        //LISTAR
        public void ListarVentas(List<SingleVenta> l)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=============================");
            Console.WriteLine("=======LISTA DE VENTAS=======");
            Console.ResetColor();
            int i = 1;
            foreach(var venta in l)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{i}-");
                Console.ResetColor();
                Console.WriteLine($"{l[i-1]}");
                Console.WriteLine("");
                i++;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=============================");
            Console.ResetColor();
        }
        public void ListarArmarios(List<Armario> l)
        {
            int i = 1;
            foreach(var articulo in l)
            {
                Console.WriteLine($"{i}- {articulo._precio} € ({articulo._nombre}) - {articulo._descripcion}");
                i++;
            }
        }
        public void ListarClientesVIP(List<ClienteVIP> l)
        {
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===LISTA CLIENTES VIP===");
            Console.ResetColor();

            int i = 1;
            foreach(var venta in l)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{i}-");
                Console.ResetColor();
                Console.WriteLine($"{l[i-1]}");
                Console.WriteLine("");
                i++;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=========================");
            Console.ResetColor();
        }
        public void ListarClientesEstandar(List<ClienteS> l)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=============================");
            Console.WriteLine("===LISTA CLIENTES ESTANDAR===");
            Console.ResetColor();
            int i = 1;
            foreach(var venta in l)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{i}-");
                Console.ResetColor();
                Console.WriteLine($"{l[i-1]}");
                Console.WriteLine("");
                i++;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("==============================");
            Console.ResetColor();
        }




        //CLIENTES
        public void modificarDescuentoVIP(List<ClienteVIP> l)
        {
            ListarClientesVIP(l);
            Console.WriteLine("Que cliente deseas modificar (posicion nº cliente): ");
            int posicionCliente = int.Parse(Console.ReadLine());

            Console.WriteLine($"Actual descuento: {l[posicionCliente-1]._descuento} %\n"
            +"¿Que descuento quieres aplicar a este cliente?");
            int descuentoNuevo = int.Parse(Console.ReadLine());
            l[posicionCliente-1]._descuento=descuentoNuevo;

            Console.WriteLine("Descuento modificado correctamente.\n");
        }




        //USOS DE VENTAS
        public void facturarVenta(List<SingleVenta> l) 
        {
            ListarVentas(l);
            Console.WriteLine("Introduce el numero de la venta: ");
            int numeroEntero=int.Parse(Console.ReadLine());
            l[numeroEntero-1].Check();
            Console.WriteLine("");
        }
        public void cancelarVenta(List<SingleVenta> l) 
        {
            ListarVentas(l);
            Console.WriteLine("Introduce el numero de la venta: ");
            int numeroEntero=int.Parse(Console.ReadLine());
            l[numeroEntero-1].Cancel(l,numeroEntero-1);
            
            Console.WriteLine("");
        }
        public void UsandoTax(List<SingleVenta> l)
        {
            ListarVentas(l);
            
            Console.WriteLine("Introduce el numero de la venta: ");    
            int numeroEntero=int.Parse(Console.ReadLine());
            
            Console.WriteLine($"La venta que ha seleccionado tiene un IVA del {(l[numeroEntero-1]._iva)/10}.\n"
            +$"In troduce el numero valor: ");
            int IVA=int.Parse(Console.ReadLine());

            l[numeroEntero-1].Tax(IVA);
            Console.WriteLine("");
        }
    }
}
