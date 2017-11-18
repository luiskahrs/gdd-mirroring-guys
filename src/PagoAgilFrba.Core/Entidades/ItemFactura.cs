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
                return database.EjecutarQuery(@"SELECT F.id, F.monto, F.cantidad, F.id_factura
                                                FROM [MIRRORING_GUYS].[ItemFactura] F
                                                WHERE F.id_factura = @Id",
                                                Database.CrearParametro("@Id", idFac));
            }
        }

        public override void Guardar()
        {
        }

        public int Insert()
        {
            using (Database Database = new Database())
            {
                throw new NotImplementedException("implementar");
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
