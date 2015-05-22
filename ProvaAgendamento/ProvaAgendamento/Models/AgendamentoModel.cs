using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProvaAgendamento.Entity;

namespace ProvaAgendamento.Models
{
    public class AgendamentoModel
    {
        private Agendamento_ProvaEntities db = new Agendamento_ProvaEntities();

        public List<Agendamento> todosAgendamentos()
        {
            var lista = from a in db.Agendamento
                        select a;
            return lista.ToList();
        }

        public string adicionarAgendamento(Agendamento a)
        {
            string erro = null;
            try
            {
                db.Agendamento.AddObject(a);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public Agendamento obterAgendamento(int idAgendamento)
        {
            var lista = from a in db.Agendamento
                        where a.IdAgendamento == idAgendamento
                        select a;
            return lista.ToList().FirstOrDefault();
        }

        public string editarAgendamento(Agendamento a)
        {
            string erro = null;
            try
            {
                if (a.EntityState == System.Data.EntityState.Detached)
                {
                    db.Agendamento.Attach(a);
                }
                db.ObjectStateManager.ChangeObjectState(a, System.Data.EntityState.Modified);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string excluirAgendamento(Agendamento a)
        {
            string erro = null;
            try
            {
                db.Agendamento.DeleteObject(a);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

    }
}