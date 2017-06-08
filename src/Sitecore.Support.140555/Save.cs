using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Pipelines.Save;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace Sitecore.Support.Pipelines.Save
{
    public class Save : Sitecore.Pipelines.Save.Save
    {
        public new void Process(SaveArgs args)
        {
            foreach (SaveArgs.SaveItem item in args.Items)
            {
                Item currItem = Context.ContentDatabase.Items[item.ID];
                Assert.IsNotNull(currItem, "Sitecore.Support.140555: currItem = null");
                foreach (SaveArgs.SaveField field in item.Fields)
                {
                    Assert.IsNotNull(currItem.Fields[field.ID], "Sitecore.Support.140555: currItem.Fields[field.ID] = null");
                    if (currItem.Fields[field.ID].TypeKey == "single-line text" || currItem.Fields[field.ID].TypeKey == "text" || currItem.Fields[field.ID].TypeKey == "multi-line text")
                    {
                        if (field.Value == "<br>")
                        {
                            field.Value = String.Empty;
                        }
                    }
                }
            }
            base.Process(args);
        }
    }
}