using Microsoft.EntityFrameworkCore;
using ML;

namespace BL
{
    public class Banco
    {
        public static ML.Result Add(ML.Banco Banco)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BancoContext contex = new DL.BancoContext())
                {
                    var query = contex.Database.ExecuteSqlRaw($"[BancoAdd] '{Banco.Nombre}',{Banco.NoEmpleado},{Banco.NoSucursales},{Banco.Pais.IdPais},{Banco.Capital},{Banco.RazonSocial.IdRazonSocial},{Banco.NoClientes}");

                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex )
            {
                result.Exception = ex;
                result.Correct = false;
                result.ErrorMessage= ex.Message;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result resultAll = new ML.Result();

            try
            {
                using (DL.BancoContext context = new DL.BancoContext())
                {
                    var query = context.Bancos.FromSqlRaw("[BancoGetAll]").ToList();

                    if (query != null)
                    {
                        resultAll.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Banco banco = new ML.Banco();

                            banco.IdBanco = obj.IdBanco;
                            banco.Nombre = obj.Nombre;
                            banco.NoEmpleado = obj.NoEmpleados.Value;
                            banco.NoSucursales = obj.NoSucursales.Value;
                            banco.Capital = obj.Capital.Value;  
                            banco.NoClientes = obj.NoClientes.Value;

                            banco.Pais = new ML.Pais();
                            banco.Pais.Nombre = obj.Pais;

                            banco.RazonSocial = new ML.RazonSocial();
                            banco.RazonSocial.Nombre = obj.RazonSocial;

                            resultAll.Objects.Add(banco);
                            
                        }
                        resultAll.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                resultAll.Exception = ex;
                resultAll.ErrorMessage= ex.Message;
                resultAll.Correct = false;
            }
            return resultAll;
        }
        public static ML.Result GetById(int IdBanco)
        {
            ML.Result resultId = new ML.Result();

            try
            {
                using (DL.BancoContext contex = new DL.BancoContext())
                {
                    var query = contex.Bancos.FromSqlRaw($"[BancoGetById] {IdBanco}").AsEnumerable().FirstOrDefault();

                    if (query != null)
                    {
                        ML.Banco banco = new ML.Banco();

                        banco.IdBanco = query.IdBanco;
                        banco.Nombre = query.Nombre;
                        banco.NoEmpleado = query.NoEmpleados.Value;
                        banco.NoSucursales= query.NoSucursales.Value;
                        banco.Capital = query.Capital.Value;
                        banco.NoClientes=query.NoClientes.Value;

                        banco.Pais = new ML.Pais();
                        banco.Pais.Nombre = query.Pais;

                        banco.RazonSocial = new ML.RazonSocial();
                        banco.RazonSocial.Nombre = query.Nombre;

                        resultId.Object = banco;

                        resultId.Correct = true;

                    }
                }

            }
            catch(Exception ex)
            {
                resultId.Exception = ex;
                resultId.ErrorMessage= ex.Message;
                resultId.Correct = false;
            }
            return resultId;
        }

    }
}