using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Formulario
{
    class Inventario
    {
        private Producto inicio;
        
        private int _indiceProducto;
        
        public Inventario()
        {
            _indiceProducto = 0;
        }

        public override string ToString()
        {
            return "Total de productos: " + _indiceProducto;
        }
        
        public void agregarProducto(Producto producto)
        {
            Producto temporal = inicio;

            if (inicio == null)
            {
                inicio = producto;
            }

            else
            {
                //si el codigo del producto es menor   o igual al codigo de inicio
                //
                if (producto.codigoDeBarras <= inicio.codigoDeBarras)
                {
                    //el ultimo producto ahora es el inicio
                    producto.siguiente = inicio;
                    inicio = producto;
                }

                else
                {

                    while (temporal.siguiente != null)
                    {
                        if (producto.codigoDeBarras <= temporal.siguiente.codigoDeBarras)
                            break;
                        temporal = temporal.siguiente;
                    }

                    producto.siguiente = temporal.siguiente;
                    temporal.siguiente = producto;
                }
            }
            _indiceProducto++;
        }

        public Producto buscar(string nombre)
        {
            Producto temporal = inicio;
            
            while(temporal != null)//aqui solo se recorre no itera
            {
                if(temporal.nombre == nombre)
                {
                    return temporal;
                }
                else
                {
                    temporal = temporal.siguiente;//es el que hace que itere
                }
            }
            
            return null;

        }

        public void eliminar(string nombre)
        {
            if(inicio.nombre == nombre)
            {
                inicio = inicio.siguiente;
                _indiceProducto--;
            }
            else
            {
                Producto temporal = inicio;

                while(temporal.siguiente != null)
                {
                    if(temporal.siguiente.nombre == nombre)
                    {
                        temporal.siguiente = temporal.siguiente.siguiente;
                        _indiceProducto--;
                        break;
                    }
                    else
                    {
                        temporal = temporal.siguiente;
                    }
                }
            }
        }

        public void insertar(Producto producto, int posicion)
        {
            {
                if ((inicio != null) && (posicion > 0) && (posicion < _indiceProducto))
                {
                    Producto temp = inicio;
                    int index = 1;
                    while (true)
                    {
                        if (index <= posicion)
                        {
                            producto.siguiente = temp.siguiente;
                            temp.siguiente = producto;
                            break;
                        }
                        else
                        {
                            index++;
                            temp = temp.siguiente;
                        }
                    }
                    _indiceProducto++;
                }
            }
        }

        public string reporte()
        {
            string mostrar = ToString() + Environment.NewLine;
            Producto temporal = inicio;
            while (temporal != null)
            {
                mostrar += "_______________" + Environment.NewLine;
                mostrar += temporal.ToString();
                temporal = temporal.siguiente;
            }

            return mostrar;
        }
    }
}
