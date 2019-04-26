using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace DG.Framework.Strategy
{
    public interface IExecutable
    {
        void Execute(Page page, SPContext context);
    }
}
