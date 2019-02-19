using Repository_Pattern.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repository_Pattern.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        #region Private Property

        private IHomeService _homeService { get; }

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            return View(_homeService.Get());
        }
    }
}