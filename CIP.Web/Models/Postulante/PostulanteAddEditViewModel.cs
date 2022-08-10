using CIP.Models.Contexto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;



namespace CIP.Web.Models.Postulante
{
    public class PostulanteAddEditViewModel
    {
        public int? IdPostulante { get; set; }

        [Required]
        public string DatosPostulante { get; set; }

        [Required]
        public string DNI { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public int Especialidades { get; set; }

        public List<Especialidades> ListEspecialidades { get; set; }

        public void CargarDatos(CIPEntities Contexto)
        {
            this.ListEspecialidades = Contexto.Especialidades.OrderBy(x => x.Nombre).ToList();

            if (this.IdPostulante.HasValue)
            {
                var objConsulta = Contexto.Postulantes.Find(this.IdPostulante);

                this.IdPostulante = objConsulta.IdPostulante;
                this.DatosPostulante = objConsulta.DatosPostulante;
                this.DNI = objConsulta.DNI;
                this.Telefono = objConsulta.Telefono;
                
                this.Especialidades = (int)objConsulta.IdEspecialidad;
            }
        }



    }
}