using CIP.Models.Contexto;
using CIP.Models.Helpers;
using CIP.Web.Filters;
using CIP.Web.Helpers;
using CIP.Web.Models.Postulante;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CIP.Web.Controllers
{
    public class PostulanteController : BaseController
    {
        [RolAuthFilter(ConstanHelpers.Rol.Administrador,ConstanHelpers.Rol.Recepcionista)]
        public ActionResult Index()
        {
            var viewModel = new PostulanteIndexViewModel();

            var lista =  Contexto.Postulantes.ToList();
                //.Where(x => x.TipoPreguntaId == ConstanHelpers.TipoPregunta.PreguntaFrecuente)
                //.ToList(); 

            viewModel.ListPreguntas = lista;

            return View(viewModel);
        }

        [RolAuthFilter(ConstanHelpers.Rol.Administrador, ConstanHelpers.Rol.Recepcionista)]
        public ActionResult Detail(int Idpostulante)
        {
            var viewModel = new PostulanteDetailViewModel();

            viewModel.IdPostulante = Idpostulante;
            // llave primaria de una columna
            viewModel.PostulantesDetail = Contexto.Postulantes.Find(Idpostulante);

            // llave primaria compleja de mas de una columna
            //Contexto.ConsultaLegal.FirstOrDefault(x => x.ConsultaLegalId == 10 &&
            //        x.Estado == "XYZ" && x.TemaId == 9);

            return View(viewModel);
        }

        [RolAuthFilter(ConstanHelpers.Rol.Administrador)]
        public ActionResult Delete(int Idpostulante)
        {
            try
            {
                var objPostulante = Contexto.Postulantes
                    .FirstOrDefault(x => x.IdPostulante == Idpostulante);// &&
                       // x.TipoPreguntaId == ConstantHelpers.TipoPregunta.PreguntaFrecuente);

                if (objPostulante == null)
                {
                    TempData["MensajePostulante"] = "El registro no existe en BD.";
                    return RedirectToAction("Index");
                }

                Contexto.Postulantes.Remove(objPostulante);
                Contexto.SaveChanges();
                TempData["MensajePostulante"] = "El registro fue eliminado exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["MensajePostulante"] = "Ocurrio un error, contacte con el administrador";
            }

            return RedirectToAction("Index");
        }

        [RolAuthFilter(ConstanHelpers.Rol.Administrador, ConstanHelpers.Rol.Recepcionista))]
        public ActionResult AddEdit(int? Idpostulante)
        {
            var viewModel = new PostulanteAddEditViewModel();

            viewModel.IdPostulante = Idpostulante;
            viewModel.CargarDatos(Contexto);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RolAuthFilter(ConstanHelpers.Rol.Administrador, ConstanHelpers.Rol.Recepcionista))]
        public ActionResult AddEdit(PostulanteAddEditViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    viewModel.IdPostulante = viewModel.IdPostulante;
                    viewModel.CargarDatos(Contexto);

                    TryUpdateModel(viewModel);

                    TempData["MensajeAddEditPostulante"] = "Por favor, complete los campos requeridos.";
                    return View(viewModel);
                }

                Postulantes objPostulante = null;

                if (viewModel.IdPostulante.HasValue)
                {
                    objPostulante = Contexto.Postulantes.Find(viewModel.IdPostulante);
                }
                else
                {
                    objPostulante = new Postulantes();
                    objPostulante.DatosPostulante = viewModel.DatosPostulante ;
                    objPostulante.DNI = viewModel.DNI;
                    objPostulante.Fecha = DateTime.Now;
                    objPostulante.Telefono = viewModel.Telefono;
                    objPostulante.IdEspecialidad = viewModel.Especialidades;
                    objPostulante.IdUsuario = Session.GetUsuarioId();
                    

                    Contexto.Postulantes.Add(objPostulante);
                }

                objPostulante.DatosPostulante = viewModel.DatosPostulante;
                objPostulante.DNI = viewModel.DNI;
                objPostulante.Fecha = DateTime.Now;
                objPostulante.Telefono = viewModel.Telefono;
                objPostulante.IdEspecialidad = viewModel.Especialidades;
                objPostulante.IdUsuario = Session.GetUsuarioId();

                Contexto.SaveChanges();
                TempData["MensajePostulante"] = "La consulta fue procesada exitosamente.";
            }
            catch (Exception ex)
            {
                viewModel.IdPostulante = viewModel.IdPostulante;
                viewModel.CargarDatos(Contexto);

                TryUpdateModel(viewModel);

                TempData["MensajeAddEditPostulante"] = "Hubo un error, consulte con el administrador.";
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }
    }
}
