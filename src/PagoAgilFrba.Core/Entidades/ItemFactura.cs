using System;

namespace PagoAgilFrba.Core
{
    using System.Data;

    public class ItemFactura : EntidadBase
	{
        public int Monto { get; set; }
        public int Cantidad { get; set; }
        public int IdFactura { get; set; }

        public ItemFactura()
        {
        }

        public ItemFactura(int id)
        {
            this.Id = id;
        }

        public ItemFactura(int Monto, int Cantidad)
        {
            this.Monto = Monto;
            this.Cantidad = Cantidad;
        }

        public ItemFactura(int id, int Monto, int Cantidad, int Fac)
        {
            this.Id = id;
            this.Monto = Monto;
            this.Cantidad = Cantidad;
            this.IdFactura = Fac;
        }

        public static DataTable ListarPorIdFac(int idFac)
        {
            using (Database database = new Database())
            {
                return database.EjecutarQuery(@"SELECT F.id 'ID', F.monto 'Monto', F.cantidad 'Cantidad', F.id_factura 'Factura ID'
                                                FROM [MIRRORING_GUYS].[ItemFactura] F
                                                WHERE F.id_factura = @Id",
                                                Database.CrearParametro("@Id", idFac));
            }
        }

        public override void Guardar()
        {
            using (Database Database = new Database())
            {
                if (this.Id == null)
                {
                    this.Id = this.Insert();
                }
                else
                {
                   Database.IniciarTransaccion();
                   throw new NotImplementedException("implementar");
                   Database.ConfirmarTransaccion();
                }
                
            }
        }

        public void Borrar()
        {
            using (Database Database = new Database())
            {
                Database.IniciarTransaccion();
                this.Id = Database.EjecutarEscalar<int>(
                    "DELETE FROM [MIRRORING_GUYS].[ItemFactura] I WHERE I.id = @Id output DELETED.ID ",
                    Database.CrearParametro("@Id", this.Id));
                Database.ConfirmarTransaccion();
            }
        }

        public int Insert()
        {
            using (Database Database = new Database())
            {
                Database.IniciarTransaccion();
                int InsertedId = Database.EjecutarEscalar<int>(
                    "INSERT INTO MIRRORING_GUYS.ItemFactura (monto, cantidad, [id_factura])" +
                    "output INSERTED.ID " +
                    "VALUES (@Monto, @Cantidad, @IFactura)",
                    Database.CrearParametro("@Monto", this.Monto),
                    Database.CrearParametro("@Cantidad", this.Cantidad),
                    Database.CrearParametro("@IFactura", this.IdFactura));
                Database.ConfirmarTransaccion();
                return InsertedId;
            }
        }

        public void Update()
        {
            using (Database Database = new Database())
            {
                throw new NotImplementedException("implementar");
            }
        }


    }
}
