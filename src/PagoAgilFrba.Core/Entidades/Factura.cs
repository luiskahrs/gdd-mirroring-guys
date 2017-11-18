using System;

namespace PagoAgilFrba.Core
{
    using System.Data;

    public class Factura : EntidadBase
	{
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdCliente { get; set; }
        public string DniCliente { get; set; }
        public int IdEmpresa { get; set; }
        public string CuitEmpresa { get; set; }
        public int IdPago { get; set; }
        public int IdRendicion { get; set; }

        public Factura()
        {
        }

        public Factura(int id, string Numero, DateTime Fecha, DateTime FechaVenc, int cliente, string DNI, int empresa, string CuitEm, int pago, int rendi)
        {
            this.Id = id;
            this.Numero = Numero;
            this.Fecha = Fecha;
            this.FechaVencimiento = FechaVenc;
            this.IdCliente = cliente;
            this.IdEmpresa = empresa;
            this.IdPago = pago;
            this.IdRendicion = rendi;
            this.DniCliente = DNI;
            this.CuitEmpresa = CuitEm;
        }

        public static DataTable ListarParaAbm()
        {
            using (Database database = new Database())
            {
                return database.EjecutarQuery(@"SELECT TOP 10
	                                                F.id, 
	                                                F.nro 'Numero', 
	                                                F.fecha, 
	                                                F.fecha_vencimiento 'Vencimiento',
	                                                F.id_cliente 'Cliente ID',
	                                                C.nombre 'Nombre Cliente',
	                                                C.apellido 'Apellido Cliente',
	                                                C.dni 'Cliente DNI', 
	                                                F.id_empresa 'Empresa ID', 
	                                                E.nombre 'Nombre Empresa',
	                                                E.cuit 'Cuit Empresa',
                                                    F.id_pago 'Pago ID',
                                                    F.id_rendicion 'Rendicion ID',
	                                                CASE WHEN id_pago IS NOT NULL THEN 'Paga' ELSE 'Impaga' END 'Esta paga',
	                                                CASE WHEN id_rendicion IS NOT NULL THEN 'Rendida' ELSE 'No rendida' END 'Esta rendiad'
                                                FROM [MIRRORING_GUYS].[Factura] F, [MIRRORING_GUYS].[Cliente] C, [MIRRORING_GUYS].[Empresa] E
                                                WHERE F.id_cliente = C.id AND F.id_empresa = E.id
                                                ORDER BY F.nro");
            }
        }

        public static DataTable Buscar(int? idCliente, int? idEmpresa, string numero)
        {
            using (Database database = new Database())
            {
                return database.EjecutarQuery(@"SELECT 
	                                                F.id, 
	                                                F.nro 'Numero', 
	                                                F.fecha, 
	                                                F.fecha_vencimiento 'Vencimiento',
	                                                F.id_cliente 'Cliente ID',
	                                                C.nombre 'Nombre Cliente',
	                                                C.apellido 'Apellido Cliente',
	                                                C.dni 'Nombre DNI', 
	                                                F.id_empresa 'Empresa ID', 
	                                                E.nombre 'Nombre Empresa',
	                                                E.cuit 'Cuit Empresa',
	                                                CASE WHEN id_pago IS NOT NULL THEN 'Paga' ELSE 'Impaga' END 'Esta paga',
	                                                CASE WHEN id_rendicion IS NOT NULL THEN 'Rendida' ELSE 'No rendida' END 'Esta rendiad'
                                                FROM [MIRRORING_GUYS].[Factura] F, [MIRRORING_GUYS].[Cliente] C, [MIRRORING_GUYS].[Empresa] E
                                                WHERE 
	                                                F.id_cliente = C.id AND 
	                                                F.id_empresa = E.id AND
	                                                (@Numero = -1 OR F.nro = @Numero) AND
	                                                (@Cliente = -1 OR F.id_cliente = @Cliente) AND
	                                                (@Empresa = -1 OR F.id_empresa = @Empresa)
                                                ORDER BY F.nro",
                                                Database.CrearParametro("@Numero", (numero==null || numero=="") ? -1 : int.Parse(numero)),
                                                Database.CrearParametro("@Cliente", idCliente.GetValueOrDefault(-1)),
                                                Database.CrearParametro("@Empresa", idEmpresa.GetValueOrDefault(-1)));
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
