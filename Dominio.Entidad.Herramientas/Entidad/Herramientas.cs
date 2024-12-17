using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidad.Herramientas.Entidad
{
    public class Herramientas
    {
        [Display(Name = "Id Herramienta"), Required] public string idher {  get; set; }
        [Display(Name = "Descripcion Herramienta"), Required] public string desher {  get; set; }
        [Display(Name = "Medida Herramienta"), Required] public string medher { get; set; }
        [Display(Name = "Id Categoria"), Required] public int idcategoria { get; set; }
        [Display(Name = "Precio Unitario"), Required] public decimal preuni  { get; set; }
        [Display(Name = "Stock"), Required] public int stock { get; set; }
    }
}
