using System;

namespace PagoAgilFrba.Core
{
    using System.Data;

    public class ItemFactura : EntidadBase
	{
        public decimal Monto { get; set; }
        public decimal Cantidad { get; set; }
        public int IdFactura { get; set; }

        public ItemFactura()
        {
        }

        public ItemFactura(int id)
        {
            this.Id = id;
        }

        public ItemFactura(int Monto, int Cantidad, int Fac)
        {
            this.Monto = Monto;
            this.Cantidad = Cantidad;
            this.IdFactura = Fac;
        }

        public ItemFactura(int id, decimal Monto, decimal Cantidad, int Fac)
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
                return database.EjecutarQuery(@"SELECT F.id 'ID', F.cantidad 'Cantidad', F.monto 'Monto', F.id_factura 'Factura ID'
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
                    this.Insert();
                }
            }
            throw new NotImplementedException("implementar");
        }

        public void Borrar()
        {
            using (Database Database = new Database())
            {
                Database.IniciarTransaccion();
                Database.EjecutarNonQuery(
                    "DELETE FROM [MIRRORING_GUYS].ItemFactura WHERE id = @Id", 
                    CommandType.Text, 
                    Database.CrearParametro("@Id", this.Id));
                Database.ConfirmarTransaccion();
            }
        }

        public void Insert()
        {
            using (Database Database = new Database())
            {
                Database.IniciarTransaccion();
                this.Id = Database.EjecutarEscalar<int>(
                    "INSERT INTO MIRRORING_GUYS.ItemFactura (monto, cantidad, [id_factura])" +
                    "output INSERTED.ID " +
                    "VALUES (@Monto, @Cantidad, @IFactura)",
                    Database.CrearParametro("@Monto", this.Monto),
                    Database.CrearParametro("@Cantidad", this.Cantidad),
                    Database.CrearParametro("@IFactura", this.IdFactura));
                Database.ConfirmarTransaccion();
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
