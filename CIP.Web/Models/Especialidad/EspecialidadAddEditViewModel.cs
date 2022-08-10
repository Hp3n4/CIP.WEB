using CIP.Models.Contexto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace CIP.Web.Models.Especialidad
{
    public class EspecialidadAddEditViewModel
    {
        public int? IdEspecialidad { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public void CargarDatos(CIPEntities Contexto)
        {
            /*his.ListEspecialidades = Contexto.Especialidades.OrderBy(x => x.Nombre).ToList();*/

            if (this.IdEspecialidad.HasValue)
            {
                var objConsulta = Contexto.Especialidades.Find(this.IdEspecialidad);

                this.IdEspecialidad = objConsulta.IdEspecialidad;
                this.Nombre = objConsulta.Nombre;
                this.Descripcion = objConsulta.Descripcion;
                //this.Telefono = objConsulta.Telefono;

                //this.Especialidades = (int)objConsulta.IdEspecialidad;
            }
        }
    }
}