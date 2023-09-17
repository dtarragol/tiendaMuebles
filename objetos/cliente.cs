namespace Ventas.objetos
{
    public abstract class Cliente
    {
        public string _identificador;
        public string _nombre;
        public string _apellido;
        public string _apellido2;
        public string _direccion;

        public Cliente(string identificador, string nombre, string apellido, string apellido2, string direccion)
        {
            this._identificador=identificador;
            this._nombre=nombre;
            this._apellido=apellido;
            this._apellido2=apellido2;
            this._direccion=direccion;
        }
        
    }
    interface IComprar
    {

    }
    interface IRecoger
    {

    }
    interface IReservar
    {

    }
    
    public class ClienteVIP : Cliente, IComprar, IRecoger, IReservar
    {
        public decimal _descuento;
        public void descontar()
        {
            Console.WriteLine($"Aplicando descuento del {this._descuento}");
        }
        public ClienteVIP(string identificador,string nombre, string apellido, string apellido2,string direccion, decimal descuento):base(identificador,nombre,apellido,apellido2,direccion)
        {
            this._descuento=descuento;
            Console.WriteLine($"Se ha agregado al Sr. {this._apellido}");
        }
        public override string ToString()
        {
            return $"Nombre: {this._nombre} {this._apellido} {this._apellido2}\n"+
            $"DNI/NIE/CIF: {this._identificador}\n"+
            $"Descuento: {this._descuento}%\n"+
            $"Direccion: {this._direccion}";
        }
    }
    public class ClienteS : Cliente, IComprar, IRecoger, IReservar
    {
        public ClienteS(string identificador, string nombre, string apellido, string apellido2, string direccion):base(identificador,nombre,apellido,apellido2,direccion)
        {
            this._identificador=identificador;
            this._nombre=nombre;
            this._apellido=apellido;
            this._apellido2=apellido2;
            this._direccion=direccion;
            Console.WriteLine($"Se ha agregado al Sr. {this._apellido}");
        
        }
        public override string ToString()
        {
            return $"Nombre: {this._nombre} {this._apellido} {this._apellido2}\n"+
            $"DNI/NIE/CIF: {this._identificador}\n"+
            $"Direccion: {this._direccion}";
        }
    }
    
}