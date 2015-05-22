using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvaAgendamento.Entity;
using ProvaAgendamento.Models;

namespace ProvaAgendamento.Controllers
{
    public class AgendamentoController : Controller
    {
        private AgendamentoModel agendamentoModel = new AgendamentoModel();
        private MedicoModel medicoModel = new MedicoModel();
        private MotivoModel motivoModel = new MotivoModel();
        private PacienteModel pacienteModel = new PacienteModel();

        public ActionResult Index()
        {
            return View(agendamentoModel.todosAgendamentos());
        }

        public ActionResult Edit(int id)
        {
            Agendamento a = new Agendamento();
            ViewBag.Titulo = "Novo Agendamento";
            int pacienteSelecionado = 0;
            int motivoSelecionado = 0;
            int medicoSelecionado = 0;
            if (id != 0)
            {
                a = agendamentoModel.obterAgendamento(id);
                ViewBag.Titulo = "Editar Agendamento";
                pacienteSelecionado = a.IdPaciente;
                motivoSelecionado = a.IdMotivo;
                medicoSelecionado = a.IdMedico;
            }
            ViewBag.IdPaciente = new
                SelectList(pacienteModel.todosPacientes(), "IdPaciente",
                            "Nome", pacienteSelecionado);
            ViewBag.IdMotivo = new
                SelectList(motivoModel.todosMotivos(), "IdMotivo",
                            "Descricao", motivoSelecionado);
            ViewBag.IdMedico = new
                SelectList(medicoModel.todosMedicos(), "IdMedico",
                            "Nome", medicoSelecionado);
            return View(a);
        }

        [HttpPost]
        public ActionResult Edit(Agendamento a)
        {
            string erro = null;
            if (a.IdAgendamento == 0)
            {
                erro = agendamentoModel.adicionarAgendamento(a);
            }
            else
            {
                erro = agendamentoModel.editarAgendamento(a);
            }
            if (erro != null)
            {
                ViewBag.Erro = erro;
                ViewBag.IdPaciente = new
                    SelectList(pacienteModel.todosPacientes(), "IdPaciente", "Nome");
                ViewBag.IdMotivo = new
                    SelectList(motivoModel.todosMotivos(), "IdMotivo", "Descricao");
                ViewBag.IdMedico = new
                    SelectList(medicoModel.todosMedicos(), "IdMedico", "Nome");
                return View(a);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            Agendamento a = agendamentoModel.obterAgendamento(id);
            agendamentoModel.excluirAgendamento(a);
            return RedirectToAction("Index");
        }

    }
}
