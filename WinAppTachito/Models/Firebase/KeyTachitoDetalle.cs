using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Models.Firebase
{
    public class KeyTachitoDetalle : TachitoDetalle
    {
        public string Key { get; set; }
        public KeyTachitoDetalle Copy()
        {
            return new KeyTachitoDetalle()
            {
                Key = this.Key,
                Id = this.Id,
                IdPadre = this.IdPadre,
                Valvula = this.Valvula,
                Orden = this.Orden,
                Medida1 = this.Medida1,
                Medida2 = this.Medida2,
                Comentario = this.Comentario
            };
        }
    }
}
