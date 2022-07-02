using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Models.Report
{
    public class ResumenAnio
    {
        public string Cultivo { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int TotalVB { get; set; }
        public int TotalVM { get; set; }
        public DateTime? Fecha
        {
            get
            {
                string dateString = Mes.ToString() + "/1/" + Anio.ToString();
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
                DateTimeStyles styles = DateTimeStyles.None;
                DateTime dateResult;
                if (DateTime.TryParse(dateString, culture, styles, out dateResult))
                    return dateResult;
                else
                    return null;                
            }
        }
        public decimal? Cumplimiento
        {
            get
            {
                if (TotalVB + TotalVM > 0)
                {
                    return (decimal)100 * TotalVB / (TotalVM + TotalVB);
                }
                else
                    return null;
            }
        }
    }
}
