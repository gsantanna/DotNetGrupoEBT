using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace DG.EmbratelIntranet.CascadingLookupField
{

    internal sealed class Util
    {
        internal static bool ListIsNullOrEmpty(List<ListItem> list)
        {
            return (list != null && list.Count > 0) ? false : true;
        }

        internal static List<ListItem> GetAvailableValues(CascadingLookupField f, BaseFieldControl thisfield)
        {
            List<ListItem> _v = null;
            List<SPListItem> items = new List<SPListItem>();
            Guid fId = new Guid(f.LookupField);

            SPList lookupList = SPContext.Current.Web.Lists[new Guid(f.LookupList)];
            try
            {
                if (f.QueryFilter != null)
                {
                    SPQuery query = new SPQuery();
                    query.Query = f.QueryFilter.Query;

                    Regex regex = new Regex(@"\[(.[^\[\]]+)");

                    foreach (string coluna in regex.Matches(query.Query).OfType<Match>().Select(m => m.Groups[1].Value)
                        .Where(m => m.ToUpper() != "HOJE" && m.ToUpper() != "EU"))
                    {
                        BaseFieldControl ctr = GetFieldControlByName(thisfield, coluna);

                        if (!(ctr is MultipleCascadingLookupFieldControl) && !(ctr is CascadingLookupFieldControl) && ctr.Controls[0] != null)
                        {
                            if (ctr.Controls[0] is ListControl)
                                (ctr.Controls[0] as ListControl).AutoPostBack = true;
                            else if (ctr.Controls[0] is TextBox)
                                (ctr.Controls[0] as TextBox).AutoPostBack = true;
                        }

                        string value = string.Empty;

                        if (ctr != null)
                        {
                            if (ctr.Value is SPFieldLookupValue)
                                value = ((SPFieldLookupValue)ctr.Value).LookupId.ToString();
                            else
                                value = ctr.Value.ToString();
                        }
                        else if (SPContext.Current.ListItem != null)
                        {
                            value = SPContext.Current.ListItem[coluna].ToString();
                        }

                        query.Query = query.Query.Replace(string.Format("[{0}]", coluna), value);
                    }

                    items = lookupList.GetItems(query).OfType<SPListItem>().ToList();
                }
                else
                {
                    items = lookupList.Items.OfType<SPListItem>().ToList();
                }
            }
            catch { }
            //if (items.Count <= 0) { items = lookupList.Items.OfType<SPListItem>().ToList(); }
            try
            {
                if (items.Count > 0)
                {
                    _v = items
                      .Cast<SPListItem>()
                      .Where(e => e[e.Fields[fId].InternalName] != null)
                      .Select(e => new ListItem((
                        e.Fields[fId].GetFieldValueAsText(e[fId])), e.ID.ToString()))
                      .ToList<ListItem>();
                }
            }
            catch { }
            return _v;
        }

        internal static BaseFieldControl GetFieldControlByName(BaseFieldControl thisfield, String fieldNameToSearch)
        {
            String iteratorId = GetIteratorByFieldControl(thisfield).ClientID;

            foreach (IValidator validator in thisfield.Page.Validators)
            {
                if (validator is BaseFieldControl)
                {
                    BaseFieldControl baseField = (BaseFieldControl)validator;
                    if (baseField.FieldName == fieldNameToSearch &&
                        GetIteratorByFieldControl(baseField).ClientID == iteratorId)
                        return baseField;
                }
            }

            return null;
        }

        internal static ListFieldIterator GetIteratorByFieldControl(BaseFieldControl fieldControl)
        {
            return (Microsoft.SharePoint.WebControls.ListFieldIterator)fieldControl.Parent.Parent.Parent.Parent.Parent;
        }
    }
}