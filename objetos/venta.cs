using System.Xml.Linq;
namespace Ventas.objetos


{
    public abstract class Venta
    {
        public decimal _total;
        public int _numeroArticulos;
        public string _nombre;
        public int _identificador;
        public Cliente _cliente;
        public Articulo _articulo;
        public decimal _descuento;
        
        //public Venta(decimal total) => _total = total;
        public Venta(int numeroArticulos, string nombre, Articulo articulo, Cliente cliente) 
        {
            this._numeroArticulos=numeroArticulos;
            this._total=articulo._precio * _numeroArticulos;
            this._nombre=nombre;
            this._articulo=articulo;
            this._cliente=cliente;
            if(this._cliente is ClienteVIP)
            {
                ClienteVIP CV= (ClienteVIP)cliente;
                this._descuento=CV._descuento;
            }else
            {
                this._descuento=0;
            }
            //this._descuento= descuento;
        }
    }

    interface IFactura
    {
        void Check();
    }

    interface ICancel
    {
        void Cancel(List<SingleVenta> lista, int num);
    }

    interface ITax
    {
        public decimal Total { get; set;}
    }
    interface IDescontar
    {
        public decimal precioConDescuento {get;set;}
        void Descontar();
    }
    public class SingleVenta : Venta, IFactura, ICancel, ITax, IDescontar
    {
        public decimal _iva;
        public void Check()
        {
                Console.WriteLine($"PRobando checkear {this._nombre}");
                string nombreCliente= this._cliente._nombre+" "+this._cliente._apellido+" "+this._cliente._apellido2;
                string DNI = this._cliente._identificador;
                string nombreArticulo = this._articulo._nombre;
                string precioArticulo = this._articulo._precio+"";
                string numeroArticulos = this._numeroArticulos+"";
                

                XElement root = new XElement(this._nombre,
                    new XElement("Cliente", nombreCliente),
                    new XElement("Identidad", DNI),
                    new XElement("Articulos",
                        new XElement("Articulo", nombreArticulo),
                        new XElement("Precio", precioArticulo),
                        new XElement("Cantidad", numeroArticulos),
                        new XElement("IVA", this._iva),
                        new XElement("TOTAL", this.Total),
                        new XElement("ConDescuento", this.precioConDescuento)
                        
                    )
                );
            // Crea un documento XML y agrega el elemento raíz
            XDocument document = new XDocument(root);

            // Especifica la ruta donde deseas guardar el archivo XML
            string rutaArchivoXml = $"facturas/{this._nombre}.xml";

            // Guarda el documento XML en el archivo
            document.Save(rutaArchivoXml);

            Console.WriteLine("Archivo XML generado exitosamente en: " + rutaArchivoXml);
        }
        public void Cancel(List<SingleVenta> lista, int posicionArray)
        {   
            Console.WriteLine($"Cancelando venta número {posicionArray} con valor de {this.Total} € ({this._total} € + {this._iva}) ...");
            lista.RemoveAt(posicionArray);
        }
        public void Tax(int tasa)
        {
            this._iva=this._total*tasa/100;
        }
        public decimal Total 
        { 
            get
            {
                return _total + _iva;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public decimal precioConDescuento
        {
            get
            {
                return Total - Total*(_descuento/100);
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public void Descontar()
        {
            if(this._cliente is ClienteVIP)
            {
                Console.WriteLine($"{this._cliente._nombre} tiene descuento");
            }else
            {
                Console.WriteLine($"{this._cliente._nombre} NO tiene descuento");
            }
        }
        public SingleVenta(int numeroArticulos, string nombre, Articulo articulo, Cliente cliente):base(numeroArticulos,nombre,articulo,cliente)
        {
            this.Tax(21);
        }
        public override string ToString()
        {
            if(this._cliente is ClienteVIP)
            {
                return $"Nombre de la venta: {this._nombre}\n Articulo: {this._articulo}\n"
                    +$" Cantidad: {this._numeroArticulos}\n Importe total: {this.precioConDescuento}€(con descuento) >> {this.Total} €(({this._articulo._precio} € * {this._numeroArticulos}) + {this._iva} €(IVA)).\n"
                    +$" Cliente: {this._cliente._nombre} {this._cliente._apellido} {this._cliente._apellido2} ({this._cliente._identificador})";
        
            }else
            {
                return $"Nombre de la venta: {this._nombre}\n Articulo: {this._articulo}\n"
                    +$" Cantidad: {this._numeroArticulos}\n Importe total: {this.Total} €(({this._articulo._precio} € * {this._numeroArticulos}) + {this._iva} €(IVA)).\n"
                    +$" Cliente: {this._cliente._nombre} {this._cliente._apellido} {this._cliente._apellido2} ({this._cliente._identificador})";
        
            }
            }
    }
}


