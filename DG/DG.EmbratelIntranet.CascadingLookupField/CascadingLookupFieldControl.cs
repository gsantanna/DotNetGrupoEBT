using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Web;

namespace DG.EmbratelIntranet.CascadingLookupField
{
    [Guid("36960BE5-5FDD-4368-AA93-EF34A3DC5FD7")]
    public sealed class CascadingLookupFieldControl : LookupField
    {
        SPFieldLookupValue _fieldVal;
        List<ListItem> _availableItems = null;

        protected override string DefaultTemplateName { get { return "CascadingLookupFieldControl"; } }

        protected override void OnInit(EventArgs e)
        {
            if (ControlMode == SPControlMode.Edit || ControlMode == SPControlMode.Display)
            {
                if (base.ListItemFieldValue != null)
                {
                    _fieldVal = base.ListItemFieldValue as SPFieldLookupValue;
                }
                else { _fieldVal = new SPFieldLookupValue(); }
            }
            if (ControlMode == SPControlMode.New) { _fieldVal = new SPFieldLookupValue(); }
            base.OnInit(e);
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
            Initialize();

            if (base.Field != null && base.ControlMode != SPControlMode.Display)
            {
                if (!this.ChildControlsCreated)
                {
                    this.Controls.Clear();
                    this.Controls.Add(new LiteralControl("<span dir=\"none\">"));
                    CascadingLookupField field = base.Field as CascadingLookupField;

                    if (_availableItems != null && _availableItems.Count > 19 && IsExplorerOnWin())
                    {
                        CreateCustomSelect();
                    }
                    else { CreateStandardSelect(); }
                    this.Controls.Add(new LiteralControl("<br /></span>"));
                }
            }

        }

        private bool IsExplorerOnWin()
        {
            HttpBrowserCapabilities hc = this.Page.Request.Browser;
            return (hc.Browser.ToLower() == "ie" &&
              hc.Platform.ToLower() == "winnt" && hc.MajorVersion > 5);
        }

        private void CreateStandardSelect()
        {
            DropDownList l = new DropDownList();
            l.ID = "Lookup";
            l.AutoPostBack = true;
            l.CausesValidation = false;
            l.ToolTip = string.Format(CultureInfo.InvariantCulture, "{0}", Field.InternalName);
            if (!Util.ListIsNullOrEmpty(_availableItems))
            {
                l.Items.Clear();
                l.Items.AddRange(_availableItems.ToArray());
            }
            if (!Field.Required) { l.Items.Insert(0, new ListItem("(Nenhum)", "0")); }
            this.Controls.Add(l);
        }

        private void CreateCustomSelect()
        {
            HtmlInputHidden h = new HtmlInputHidden();
            h.ID = string.Format(CultureInfo.InvariantCulture, "{0}_Hidden", Field.InternalName);
            this.Controls.Add(h);
            this.Controls.Add(new LiteralControl("<span style=\"vertical-align: middle\">"));

            HtmlInputText t = new HtmlInputText();
            t.ID = "Txtbx";
            t.Attributes.Add("class", "ms-lookuptypeintextbox");
            t.Attributes.Add("onfocusout", "HandleLoseFocus()");
            t.Attributes.Add("opt", "_Select");
            t.Attributes.Add("title", string.Format(CultureInfo.InvariantCulture, "{0}", Field.InternalName));
            t.Attributes.Add("optHid", h.ClientID);
            t.Attributes.Add("onkeypress", "HandleChar()");
            t.Attributes.Add("onkeydown", "HandleKey()");
            t.Attributes.Add("match", "");
            t.Attributes.Add("choices", ConcatAvailableItems("|"));
            t.Attributes.Add("onchange", "HandleChange()");
            this.Controls.Add(t);

            this.Controls.Add(new LiteralControl("<img onclick=\"ShowDropdown('" + t.ClientID + "');\" " +
              "src=\"/_layouts/15/images/dropdown.gif\" style=\"border-width: 0px; vertical-align: middle;\" />"));

            this.Controls.Add(new LiteralControl("</span>"));
        }

        private string ConcatAvailableItems(string delimiter)
        {
            string retval = string.Empty;
            if (!Util.ListIsNullOrEmpty(_availableItems))
            {
                if (!this.Field.Required) { retval += string.Format(CultureInfo.InvariantCulture, "{0}{1}{0}0", delimiter, "(Nenhum)"); }
                foreach (ListItem i in _availableItems)
                {
                    retval += string.Format("{0}{1}{0}{2}", delimiter, i.Text, i.Value);
                }

                return retval.Trim().Substring(1);
            }

            return retval;
        }

