using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.models
{
    public class Usuario
    {
        public string? usuario { get; set; }
        public string? nombres { get; set; }       
        public string? perfil { get; set; }     
        public string? verMesasall { get; set; }     
        public string? CodVende { get; set; } 
        // Agrega más propiedades según los campos que devuelve el procedimiento.
    }
    public class Grupos
    {
        public string? Codigo_Grupo { get; set; }
        public string? Descripcion_Grupo { get; set; }       
        public string? Imagen { get; set; }             
        // Agrega más propiedades según los campos que devuelve el procedimiento.
    }

    public class Productos
    {
        public int Codigo_Producto { get; set; } // Asume que es un entero, ajusta si es diferente
        public int Codigo_Grupo { get; set; }    // Asume que es un entero, ajusta si es diferente
        public string Descripcion_Producto { get; set; }
        public decimal Valor_Producto { get; set; } // Usa decimal para valores monetarios
        public decimal Impuesto { get; set; }      // Usa decimal para tasas o porcentajes
        public string Precio_Variable { get; set; }  // Asume que es un booleano
        public int NumUniEmpaque { get; set; }    // Asume que es un entero
        public string Imagen { get; set; }        // Representación de la imagen en formato binario
    }

}
