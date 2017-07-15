using Newtonsoft.Json;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using SitecoreSolrSearchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSolrSearchAPI.Repository
{
    public class SearchAPI
    {
        public IEnumerable<Sitecore.Data.Items.Item> BasicSearch(string querytext)
        {
            var indexName = String.Format("sitecore_{0}_index", Sitecore.Context.Database.Name);
            ISearchIndex index = ContentSearchManager.GetIndex(indexName);
            var tID= new ID("{766464BE-12CA-4441-8DF2-2D3865B57B23}");
            using (IProviderSearchContext context = index.CreateSearchContext())
            {
                var query = context.GetQueryable<TestModel>().Where(x => x.description.Contains(querytext));
                query = query.Filter(x => x.TemplateId==tID);
                var results = query.GetResults();
                return results.Hits.Select(h => GetSiteCoreItem(h.Document.ItemId)).ToArray();


            }
            
        }
        public string AutoComplete(string querytext)
        {
            var indexName = String.Format("sitecore_{0}_index", Sitecore.Context.Database.Name);
            ISearchIndex index = ContentSearchManager.GetIndex(indexName);
            var tID = new ID("{766464BE-12CA-4441-8DF2-2D3865B57B23}");
           
           List<string> Listtm=new List<string>();
            using (IProviderSearchContext context = index.CreateSearchContext())
            {
                var query = context.GetQueryable<TestModel>();//.Where(x => x.title.Contains("News"));
                query = query.Filter(x => x.TemplateId == tID);
                var results = query.GetResults();
                var finalresult=results.Hits.Select(h => GetSiteCoreItem(h.Document.ItemId)).ToArray();
                
                foreach(var Item in finalresult)
                {
                    JsonModel tm = new JsonModel();
                    Listtm.Add(Item.Fields["title"].ToString());
                   // tm.title = Item.Fields["title"].ToString();
                //    Listtm.Add(tm);
                }
                
            }
            return JsonConvert.SerializeObject(Listtm);


        }
        public Sitecore.Data.Items.Item GetSiteCoreItem(ID id)
        {


            Database database = Sitecore.Context.Database;

            Sitecore.Data.Items.Item item = database.GetItem(id);

            return item;
        }
    }
}