        private Control GetRenderingWebControl()
        {
            Control ctrl = null;
            foreach (Control c in Controls)
            {
                if (c.ID == "Lookup" && c.GetType().FullName == "System.Web.UI.WebControls.DropDownList")
                {
                    ctrl = c;
                    break;
                }
                else if (c.ID == "Txtbx" && c.GetType().FullName == "System.Web.UI.HtmlControls.HtmlInputText")
                {
                    ctrl = c;
                    break;
                }
            }

            return ctrl;
        }

        public override object Value
        {
            get
            {
                EnsureChildControls();
                Control c = GetRenderingWebControl();
                if (c != null)
                {
                    if (c is System.Web.UI.WebControls.DropDownList)
                    {
                        DropDownList ctrl = c as DropDownList;
                        if (ctrl.SelectedItem != null && ctrl.SelectedItem.Value != "0" && ctrl.SelectedItem.Text != "(Nenhum)")
                        {
                            return (new SPFieldLookupValue(
                              int.Parse(ctrl.SelectedItem.Value), ctrl.SelectedItem.Text));
                        }
                    }
                    else if (c is System.Web.UI.HtmlControls.HtmlInputText)
                    {
                        return GetCustomSelectValue(((HtmlInputText)c));
                    }
                }
                return new SPFieldLookupValue();
            }
            set
            {
                EnsureChildControls();
                base.Value = value as SPFieldLookupValue;
            }
        }

        private void Initialize()
        {
            _availableItems = Util.GetAvailableValues(
              ((CascadingLookupField)base.Field), this);
            if (!Util.ListIsNullOrEmpty(_availableItems))
            {
                EnsureValueIsAvailable();
            }
        }

        private void EnsureValueIsAvailable()
        {
            if (_fieldVal != null && !string.IsNullOrEmpty(_fieldVal.LookupValue))
            {
                ListItem s = _availableItems.Find(x => (x.Value.ToLower() == _fieldVal.LookupId.ToString().ToLower()));
                if (s == null)
                {
                    _availableItems.Add(new ListItem(_fieldVal.LookupValue, _fieldVal.LookupId.ToString()));
                }
            }
        }

        private SPFieldLookupValue GetCustomSelectValue(HtmlInputText txtBox)
        {
            Control h = FindControl(string.Format(CultureInfo.InvariantCulture, "{0}_Hidden", Field.InternalName));
            if (h != null && !string.IsNullOrEmpty(((HtmlInputHidden)h).Value))
            {
                ListItem s = _availableItems.Find(x => (x.Value.ToLower() == ((HtmlInputHidden)h).Value.ToLower()));
                if (s != null && (s.Value != "0") && (s.Text.ToLower() == txtBox.Value.ToLower()))
                {
                    return new SPFieldLookupValue(int.Parse(s.Value), s.Text);
                }
            }

            return new SPFieldLookupValue();
        }

        private void SetCustomSelectValue(HtmlInputText txtBox)
        {
            if (_fieldVal != null && (!string.IsNullOrEmpty(_fieldVal.LookupValue)))
            {
                txtBox.Value = _fieldVal.LookupValue;
                Control h = FindControl(string.Format(CultureInfo.InvariantCulture, "{0}_Hidden", Field.InternalName));
                if (h != null) { ((HtmlInputHidden)h).Value = _fieldVal.LookupId.ToString(); }
            }
        }

        private void SetValue()
        {
            Control c = GetRenderingWebControl();

            if (!Util.ListIsNullOrEmpty(_availableItems) && (c != null))
            {
                if (c.GetType().FullName == "System.Web.UI.WebControls.DropDownList")
                {
                    DropDownList ctrl = c as DropDownList;
                    if (_fieldVal != null && (!string.IsNullOrEmpty(_fieldVal.LookupValue)))
                    {
                        ListItem bitem = ctrl.Items.FindByValue(_fieldVal.LookupId.ToString());
                        if (bitem != null)
                        {
                            ctrl.SelectedIndex = ctrl.Items.IndexOf(bitem);
                            base.ItemIds.Add(_fieldVal.LookupId);
                        }
                        else { ctrl.SelectedIndex = 0; }

                    }
                    else { ctrl.SelectedIndex = 0; }
                }
                else { SetCustomSelectValue(((HtmlInputText)c)); }
            }
        }
    }
}