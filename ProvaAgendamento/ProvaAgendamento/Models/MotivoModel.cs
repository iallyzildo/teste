using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProvaAgendamento.Entity;

namespace ProvaAgendamento.Models
{
    public class MotivoModel
    {

        private Agendamento_ProvaEntities db = new Agendamento_ProvaEntities();

        public List<Motivo> todosMotivos()
        {
            var lista = from m in db.Motivo
                        select m;
            return lista.ToList();
        }
    }
}