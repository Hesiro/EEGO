using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Models
{
    public enum TipoUsuario
    {
        Ninguno = 0,
        Usuario = 1,//Acceso a reportes
        Registrador = 2,//Acceso a registro y actualizacion de datos
        Administrador = 3//Acceso a tablas del sistema
    }
}
