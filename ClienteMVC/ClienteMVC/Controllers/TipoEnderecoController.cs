using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClienteMVC.Entity;
using ClienteMVC.Models;
using ClienteMVC.ViewModels;

namespace ClienteMVC.Controllers
{
    public class TipoEnderecoController : Controller
    {

        private TipoEnderecoModel teModel = new TipoEnderecoModel();

        public ActionResult Index()
        {
            TipoEnderecoViewModel vm = new TipoEnderecoViewModel();
            vm.tiposEndereco = teModel.todosTipoEnderecos();
            return View(vm);
        }

        public PartialViewResult List(string q)
        {
            var tiposEndereco = teModel.listarTipoEnderecos(q);
            return PartialView(tiposEndereco);
        }

    }
}
