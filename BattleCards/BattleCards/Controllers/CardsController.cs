using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        public HttpResponse Add()
        {
            return this.View();
        }

        public HttpResponse Collection()
        {
            return this.View();
        }

        public HttpResponse All()
        {
            return this.View();
        }
    }
}
