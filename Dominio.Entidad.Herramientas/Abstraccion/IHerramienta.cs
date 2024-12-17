using Dominio.Entidad.Herramientas.Entidad;
using Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad.Herramientas.Abstraccion
{
    public interface IHerramienta: IRepositorioCRUD<Entidad.Herramientas>, IRepositorioGET<Entidad.Herramientas>
    {
    }
}
