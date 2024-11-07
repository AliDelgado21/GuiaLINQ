using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario
{
    public class Inventario
    {
       private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }

        public void AgregarProducto (Producto producto)
        {
            productos.Add(producto);
        }

        public IEnumerable<Producto> FiltrarYOrdenarProductos(decimal precioMinimo)
        {
            //Filtrar y ordenar productod con LINQ y expreciones lamba
            return productos
                .Where(p => p.Precio > precioMinimo)
                .OrderBy(p=>p.Precio);
        }

        // Método para actualizar el precio de un producto por nombre
        public bool ActualizarPrecio(string nombre, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                return true;
            }
            return false;
        }

        // Método para eliminar un producto por nombre
        public bool EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                return true;
            }
            return false;
        }

        // Método para contar el total de productos
        public int ContarProductos()
        {
            return productos.Count;
        }

        // Método para calcular el precio promedio de los productos
        public decimal CalcularPrecioPromedio()
        {
            return productos.Any() ? productos.Average(p => p.Precio) : 0;
        }

        // Método para obtener el producto con el precio más alto
        public Producto ObtenerProductoMasCaro()
        {
            return productos.OrderByDescending(p => p.Precio).FirstOrDefault();
        }

        // Método para obtener el producto con el precio más bajo
        public Producto ObtenerProductoMasBarato()
        {
            return productos.OrderBy(p => p.Precio).FirstOrDefault();
        }

        // Método para agrupar productos en rangos de precio usando LINQ
        public IEnumerable<IGrouping<string, Producto>> AgruparProductosPorRangoDePrecio()
        {
            return productos.GroupBy(p =>
            {
                if (p.Precio < 100) return "Menores a 100";
                if (p.Precio <= 500) return "Entre 100 y 500";
                return "Mayores a 500";
            });
        }
    }
}
