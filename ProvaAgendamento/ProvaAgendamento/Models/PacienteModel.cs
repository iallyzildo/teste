using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProvaAgendamento.Entity;

namespace ProvaAgendamento.Models
{
    public class PacienteModel
    {
        private Agendamento_ProvaEntities db = new Agendamento_ProvaEntities();

        public List<Paciente> todosPacientes()
        {
            var lista = from p in db.Paciente
                        select p;
            return lista.ToList();
        }
    }
}