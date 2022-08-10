using CIP.Models.Contexto;
using CIP.Models.Helpers;
using CIP.Web.Filters;
using CIP.Web.Helpers;
using CIP.Web.Models.Especialidad;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CIP.Web.Controllers
{
    public class EspecialidadController : BaseController
    {
        [RolAuthFilter(ConstanHelpers.Rol.Administrador)]
        public ActionResult Index()
        {
            var viewModel = new EspecialidadIndexViewModel();

            var lista = Contexto.Especialidades.ToList();
            //.Where(x => x.TipoPreguntaId == ConstanHelpers.TipoPregunta.PreguntaFrecuente)
            //.ToList(); 

            viewModel.ListPreguntas = lista;

            return View(viewModel);
        }

        [RolAuthFilter(ConstanHelpers.Rol.Administrador)]
        public ActionResult Detail(int Idespecialidad)
        {
            var viewModel = new EspecialidadDetailViewModel();

            viewModel.IdEspecialidad = Idespecialidad;
            // llave primaria de una columna
            viewModel.EspecialidadesDetail = Contexto.Especialidades.Find(Idespecialidad);

            // llave primaria compleja de mas de una columna
            //Contexto.ConsultaLegal.FirstOrDefault(x => x.ConsultaLegalId == 10 &&
            //        x.Estado == "XYZ" && x.TemaId == 9);

            return View(viewModel);
        }

        [RolAuthFilter(ConstanHelpers.Rol.Administrador)]
        public ActionResult Delete(int Idespecialidad)
        {
            try
            {
                var objEspecialidad = Contexto.Especialidades
                    .FirstOrDefault(x => x.IdEspecialidad == Idespecialidad);// &&
                                                                         // x.TipoPreguntaId == ConstantHelpers.TipoPregunta.PreguntaFrecuente);

                if (objEspecialidad == null)
                {
                    TempData["MensajeEspecialidad"] = "El registro no existe en BD.";
                    return RedirectToAction("Index");
                }

                Contexto.Especialidades.Remove(objEspecialidad);
                Contexto.SaveChanges();
                TempData["MensajeEspecialidad"] = "El registro fue eliminado exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["MensajeEspecialidad"] = "Ocurrio un error, contacte con el administrador";
            }

            return RedirectToAction("Index");
        }

        [RolAuthFilter(ConstanHelpers.Rol.Administrador)]
        public ActionResult AddEdit(int? Idespecialidad)
        {
            var viewModel = new EspecialidadAddEditViewModel();

            viewModel.IdEspecialidad = Idespecialidad;
            viewModel.CargarDatos(Contexto);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RolAuthFilter(ConstanHelpers.Rol.Administrador)]
        public ActionResult AddEdit(EspecialidadAddEditViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    viewModel.IdEspecialidad = viewModel.IdEspecialidad;
                    viewModel.CargarDatos(Contexto);

                    TryUpdateModel(viewModel);

                    TempData["MensajeAddEditEspecialidad"] = "Por favor, complete los campos requeridos.";
                    return View(viewModel);
                }

                Especialidades objEspecialidad = null;

                if (viewModel.IdEspecialidad.HasValue)
                {
                    objEspecialidad = Contexto.Especialidades.Find(viewModel.IdEspecialidad);
                }
                else
                {
                    objEspecialidad =  new Especialidades();
                    objEspecialidad.Nombre = viewModel.Nombre;
                    objEspecialidad.Descripcion = viewModel.Descripcion;
                    //objEspecialidad.Fecha = DateTime.Now;
                    //objEspecialidad.Telefono = viewModel.Telefono;
                    //objEspecialidad.IdEspecialidad = viewModel.Especialidades;
                    //objEspecialidad.IdUsuario = Session.GetUsuarioId();


                    Contexto.Especialidades.Add(objEspecialidad);
                }

                objEspecialidad.Nombre = viewModel.Nombre;
                objEspecialidad.Descripcion = viewModel.Descripcion;
                //objEspecialidad.Fecha = DateTime.Now;
                //objEspecialidad.Telefono = viewModel.Telefono;
                //objEspecialidad.IdEspecialidad = viewModel.Especialidades;
                //objEspecialidad.IdUsuario = Session.GetUsuarioId();
                
                Contexto.SaveChanges();
                TempData["MensajeEspecialidad"] = "La consulta fue procesada exitosamente.";
            }
            catch (Exception ex)
            {
                viewModel.IdEspecialidad = viewModel.IdEspecialidad;
                //viewModel.CargarDatos(Contexto);

                TryUpdateModel(viewModel);

                TempData["MensajeAddEditEspecialidad"] = "Hubo un error, consulte con el administrador.";
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }
    }
}
