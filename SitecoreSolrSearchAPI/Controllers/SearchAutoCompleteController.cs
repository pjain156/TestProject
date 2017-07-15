using SitecoreSolrSearchAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitecoreSolrSearchAPI.Controllers
{
    public class SearchAutoCompleteController : Controller
    {
        //
        // GET: /SearchAutoComplete/
        public ActionResult AutoComplete(string querytxt)
        {
            string datamodel;
            SearchAPI searchapi = new SearchAPI();
            datamodel = searchapi.AutoComplete("New");
            
            return View("AutoComplete",model:datamodel);
        }
	}
}