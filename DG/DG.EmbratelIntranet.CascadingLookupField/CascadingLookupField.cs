using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using System.Globalization;

namespace DG.EmbratelIntranet.CascadingLookupField
{
    [Guid("CADE9B7D-1777-4503-854E-B3EE09A6554B")]
    [SharePointPermission(SecurityAction.Demand, ObjectModel = true)]
    public class CascadingLookupField : SPFieldLookup
    {
        private string _listViewFilter;
        private string _queryFilter;
        private string _allowMultiple;
        private string _isFilterRecursive;
        public CascadingLookupField(SPFieldCollection fields, string fieldName)
            : base(fields, fieldName)
        {
        }

        public CascadingLookupField(SPFieldCollection fields, string typeName, string displayName)
            : base(fields, typeName, displayName)
        {
        }

        public override void OnAdded(SPAddFieldOptions op)
        {
            base.OnAdded(op);
            Update();
        }

        public override void Update()
        {

            UpdateFieldProperties();
            base.Update();
            CleanUpThreadData();
        }

        private void UpdateFieldProperties()
        {
            string _v = GetFieldThreadDataValue("ListViewFilter", true);
            string _l = GetFieldThreadDataValue("QueryFilterAsString", true);
            string _m = GetFieldThreadDataValue("SupportsMultipleValues", true);
            string _r = GetFieldThreadDataValue("IsFilterRecursive", true);
            base.SetCustomProperty("ListViewFilter", _v);
            base.SetCustomProperty("QueryFilterAsString", _l);
            base.SetCustomProperty("SupportsMultipleValues", _m);

            base.SetCustomProperty("IsFilterRecursive", ((!string.IsNullOrEmpty(_l)) ? _r : "false"));

            if (this.AllowMultipleValues)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(base.SchemaXml);
                EnsureAttribute(doc, "Mult", "TRUE");
                base.SchemaXml = doc.OuterXml;
            }
        }

        private void EnsureAttribute(XmlDocument doc, string name, string value)
        {
            XmlAttribute attribute = doc.DocumentElement.Attributes[name];
            if (attribute == null)
            {
                attribute = doc.CreateAttribute(name);
                doc.DocumentElement.Attributes.Append(attribute);
            }
            doc.DocumentElement.Attributes[name].Value = value;
        }

        public override string GetValidatedString(object value)
        {
            if (this.Required)
            {
                string _s = string.Format(CultureInfo.InvariantCulture,
                  "Você deve especificar um valor para este campo obrigatório.", this.Title);
                if (value == null)
                {
                    throw new SPFieldValidationException(_s);
                }
                else
                {
                    if (this.AllowMultipleValues)
                    {
                        SPFieldLookupValueCollection c = value as SPFieldLookupValueCollection;
                        if (c.Count < 0)
                        {
                            throw new SPFieldValidationException(_s);
                        }
                    }
                    else
                    {
                        SPFieldLookupValue v = value as SPFieldLookupValue;
                        if (v.LookupId < 1 && (string.IsNullOrEmpty(v.LookupValue) || v.LookupValue == "(Nenhum)"))
                        {
                            throw new SPFieldValidationException(_s);
                        }
                    }
                }
            }
            return base.GetValidatedString(value);
        }

        private string GetFieldThreadDataValue(string propertyName, bool ignoreEmptyValue)
        {
            string _d = (string)Thread.GetData(Thread.GetNamedDataSlot(propertyName));
            if (string.IsNullOrEmpty(_d) && !ignoreEmptyValue)
            {
                _d = (string)base.GetCustomProperty(propertyName);
            }
            return _d;
        }

        private void SetFieldThreadDataValue(string propertyName, string value)
        {
            Thread.SetData(Thread.GetNamedDataSlot(propertyName), value);
        }

        private void CleanUpThreadData()
        {
            Thread.FreeNamedDataSlot("ListViewFilter");
            Thread.FreeNamedDataSlot("QueryFilterAsString");
            Thread.FreeNamedDataSlot("SupportsMultipleValues");
            Thread.FreeNamedDataSlot("IsFilterRecursive");
        }

        public override bool Sortable
        {
            get
            {
                return (this.AllowMultipleValues) ? false : base.Sortable;
            }
        }

        public override bool AllowMultipleValues
        {
            get
            {
                if (_allowMultiple == null)
                {
                    _allowMultiple = GetFieldThreadDataValue("SupportsMultipleValues", false);
                }
                return (!string.IsNullOrEmpty(_allowMultiple) && _allowMultiple.ToLower() == "true") ? true : false;
            }
            set
            {
                SetFieldThreadDataValue("SupportsMultipleValues", value.ToString());
            }
        }

        public bool IsFilterRecursive
        {
            get
            {
                if (_isFilterRecursive == null)
                {
                    _isFilterRecursive = GetFieldThreadDataValue("IsFilterRecursive", false);
                }
                return (!string.IsNullOrEmpty(_isFilterRecursive) && _isFilterRecursive.ToLower() == "true") ? true : false;
            }
            set
            {
                SetFieldThreadDataValue("IsFilterRecursive", value.ToString());
            }
        }

        public string ListViewFilter
        {
            get
            {
                if (_listViewFilter == null)
                {
                    _listViewFilter = GetFieldThreadDataValue("ListViewFilter", false);
                }
                return (!string.IsNullOrEmpty(_listViewFilter)) ? _listViewFilter : null;
            }
            set
            {
                SetFieldThreadDataValue("ListViewFilter",
                  (!string.IsNullOrEmpty(value) ? value : ""));
            }
        }

        public string QueryFilterAsString
        {
            get
            {
                if (_queryFilter == null)
                {
                    _queryFilter = GetFieldThreadDataValue("QueryFilterAsString", false);
                }
                return (!string.IsNullOrEmpty(_queryFilter)) ? _queryFilter : null;
            }
            set
            {
                SetFieldThreadDataValue("QueryFilterAsString",
                  (!string.IsNullOrEmpty(value) ? value : ""));
            }
        }

        public SPQuery QueryFilter
        {
            get
            {
                SPQuery q = null;
                if (!string.IsNullOrEmpty(this.QueryFilterAsString))
                {
                    q = new SPQuery();
                    q.Query = SPHttpUtility.HtmlDecode(this.QueryFilterAsString);
                    if (IsFilterRecursive)
                    {
                        q.ViewAttributes = "Scope=\"Recursive\"";
                    }
                }
                else if (!string.IsNullOrEmpty(this.ListViewFilter))
                {
                    try
                    {
                        SPWeb w = SPContext.Current.Site.OpenWeb(LookupWebId);
                        SPView _v = w.Lists[new Guid(LookupList)].Views[new Guid(ListViewFilter)];
                        if (_v != null)
                        {
                            q = new SPQuery();
                            q.Query = _v.Query; // use only view's query to avoid view's excess baggage :)
                            if (_v.Scope != SPViewScope.Default)
                            {
                                q.ViewAttributes = string.Format(CultureInfo.InvariantCulture, "Scope=\"{0}\"", _v.Scope);
                            }
                        }
                    }
                    catch { }
                }

                return q;
            }
        }

        public override BaseFieldControl FieldRenderingControl
        {
            [SharePointPermission(SecurityAction.LinkDemand, ObjectModel = true)]
            get
            {
                BaseFieldControl fieldControl = null;
                if (this.AllowMultipleValues)
                {
                    fieldControl = new MultipleCascadingLookupFieldControl();
                }
                else
                {
                    fieldControl = new CascadingLookupFieldControl();
                }
                fieldControl.FieldName = this.InternalName;
                
                return fieldControl;
            }
        }
    }
}