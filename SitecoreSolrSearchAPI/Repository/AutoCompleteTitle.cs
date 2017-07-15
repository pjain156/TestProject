using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSolrSearchAPI.Repository
{
    public class AutoCompleteTitle : IComputedIndexField
    {
        public object ComputeFieldValue(IIndexable indexable)
        {
            if (indexable == null) throw new ArgumentNullException("indexable");
            var scIndexable = indexable as SitecoreIndexableItem;
            if (scIndexable == null)
            {
                Log.Warn(
                    this + " : unsupported IIndexable type : " + indexable.GetType(), this);
                return false;
            }
            var item = (Item)scIndexable;
            if (item == null)
            {
                Log.Warn(
                    this + " : unsupported SitecoreIndexableItem type : " + scIndexable.GetType(), this);
                return false;
            }
            if (String.Compare(item.Database.Name, "core", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return false;
            }
            return item["title"];
        }
        public string FieldName { get; set; }
        public string ReturnType { get; set; }
    }
}