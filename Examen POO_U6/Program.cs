using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_POO_U6
{
    public class Producto
    {
        public string nombre, descripcion;
        public float precio;
        public int cantidad;

        public Producto(string nombre, string descripcion, float precio, int cantidad)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.cantidad = cantidad;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Variables Auxiliares
            string nombreax, descripcionax;
            float precioax;
            int cantidadax;
            char C; // Variable del Ciclo

            do // Cilco del Menu
            {
                C = 'x';
                try
                {
                    Console.Clear();

                    Console.WriteLine("-Menu-\n");
                    Console.WriteLine("a) Añadir Producto.");
                    Console.WriteLine("b) Ver lista de Inventario.");
                    Console.WriteLine("c) Salir del Programa.");

                    Console.Write("\n   Seleccione una opción: ");
                    C = char.Parse(Console.ReadLine());

                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.Write("\n¡Ingrese un solo Caracter!");
                    Console.ReadKey();

                    Console.Clear();
                }
                switch (C)
                {
                    case 'a':

                        StreamWriter inventario = new StreamWriter("Productos.txt", true); // Crear o Añadir Archivo

                        try
                        {
                            Console.Write("Nombre del Producto: ");
                            nombreax = Console.ReadLine();
                            Console.Write("Descripcion del Producto: ");
                            descripcionax = Console.ReadLine();
                            Console.Write("Precio del Producto: ");
                            precioax = Single.Parse(Console.ReadLine());
                            Console.Write("Cantidad en Stock del Producto: ");
                            cantidadax = int.Parse(Console.ReadLine());

                            Producto producto = new Producto(nombreax, descripcionax, precioax, cantidadax);

                            inventario.Write("Produsto: {0}\nDescripcion del Producto: {1}\nPrecio del Producto: {2:C}" +
                                "\nCantidad en Stok: {3}\n\n", producto.nombre, producto.descripcion, producto.precio, producto.cantidad);

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\n¡Error de Formato!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\nError: " + e.Message);
                        }
                        finally
                        {
                            inventario.Close();
                        }

                        Console.WriteLine("\nProducto Guardado, Precione <enter> para Continuar . . .");
                        Console.ReadLine();

                        break;
                    case 'b':

                        try
                        {
                            StreamReader mostrar = new StreamReader("Productos.txt"); // Leer Archivo
                            string Line;

                            while ((Line = mostrar.ReadLine()) != null)
                            {
                                Console.WriteLine(Line);
                            }
                            mostrar.Close();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("¡Primero tiene que añadir un Producto!");
                        }

                        Console.WriteLine("\nPrecione <enter> para Continuar . . .");
                        Console.ReadKey();

                        break;

                    case 'c':

                        // Salir del Programa

                        break;

                    default:

                        Console.WriteLine("¡No Ingreso ninguna de las 3 opciones!");
                        Console.ReadKey();

                        break;
                }
            }
            while (C != 'c');
        }
    }
}