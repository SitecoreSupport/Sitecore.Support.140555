using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Pipelines.Save;

namespace Sitecore.Support.Pipelines.Save
{
    public class Save : Sitecore.Pipelines.Save.Save
    {
        public new void Process(SaveArgs args)
        {
            foreach (SaveArgs.SaveItem item in args.Items)
            {
                foreach (SaveArgs.SaveField field in item.Fields)
                {
                    if (field.Value == "<br>")
                    {
                        field.Value = String.Empty;
                    }
                }
            }
            base.Process(args);
        }
    }
}