﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Principal.Controllers
{
    public class WorkersController : Controller
    {
        // GET: Workers
        public ActionResult Index()
        {
            return View();
        }
    }
}