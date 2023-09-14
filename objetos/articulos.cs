namespace Ventas.objetos
{
     public abstract class Articulo
    {
        public int _identificador;
        public string _descripcion;
        public decimal _precio;
        public string _nombre;
        public Articulo(string descripcion,decimal precio, string nombre) 
        {
            this._descripcion=descripcion;
            this._precio=precio;
            this._nombre=nombre;
            //this._identificador=identificador;
            
        }
    }
    public class Armario : Articulo
    {
        public int _numeroPuertas;
        public Armario(decimal precio, string descripcion,string nombre, int numeroPuertas):base(descripcion,precio,nombre)
        {
            this._numeroPuertas=numeroPuertas;
        }
        public override string ToString()
        {
            return $"Nombre: {this._nombre}, Puertas: {this._numeroPuertas}, Descripcion: {this._descripcion}[PRECIO = {this._precio} €].";
        }
    }
}