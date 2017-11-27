﻿using System;

namespace PagoAgilFrba.Core
{
    using System.Data;
    using System.Collections.Generic;

    public class Rendicion
	{
        public static int Rendir(List<int> FacturasIds, int Porcentaje)
        {
            int InsertedId = Insert(Porcentaje);
            Factura.Rendir(FacturasIds, InsertedId);
            return InsertedId;
        }

        public static int Insert(int Porcentaje)
        {
            using (Database Database = new Database())
            {
                Database.IniciarTransaccion();
                int InsertedId = Database.EjecutarEscalar<int>(
                    "INSERT INTO [MIRRORING_GUYS].[Rendicion] (fecha, [porcentaje_comision])"+
                    "output INSERTED.ID " +
                    "VALUES (GETDATE(), @Porcentaje)",
                    Database.CrearParametro("@Porcentaje", Porcentaje));
                Database.ConfirmarTransaccion();
                return InsertedId;
            }
        }

        public static DataTable Listar()
        {
            using (Database database = new Database())
            {
                return database.EjecutarQuery(@"SELECT 
	                                                F.id, 
	                                                F.nro 'Numero', 
	                                                F.id_empresa 'Empresa ID', 
	                                                E.nombre 'Nombre Empresa',
	                                                E.cuit 'Cuit Empresa',
	                                                SUM(I.monto) 'Total'
                                                FROM [MIRRORING_GUYS].[Factura] F, [MIRRORING_GUYS].[Empresa] E, [MIRRORING_GUYS].[ItemFactura] I
                                                WHERE 
	                                                F.id_empresa = E.id AND 
	                                                F.id_pago IS NOT NULL AND 
	                                                F.id_rendicion IS NULL AND
	                                                E.dia_rendicion = DAY(GETDATE()) AND
	                                                I.id_factura = F.id
                                                GROUP BY F.id, F.nro, F.id_empresa, E.nombre, E.cuit
                                                ORDER BY F.id desc");
            }
        }

    }
}
