﻿using System;

namespace PagoAgilFrba.Core
{
    using System.Data;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Configuration;

    public class Factura : EntidadBase
	{
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int IdCliente { get; set; }
        public string DniCliente { get; set; }
        public int IdEmpresa { get; set; }
        public string CuitEmpresa { get; set; }
        public int? IdPago { get; set; }
        public int? IdRendicion { get; set; }
        public List<ItemFactura> Items { get; set; }
        public List<ItemFactura> AddedItems { get; set; }
        public List<ItemFactura> DeletedItems { get; set; }
        public decimal Importe { get; set; }

        public Factura()
        {
            Items = new List<ItemFactura>();
            this.DeletedItems = new List<ItemFactura>();
            this.AddedItems = new List<ItemFactura>();
            Fecha = DateTime.Parse(ConfigurationManager.AppSettings.Get("SystemDate"), new CultureInfo("es-ES", true));
        }

        public Factura(
            int id, 
            string Numero, 
            DateTime Fecha, 
            DateTime FechaVenc, 
            int cliente, 
            string DNI, 
            int empresa, 
            string CuitEm, 
            int? pago, 
            int? rendi)
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
            this.Items = Items;
            this.DeletedItems = new List<ItemFactura>();
            this.AddedItems = new List<ItemFactura>();
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
                                                ORDER BY F.id desc");
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
	                                                C.dni 'Cliente DNI', 
	                                                F.id_empresa 'Empresa ID', 
	                                                E.nombre 'Nombre Empresa',
	                                                E.cuit 'Cuit Empresa',
                                                    F.id_pago 'Pago ID',
                                                    F.id_rendicion 'Rendicion ID',
	                                                CASE WHEN id_pago IS NOT NULL THEN 'Paga' ELSE 'Impaga' END 'Esta paga',
	                                                CASE WHEN id_rendicion IS NOT NULL THEN 'Rendida' ELSE 'No rendida' END 'Esta rendiad',
                                                    (SELECT SUM(I.monto) FROM MIRRORING_GUYS.ItemFactura I WHERE I.id_factura = F.id) 'Importe'
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

        public static DataTable getRendidas(string numero)
        {
            using (Database database = new Database())
            {
                if (numero == "ALL")
                {
                    return database.EjecutarQuery(@"SELECT
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
                                                    WHERE 
	                                                    F.id_cliente = C.id AND 
	                                                    F.id_empresa = E.id AND
	                                                    F.id_rendicion IS NOT NULL
                                                    ORDER BY F.nro");
                }
                else
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
                                                    WHERE 
	                                                    F.id_cliente = C.id AND 
	                                                    F.id_empresa = E.id AND
	                                                    (@Numero = -1 OR F.nro = @Numero) AND
	                                                    F.id_rendicion IS NOT NULL
                                                    ORDER BY F.nro",
                                                    Database.CrearParametro("@Numero", (numero == null || numero == "") ? -1 : int.Parse(numero)));
                }
            }
        }

        public static DataTable getPagasNoRendidas(string numero)
        {
            using (Database database = new Database())
            {
                if (numero == "ALL")
                {
                    return database.EjecutarQuery(@"SELECT
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
                                                    WHERE 
	                                                    F.id_cliente = C.id AND 
	                                                    F.id_empresa = E.id AND
	                                                    F.id_rendicion IS NULL AND
                                                        F.id_pago IS NOT NULL
                                                    ORDER BY F.nro");
                }
                else
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
                                                    WHERE 
	                                                    F.id_cliente = C.id AND 
	                                                    F.id_empresa = E.id AND
	                                                    (@Numero = -1 OR F.nro = @Numero) AND
	                                                    F.id_rendicion IS NULL AND
                                                        F.id_pago IS NOT NULL
                                                    ORDER BY F.nro",
                                                    Database.CrearParametro("@Numero", (numero == null || numero == "") ? -1 : int.Parse(numero)));
                }
            }
        }


        public override void Guardar()
        {
            if (this.Id == null)
            {
                this.Id = this.Insert();

                foreach (ItemFactura i in this.Items)
                {
                    i.IdFactura = this.Id.GetValueOrDefault();
                    i.Insert();
                }
            }
            else
            {
                using (Database Database = new Database())
                {
                    Database.IniciarTransaccion();
                    foreach (ItemFactura i in DeletedItems)
                    {
                        i.Borrar();
                    }
                    foreach (ItemFactura i in AddedItems)
                    {
                        i.Insert();
                    }
                    
                    Database.EjecutarNonQuery(
                        "UPDATE [MIRRORING_GUYS].[Factura]"+
                        "SET [nro] = @Nro,"+
                              "[fecha_vencimiento] = @FechaVen,"+
                              "[id_cliente] = @IdCli,"+
                              "[id_empresa] = @IdEmp"+
                        " WHERE id = @FId",
                        CommandType.Text,
                        Database.CrearParametro("@Nro", int.Parse(this.Numero)),
                        Database.CrearParametro("@FechaVen", this.FechaVencimiento.Value.ToString("yyyy-MM-dd")),
                        Database.CrearParametro("@IdCli", this.IdCliente),
                        Database.CrearParametro("@IdEmp", this.IdEmpresa),
                        Database.CrearParametro("@FId", this.Id));

                    Database.ConfirmarTransaccion();    
                }
            }
        }

        public int Insert()
        {
            using (Database Database = new Database())
            {
                Database.IniciarTransaccion();
                int InsertedId = Database.EjecutarEscalar<int>(
                    "INSERT INTO [MIRRORING_GUYS].[Factura] ([nro],[fecha],[fecha_vencimiento],[id_cliente],[id_empresa])" +
                    "output INSERTED.ID " +
                    "VALUES (@Nro, @Fecha, @FechaVen, @IdCli, @IdEmp)",
                    Database.CrearParametro("@Nro", int.Parse(this.Numero)),
                    Database.CrearParametro("@Fecha", this.Fecha.ToString("yyyy-MM-dd")),
                    Database.CrearParametro("@FechaVen", this.FechaVencimiento.Value.ToString("yyyy-MM-dd")),
                    Database.CrearParametro("@IdCli", this.IdCliente),
                    Database.CrearParametro("@IdEmp", this.IdEmpresa));
                Database.ConfirmarTransaccion();
                return InsertedId;
            }
        }

        public static void Rendir(List<int> Ids, int RedencionId)
        {
            using (Database Database = new Database())
            {
                foreach (int id in Ids)
                {
                    Database.EjecutarNonQuery(
                            "UPDATE [MIRRORING_GUYS].[Factura]" +
                            "SET [id_rendicion] = @IdRen" +
                            " WHERE id = @FId",
                            CommandType.Text,
                            Database.CrearParametro("@IdRen", RedencionId),
                            Database.CrearParametro("@FId", id));
                }
            }
        }

        public static void DesRendir(int Id)
        {
            using (Database Database = new Database())
            {
                
                Database.EjecutarNonQuery(
                        "UPDATE [MIRRORING_GUYS].[Factura]" +
                        "SET [id_rendicion] = NULL" +
                        " WHERE id = @FId",
                        CommandType.Text,
                        Database.CrearParametro("@FId", Id));
                
            }
        }

        public static void BorrarPago(int Id)
        {
            using (Database Database = new Database())
            {

                Database.EjecutarNonQuery(
                        "UPDATE [MIRRORING_GUYS].[Factura]" +
                        "SET [id_pago] = NULL" +
                        " WHERE id = @FId",
                        CommandType.Text,
                        Database.CrearParametro("@FId", Id));

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
