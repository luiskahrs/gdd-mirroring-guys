using System;

namespace PagoAgilFrba.Core
{
    using System.Data;
    using System.Collections.Generic;

    public class Pago
	{


        public static int Pagar(List<Factura> Facturas, Sucursal Sus, int IdFormaPago)
        {
            using (Database Database = new Database())
            {
                Database.IniciarTransaccion();
                int InsertedId = Database.EjecutarEscalar<int>(
                    "INSERT INTO [MIRRORING_GUYS].[Pago] ([fecha],[id_forma_pago],[id_sucursal],[id_cliente])" +
                    "output INSERTED.ID " +
                    "VALUES (GETDATE(),@ForPago,@Sucu,@Cli)",
                    Database.CrearParametro("@ForPago", IdFormaPago),
                    Database.CrearParametro("@Sucu", Sus.Id),
                    Database.CrearParametro("@Cli", Facturas[0].IdCliente));

                foreach (Factura f in Facturas)
                {
                    f.IdPago = InsertedId;
                    f.Pagar();

                    int IdHisto = Database.EjecutarEscalar<int>(
                        "INSERT INTO [MIRRORING_GUYS].[HistoricoPago] ([id_factura],[id_pago]) " +
                        "output INSERTED.ID " +
                        "VALUES (@IdFac,@IdPag)",
                        Database.CrearParametro("@IdFac", f.Id.GetValueOrDefault()),
                        Database.CrearParametro("@IdPag", InsertedId));
                }


                Database.ConfirmarTransaccion();
                return InsertedId;
            }
        }



        public static List<Tuple<int, string>> FormaDePago()
        {
            using (Database dl = new Database())
            {
                DataTable DataTable = dl.EjecutarQuery(@"SELECT id, descripcion FROM [MIRRORING_GUYS].[FormaPago]");

                List<Tuple<int, string>> descs = new List<Tuple<int, string>>();
                foreach (DataRow dr in DataTable.Rows)
                {
                    int id = dr.Field<int>("id");
                    String desc = dr.Field<string>("descripcion");

                    descs.Add(new Tuple<int, string>(id, desc));
                }
                return descs;
            }
        }

        





    }
}
