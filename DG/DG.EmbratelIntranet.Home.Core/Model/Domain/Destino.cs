using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG.EmbratelIntranet.Home.Core.Domain
{
    public enum Destino
    {
        [Description("Mesma Janela")]
        _self,
        [Description("Nova Janela")]
        _blank,
        [Description("Fancybox")]
        Fancybox,

        Invalido
    }


    public static class DestinoEnum
    {
        public static Destino GetEnum(string destinoValue)
        {
            switch (destinoValue)
            {
                case "Mesma Janela":
                    return Destino._self;
                case "Nova Janela":
                    return Destino._blank;
                case "Fancybox":
                    return Destino.Fancybox;
            }
            return Destino.Invalido;
        }

        public static string GetValue(this Destino destino)
        {
            switch (destino)
            {
                case Destino._self:
                    return "_self";
                case Destino._blank:
                    return "_blank";
                case Destino.Fancybox:
                    return "Fancybox";
            }

            return string.Empty;
        }

    }

}
