using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG
{
    public class InternalNameAttribute : Attribute
    {
        public string InternalName{get; private set;}

        public InternalNameAttribute(string InternalName)
        {
            this.InternalName = InternalName;
        }
    }
}
