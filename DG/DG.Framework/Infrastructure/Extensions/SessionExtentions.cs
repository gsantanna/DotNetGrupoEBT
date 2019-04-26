using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace DG
{
    public static class SessionExtentions
    {
            public static void AddWithTimeout(
              this HttpSessionState session,
              string name,
              object value,
              TimeSpan expireAfter)
            {
                session[name] = value;
                session[name + "ExpDate"] = DateTime.Now.Add(expireAfter);
            }

            public static object GetWithTimeout(
              this HttpSessionState session,
              string name)
            {
                object value = session[name];
                if (value == null) return null;

                DateTime? expDate = session[name + "ExpDate"] as DateTime?;
                if (expDate == null) return null;

                if (expDate < DateTime.Now)
                {
                    session.Remove(name);
                    session.Remove(name + "ExpDate");
                    return null;
                }

                return value;
            }
    }
}
