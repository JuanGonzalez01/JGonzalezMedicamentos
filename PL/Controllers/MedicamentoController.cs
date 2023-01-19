using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MedicamentoController : Controller
    {
        // GET: Medicamento
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Medicamento.GetAll();

            return View(result);
        }

        [HttpGet]
        public ActionResult Form(int? idMedicamento)
        {
            ML.Medicamento medicamento = new ML.Medicamento();
            ML.Result resultProveedores = BL.Proveedor.GetAll();

            if (idMedicamento != null)
            {
                //GetById
                ML.Result result = BL.Medicamento.GetById(idMedicamento.Value);

                if (result.Status)
                {
                    medicamento = (ML.Medicamento)result.Object;
                }
            }
            else
            {
                medicamento.Proveedor = new ML.Proveedor();
            }

            medicamento.Proveedor.Proveedores = resultProveedores.Objects;

            return View(medicamento);
        }

        [HttpPost]
        public ActionResult Formulario(ML.Medicamento medicamento)
        {
            if (medicamento.IdMedicamento == 0)
            {
                //Add

                ML.Result result = BL.Medicamento.Add(medicamento);
                if (result.Status)
                {
                    ViewBag.Success = true;
                    ViewBag.Message = "Medicamento agregado con éxito.";
                }
                else
                {
                    ViewBag.Success = false;
                    ViewBag.Message = $"Error: {result.Message}";
                }
            }
            else
            {
                //Update
                ML.Result result = BL.Medicamento.Update(medicamento);
                if (result.Status)
                {
                    ViewBag.Success = true;
                    ViewBag.Message = "Medicamento modificado con éxito.";
                }
                else
                {
                    ViewBag.Success = false;
                    ViewBag.Message = $"Error: {result.Message}";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? idMedicamento)
        {
            if (idMedicamento == null)
            {
                ViewBag.Success = false;
                ViewBag.Message = "Error: No se encontró el ID.";
            }
            else
            {
                ML.Result result = BL.Medicamento.Delete(idMedicamento.Value);

                if (result.Status)
                {
                    ViewBag.Success = true;
                    ViewBag.Message = "Medicamento eliminado con éxito.";
                }
                else
                {
                    ViewBag.Success = false;
                    ViewBag.Message = $"Error: {result.Message}";
                }
            }

            return View("Formulario");
        }
    }
}