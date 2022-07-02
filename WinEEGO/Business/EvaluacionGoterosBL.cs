using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Database;
using WinEEGO.Models;

namespace WinEEGO.Business
{
    public class EvaluacionGoterosBL
    {
        private static EvaluacionGoterosBL instancia = null;
        private static object padlock = new object();
        public static EvaluacionGoterosBL Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new EvaluacionGoterosBL();
                    }
                }
                return instancia;
            }
        }
        public List<EvaluacionGoteros> List(DateTime Desde, DateTime Hasta, Usuario user)
        {
            return EvaluacionGoterosDA.Instancia.List(Desde, Hasta, user);
        }
        public int Insert(EvaluacionGoteros Obj)
        {
            return EvaluacionGoterosDA.Instancia.Insert(Obj);
        }
        public bool Update(EvaluacionGoteros Obj)
        {
            return EvaluacionGoterosDA.Instancia.Update(Obj);
        }
        public bool UpdateStatus(EvaluacionGoteros Obj)
        {
            return EvaluacionGoterosDA.Instancia.UpdateStatus(Obj);
        }
        public bool UpdateResult(EvaluacionGoteros objParent, List<DetalleEvaluacionGoteros> objDetail)
        {
            List<NodoEvaluacion> listNodo = new List<NodoEvaluacion>();
            decimal haAfectada = 0;
            decimal haRegular = 0;
            decimal haBueno = 0;
            int nroAfectado = 0;
            int nroRegular = 0;
            int nroBueno = 0;

            foreach (var item in objDetail)
            {
                if (item.CoeficienteUniformidad.HasValue)
                {
                    if (item.CoeficienteUniformidad > 90)
                    {
                        if (item.Hectarea.HasValue)
                        {
                            haBueno += (decimal)item.Hectarea;
                            nroBueno++;
                        }
                    }
                    else
                    {
                        if (item.CoeficienteUniformidad > 70)
                        {
                            if (item.Hectarea.HasValue)
                            {
                                haRegular += (decimal)item.Hectarea;
                                nroRegular++;
                            }
                        }
                        else
                        {
                            if (item.Hectarea.HasValue)
                            {
                                haAfectada += (decimal)item.Hectarea;
                                nroAfectado++;
                            }
                        }
                    }
                }

                if (item.Muestra01.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra01 });

                if (item.Muestra02.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra02 });

                if (item.Muestra03.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra03 });

                if (item.Muestra04.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra04 });

                if (item.Muestra05.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra05 });

                if (item.Muestra06.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra06 });

                if (item.Muestra07.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra07 });

                if (item.Muestra08.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra08 });

                if (item.Muestra09.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra09 });

                if (item.Muestra10.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra10 });

                if (item.Muestra11.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra11 });

                if (item.Muestra12.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra12 });

                if (item.Muestra13.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra13 });

                if (item.Muestra14.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra14 });

                if (item.Muestra15.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra15 });

                if (item.Muestra16.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra16 });

                if (item.Muestra17.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra17 });

                if (item.Muestra18.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra18 });

                if (item.Muestra19.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra19 });

                if (item.Muestra20.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra20 });

                if (item.Muestra21.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra21 });

                if (item.Muestra22.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra22 });

                if (item.Muestra23.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra23 });

                if (item.Muestra24.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra24 });

                if (item.Muestra25.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra25 });

                if (item.Muestra26.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra26 });

                if (item.Muestra27.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra27 });

                if (item.Muestra28.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra28 });

                if (item.Muestra29.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra29 });

                if (item.Muestra30.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra30 });

                if (item.Muestra31.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra31 });

                if (item.Muestra32.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra32 });

                if (item.Muestra33.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra33 });

                if (item.Muestra34.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra34 });

                if (item.Muestra35.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra35 });

                if (item.Muestra36.HasValue)
                    listNodo.Add(new NodoEvaluacion() { Valvula = item.Valvula, Muestra = item.Muestra36 });
            }

            if (listNodo.Count > 0)
            {
                decimal promMuestras = Promedio(listNodo);
                decimal promMuestras25 = Promedio25(listNodo.OrderBy(o => o.Muestra).ToList());
                decimal desv = DesviacionEstandar(listNodo);

                decimal Cu = 100 * promMuestras25 / promMuestras;
                decimal Cd = 100 * (promMuestras - objParent.Emision) / objParent.Emision;
                decimal Cv = 100 * desv / promMuestras;

                EvaluacionGoteros obj = new EvaluacionGoteros();
                obj.Id = objParent.Id;
                obj.CoeficienteUniformidad = Cu;
                obj.CoeficienteDesviacion = Cd;
                obj.CoeficienteVariacion = Cv;
                obj.Status = objParent.Status;

                obj.CaudalMedio = promMuestras;
                obj.CaudalMedio25 = promMuestras25;
                obj.DesviacionS = desv;

                int GoterosDebajoPermisible = 0;
                int GoterosPermisible = 0;
                int GoterosSobePermisible = 0;


                if (objParent.EmisionSobrePermisible.HasValue && objParent.EmisionPermisible.HasValue)
                {
                    foreach (var item in listNodo)
                    {
                        if (item.Muestra > objParent.EmisionSobrePermisible)
                            GoterosSobePermisible++;
                        else
                            if (item.Muestra > objParent.EmisionPermisible)
                            GoterosPermisible++;
                        else
                            GoterosDebajoPermisible++;
                    }
                }

                /*Ha afectada*/
                if (haAfectada > 0)
                {
                    obj.AreaAfectada = haAfectada;
                    obj.NroAfectado = nroAfectado;
                }
                else
                {
                    obj.AreaAfectada = null;
                    obj.NroAfectado = null;
                }

                if (haRegular > 0)
                {
                    obj.AreaRegular = haRegular;
                    obj.NroRegular = nroRegular;
                }
                else
                {
                    obj.AreaRegular = null;
                    obj.NroRegular = null;
                }

                if (haBueno > 0)
                {
                    obj.AreaBueno = haBueno;
                    obj.NroBueno = nroBueno;
                }
                else
                {
                    obj.AreaBueno = null;
                    obj.NroBueno = null;
                }
                ///

                obj.GoterosDebajoPermisible = GoterosDebajoPermisible;
                obj.GoterosPermisible = GoterosPermisible;
                obj.GoterosSobrePermisible = GoterosSobePermisible;

                return EvaluacionGoterosDA.Instancia.UpdateResult(obj);
            }
            else
            {
                EvaluacionGoteros obj = new EvaluacionGoteros
                {
                    Id = objParent.Id,
                    Status = objParent.Status
                };

                return EvaluacionGoterosDA.Instancia.UpdateResult(obj);
            }
        }
        public bool Delete(EvaluacionGoteros obj)
        {
            return EvaluacionGoterosDA.Instancia.Delete(obj);
        }
        public EvaluacionGoteros FindByID(EvaluacionGoteros obj)
        {
            return EvaluacionGoterosDA.Instancia.FindByID(obj);
        }
        public List<EvaluacionGoteros> List(int Anio, string Area)
        {
            return EvaluacionGoterosDA.Instancia.List(Anio, Area);
        }
        public List<EvaluacionGoteros> List(int Anio, string Area, string Valvula)
        {
            return EvaluacionGoterosDA.Instancia.List(Anio, Area, Valvula);
        }        
        public List<DetalleEvaluacionGoteros> ListDetail(EvaluacionGoteros obj)
        {
            return EvaluacionGoterosDA.Instancia.ListDetail(obj);
        }
        public bool InsertDetail(EvaluacionGoteros obj)
        {
            List<ValvulaCampo> valvula;
            valvula = ValvulaCampoBL.Instancia.List(new AreaGeneral() { Codigo = obj.Area });

            List<DetalleEvaluacionGoteros> detalle = new List<DetalleEvaluacionGoteros>();

            foreach (var item in valvula)
            {
                if (item.Estado)
                {
                    DetalleEvaluacionGoteros row = new DetalleEvaluacionGoteros();
                    row.IdParent = obj.Id;
                    row.Valvula = item.Nombre;
                    row.Hectarea = item.Hectarea;
                    detalle.Add(row);
                }
            }

            return EvaluacionGoterosDA.Instancia.InsertDetail(detalle);
        }
        public bool UpdateDetail(List<DetalleEvaluacionGoteros> obj)
        {
            return EvaluacionGoterosDA.Instancia.UpdateDetail(obj);
        }              
        public List<EvaluacionGoteros> ListPendientes(DateTime Desde, DateTime Hasta, string Cultivo)
        {
            return EvaluacionGoterosDA.Instancia.ListPendientes(Desde, Hasta, Cultivo);
        }
        public List<EvaluacionGoteros> ListParaActuar(DateTime Desde, DateTime Hasta, String Cultivo, Int16 nupCU, Int16 nupCv, Int16 nupCd)
        {
            return EvaluacionGoterosDA.Instancia.ListParaActuar(Desde, Hasta, Cultivo, nupCU, nupCv, nupCd);
        }
        decimal Promedio(List<NodoEvaluacion> obj)
        {
            int total = obj.Count;
            decimal sum = 0;
            foreach (var item in obj)
            {
                sum += (decimal)item.Muestra;
            }

            return sum / total;
        }
        decimal Promedio25(List<NodoEvaluacion> obj)
        {
            int total = obj.Count / 4;
            decimal sum = 0;

            for (int i = 0; i < total; i++)
            {
                NodoEvaluacion item = obj[i];
                sum += (decimal)item.Muestra;
            }
            if (total > 0)
            {
                return sum / total;
            }
            else
            {
                return 0;
            }
        }
        decimal DesviacionEstandar(List<NodoEvaluacion> obj)
        {
            double desvStd;
            double N, prom, suma = 0, NrestadoUno, sumapotencias = 0;
            N = obj.Count;
            NrestadoUno = N - 1;
            foreach (var dato in obj)
            {
                suma += (double)dato.Muestra;
            }
            prom = suma / N;
            foreach (var dato in obj)
            {
                sumapotencias += Math.Pow(((double)dato.Muestra - prom), 2);
            }
            desvStd = Math.Sqrt((1 * sumapotencias) / NrestadoUno);

            return (decimal)desvStd;
        }
    }
}
