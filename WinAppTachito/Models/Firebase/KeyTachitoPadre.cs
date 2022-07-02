using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Models.Firebase
{
    public class KeyTachitoPadre : TachitoPadre
    {
        public string Key { get; set; }
        public KeyTachitoPadre Copy()
        {
            return new KeyTachitoPadre()
            {
                Key = this.Key,
                Id = this.Id,
                Area = this.Area,
                NombreArea = this.NombreArea,
                Fecha = this.Fecha,
                FechaNum = this.FechaNum,
                Usuario = this.Usuario
            };
        }
    }
}
