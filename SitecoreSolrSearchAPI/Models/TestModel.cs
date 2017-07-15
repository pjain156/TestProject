using Sitecore.ContentSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Sitecore.ContentSearch.SearchTypes;

namespace SitecoreSolrSearchAPI.Models
{
    public class TestModel : SearchResultItem, IObjectIndexers
    {
        [IndexField("description_t")]
        public virtual string description { get; set; }
        [IndexField("title_t")]
        public virtual string title { get; set; }
       

    }
}