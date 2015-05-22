using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProvaAgendamento.Entity;

namespace ProvaAgendamento.Models
{
    public class MedicoModel
    {

        private Agendamento_ProvaEntities db = new Agendamento_ProvaEntities();

        public List<Medico> todosMedicos()
        {
            var lista = from m in db.Medico
                        select m;
            return lista.ToList();
        }

    }
}