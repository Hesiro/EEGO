using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Models.Firebase
{
    public class KeyTachitoPadreDetalle : TachitoPadreDetalle
    {
        public string Key { get; set; }
        public KeyTachitoPadreDetalle Copy()
        {
            return new KeyTachitoPadreDetalle()
            {
                Key = this.Key,
                Id = this.Id,
                Area = this.Area,
                NombreArea = this.NombreArea,
                Fecha = this.Fecha,
                FechaNum = this.FechaNum,
                Usuario = this.Usuario,
                Valvulas = this.Valvulas
            };
        }
    }
}
