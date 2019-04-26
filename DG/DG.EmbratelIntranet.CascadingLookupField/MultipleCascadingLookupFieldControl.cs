using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Text;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace DG.EmbratelIntranet.CascadingLookupField
{
    [Guid("778F21A7-2214-4009-9C66-6BCDA13EA7F7")]
    public class MultipleCascadingLookupFieldControl : BaseFieldControl
    {
        SPFieldLookupValueCollection _fieldVals;
        List<ListItem> _availableItems = null;

        protected SPHtmlSelect SelectCandidate;
        protected SPHtmlSelect SelectResult;
        protected HtmlButton AddButton;
        protected HtmlButton RemoveButton;
        protected GroupedItemPicker MultiLookupPicker;

        protected override string DefaultTemplateName { get { return "CascadingLookupMultiFieldControl"; } }

        protected override void OnInit(EventArgs e)
        {
            if (ControlMode == SPControlMode.Edit || ControlMode == SPControlMode.Display)
            {
                if (base.ListItemFieldValue != null)
                {
                    _fieldVals = base.ListItemFieldValue as SPFieldLookupValueCollection;
                }
                else { _fieldVals = new SPFieldLookupValueCollection(); }
            }
            if (ControlMode == SPControlMode.New) { _fieldVals = new SPFieldLookupValueCollection(); }
            base.OnInit(e);
            Initialize();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (ControlMode != SPControlMode.Display)
            {
                if (!Page.IsPostBack)
                {
                    SetValue();
                }
            }
        }

        protected override void CreateChildControls()
        {
            if (this.Field != null && this.ControlMode != SPControlMode.Display)
            {
                if (!this.ChildControlsCreated)
                {
                    CascadingLookupField field = this.Field as CascadingLookupField;
                    base.CreateChildControls();

                    MultiLookupPicker = (GroupedItemPicker)TemplateContainer.FindControl("MultiLookupPicker");
                    BuildAvailableItems(ref MultiLookupPicker);

                    SelectCandidate = (SPHtmlSelect)TemplateContainer.FindControl("SelectCandidate");
                    SelectResult = (SPHtmlSelect)TemplateContainer.FindControl("SelectResult");

                    AddButton = (HtmlButton)TemplateContainer.FindControl("AddButton");
                    RemoveButton = (HtmlButton)TemplateContainer.FindControl("RemoveButton");
                }
            }
        }

        private void BuildAvailableItems(ref GroupedItemPicker m)
        {
            if (!Util.ListIsNullOrEmpty(_availableItems))
            {
                foreach (ListItem i in _availableItems)
                {
                    m.AddItem(i.Value, i.Text, string.Empty, string.Empty);
                }
            }
        }

        public override object Value
        {
            get
            {
                EnsureChildControls();
                SPFieldLookupValueCollection _vals = new SPFieldLookupValueCollection();
                ICollection s = MultiLookupPicker.SelectedIds;
                if (s != null && s.Count > 0)
                {
                    foreach (var i in s)
                    {
                        ListItem z = _availableItems.Find(x => (x.Value == i.ToString()));
                        if (z != null)
                        {
                            _vals.Add(new SPFieldLookupValue(int.Parse(z.Value), z.Text));
                        }
                    }
                    return _vals;
                }
                return _vals;
            }
            set
            {
                EnsureChildControls();
                base.Value = value as SPFieldLookupValueCollection;
            }
        }

        private void Initialize()
        {
            _availableItems = Util.GetAvailableValues(
              ((CascadingLookupField)base.Field), this);
            if (!Util.ListIsNullOrEmpty(_availableItems))
            {
                EnsureValuesAreAvailable();
            }
        }

        private void EnsureValuesAreAvailable()
        {
            if (_fieldVals != null && _fieldVals.Count > 0)
            {
                foreach (SPFieldLookupValue i in _fieldVals)
                {
                    ListItem z = _availableItems.Find(x => (x.Value.ToLower() == i.LookupId.ToString().ToLower()));
                    if (z == null)
                    {
                        _availableItems.Add(new ListItem(i.LookupValue, i.LookupId.ToString()));
                    }
                }
            }
        }

        private void SetValue()
        {
            if (_fieldVals != null && _fieldVals.Count > 0)
            {
                string s = string.Empty;
                foreach (SPFieldLookupValue i in _fieldVals)
                {
                    MultiLookupPicker.AddInitialSelection(i.LookupId.ToString(), i.LookupValue);
                }
            }
        }
    }
}