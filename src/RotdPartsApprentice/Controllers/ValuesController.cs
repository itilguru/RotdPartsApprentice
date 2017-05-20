using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RotdPartsApprentice.Models;
using RotdPartsApprentice.Helpers;

namespace RotdPartsApprentice.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private OmronHelper _omronHelper;

        [HttpPost]
        public bool RequestPart(PartRequest request)
        {
            _omronHelper = new OmronHelper(request);
            _omronHelper.Start();
            return true;
        }

        [HttpGet]
        public string GetStatus() {
            return _omronHelper.GetOmronMessage();
        }

    }
}