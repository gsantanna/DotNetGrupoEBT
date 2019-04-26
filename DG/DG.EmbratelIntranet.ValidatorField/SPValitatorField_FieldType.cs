using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Security;

namespace DG.Embratelintranet
{
    public class SPValitatorField_FieldType : SPFieldText
    {
        public SPValitatorField_FieldType(SPFieldCollection fields, string fieldName)
            : base(fields, fieldName) { }

        public SPValitatorField_FieldType(SPFieldCollection fields, string typeName, string displayName)
            : base(fields, typeName, displayName) { }

        public override BaseFieldControl FieldRenderingControl
        {
            [SharePointPermission(SecurityAction.LinkDemand, ObjectModel = true)]
            get
            {
                BaseFieldControl fieldControl = new SPValitatorField_FieldControl();
                fieldControl.FieldName = this.InternalName;

                return fieldControl;
            }
        }

        //public override string GetValidatedString(object oValue)
        //{
        //    if (oValue == null)
        //    {
        //        throw new SPFieldValidationException("Este campo é obrigatório.");
        //    }

        //    if (string.IsNullOrEmpty(oValue.ToString()))
        //    {
        //        throw new SPFieldValidationException("Este campo é obrigatório.");
        //    }
        //    else
        //    {
        //        return oValue.ToString();
        //    }

        //}
    }
}
