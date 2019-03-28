﻿using Examine;
using System.IO;
using System.Web;
using System.Web.Hosting;
using umbraco.BusinessLogic;
using Umbraco.Core;
using Umbraco.Core.Configuration;
using Umbraco.Web;
using Umbraco.Web.Routing;
using Umbraco.Web.Security;
using UmbracoExamine;

namespace Escc.Umbraco.EditorTools.Events
{
    public class ExamineEvents : ApplicationBase
    {
        public ExamineEvents()
        {
            ExamineManager.Instance.IndexProviderCollection["InternalIndexer"].GatheringNodeData += InternalExamineEvents_GatheringNodeData;
        }

        void InternalExamineEvents_GatheringNodeData(object sender, IndexingNodeDataEventArgs e)
        {
            if (e.IndexType == IndexTypes.Content)
            {
                var contentService = ApplicationContext.Current.Services.ContentService;
                var node = contentService.GetById(e.NodeId);
                var isPublished = node.Published;
                e.Fields.Add("customIsPublished", isPublished.ToString());

                if (node.ExpireDate.HasValue)
                {
                    e.Fields.Add("customExpireDate", node.ExpireDate.Value.ToIsoString());
                }
                else
                {
                    e.Fields.Remove("customExpireDate");
                }
            }
        }
    }
}