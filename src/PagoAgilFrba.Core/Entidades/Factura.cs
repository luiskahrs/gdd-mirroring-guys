using System;

namespace PagoAgilFrba.Core
{
    using System.Data;

    public class Factura : EntidadBase
	{
        public string Calle { get; set; }
        public string Codigo_Postal { get; set; }

        public Factura()
        {
        }

        public Factura(string Calle, string Codigo_Postal)
        {
            this.Calle = Calle;
            this.Codigo_Postal = Codigo_Postal;
        }

        public static DataTable Listar(string nombre, string apellido, decimal dni)
        {
            return new DataTable();
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

        public static Boolean EmpresaTieneFacturasPagasNoRendidas(int EmpresaId)
        {
            using (Database database = new Database())
            {
                DataTable DataTable = database.EjecutarQuery(@"SELECT F.id
                                                FROM [MIRRORING_GUYS].[Factura] F
                                                WHERE F.id_rendicion is null AND F.id_pago is not null AND F.id_empresa = @Id",
                                                Database.CrearParametro("@Id", EmpresaId));
                return DataTable.Rows.Count > 0;
            }
        }
    }
}
