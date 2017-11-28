namespace PagoAgilFrba.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Listado
	{

        public static DataTable PorcentajeFacturasCobradasPorEmpresa(int Year, int Month1, int Month2, int Month3)
        {
            using (Database database = new Database())
            {
                return database.EjecutarQuery(@"SELECT TOP 5 E.nombre 'Nombre', ((SELECT COUNT(*) FROM MIRRORING_GUYS.Factura F2 WHERE F2.id_empresa = E.id AND F2.id_pago IS NOT NULL) * 100.0) / (SELECT COUNT(*) FROM MIRRORING_GUYS.Factura F2 WHERE F2.id_empresa = E.id) 'Porcentaje'
                                                FROM MIRRORING_GUYS.Factura F, MIRRORING_GUYS.Empresa E, MIRRORING_GUYS.Pago P
                                                WHERE
	                                                E.id = F.id_empresa AND
	                                                P.id = F.id_pago AND
	                                                YEAR(P.fecha) = @Year AND
	                                                (MONTH(P.fecha) = @Month1 OR MONTH(P.fecha) = @Month2 OR MONTH(P.fecha) = @Month3)
                                                GROUP BY E.nombre, E.id
                                                ORDER BY ((SELECT COUNT(*) FROM MIRRORING_GUYS.Factura F2 WHERE F2.id_empresa = E.id AND F2.id_pago IS NOT NULL) * 100.0) / (SELECT COUNT(*) FROM MIRRORING_GUYS.Factura F2 WHERE F2.id_empresa = E.id) desc",
                                                Database.CrearParametro("@Year", Year),
                                                Database.CrearParametro("@Month1", Month1),
                                                Database.CrearParametro("@Month2", Month2),
                                                Database.CrearParametro("@Month3", Month3));

            }
        }

        public static DataTable EmpresasMayorMontoRendido(int Year, int Month1, int Month2, int Month3)
        {
            using (Database database = new Database())
            {
                return database.EjecutarQuery(@"SELECT TOP 5 E.nombre
                                                FROM MIRRORING_GUYS.Factura F, MIRRORING_GUYS.ItemFactura I, MIRRORING_GUYS.Empresa E
                                                WHERE 
	                                                F.id = I.id_factura AND
	                                                F.id_empresa = E.id AND
	                                                F.id_rendicion IS NOT NULL AND
	                                                YEAR(F.fecha) = @Year AND
	                                                (MONTH(F.fecha) = @Month1 OR MONTH(F.fecha) = @Month2 OR MONTH(F.fecha) = @Month3)
                                                GROUP BY E.nombre
                                                ORDER BY SUM(I.monto) desc",
                                                Database.CrearParametro("@Year", Year),
                                                Database.CrearParametro("@Month1", Month1),
                                                Database.CrearParametro("@Month2", Month2),
                                                Database.CrearParametro("@Month3", Month3));
                
            }
        }

        public static DataTable ClientesConMasPagos(int Year, int Month1, int Month2, int Month3)
        {
            using (Database database = new Database())
            {
                return database.EjecutarQuery(@"SELECT TOP 5 C.nombre 'Nombre', C.apellido 'Apellido'
                                                FROM MIRRORING_GUYS.Factura F, MIRRORING_GUYS.Cliente C, MIRRORING_GUYS.Pago P
                                                WHERE 
	                                                F.id_pago IS NOT NULL AND 
	                                                C.id = F.id_cliente AND
	                                                P.id = F.id_pago AND
	                                                YEAR(P.fecha) = @Year AND
	                                                (MONTH(P.fecha) = @Month1 OR MONTH(P.fecha) = @Month2 OR MONTH(P.fecha) = @Month3)
                                                GROUP BY C.nombre, C.apellido
                                                ORDER BY COUNT(f.id) desc",
                                                Database.CrearParametro("@Year", Year),
                                                Database.CrearParametro("@Month1", Month1),
                                                Database.CrearParametro("@Month2", Month2),
                                                Database.CrearParametro("@Month3", Month3));

            }
        }

        public static DataTable ClientesConMayorPorcentajeDeFacturasPagas(int Year, int Month1, int Month2, int Month3)
        {
            using (Database database = new Database())
            {
                return database.EjecutarQuery(@"SELECT TOP 5 C.nombre 'Nombre', C.apellido 'Apellido'
                                                FROM MIRRORING_GUYS.Factura F, MIRRORING_GUYS.Cliente C, MIRRORING_GUYS.Pago P
                                                WHERE
	                                                C.id = F.id_cliente AND
	                                                P.id = F.id_pago AND
	                                                YEAR(P.fecha) = @Year AND
	                                                (MONTH(P.fecha) = @Month1 OR MONTH(P.fecha) = @Month2 OR MONTH(P.fecha) = @Month3)
                                                GROUP BY C.nombre, C.apellido, C.id
                                                ORDER BY ((SELECT COUNT(*) FROM MIRRORING_GUYS.Factura F2 WHERE F2.id_cliente = C.id AND F2.id_pago IS NOT NULL) * 100.0) / (SELECT COUNT(*) FROM MIRRORING_GUYS.Factura F2 WHERE F2.id_cliente = C.id) desc",
                                                Database.CrearParametro("@Year", Year),
                                                Database.CrearParametro("@Month1", Month1),
                                                Database.CrearParametro("@Month2", Month2),
                                                Database.CrearParametro("@Month3", Month3));

            }
        }

        
    }
}
