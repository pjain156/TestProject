using Sitecore.Mvc.Controllers;
using SitecoreSolrSearchAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitecoreSolrSearchAPI.Controllers
{
    public class SolrTestController : SitecoreController  
    {
        //
        // GET: /SolrTest/
        [HttpGet]
        public ActionResult Test1()
        {

            return View("FirstTest");
        }

        [HttpPost]
        public ActionResult Test1(string querytxt)
        {
            IEnumerable<Sitecore.Data.Items.Item> datamodel;
            SearchAPI searchapi = new SearchAPI();
            datamodel = searchapi.BasicSearch(querytxt);
            return View(datamodel);
        }
	}
}