namespace PagoAgilFrba.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Rubro : EntidadBase
	{
        public static DataTable Listar()
        {
            using (Database database = new Database())
            {
                return database.EjecutarQuery(@"SELECT 
	                                                *
                                                FROM [MIRRORING_GUYS].[Rubro] R
                                                Order by R.id");
            }
        }

        public static List<Tuple<int, string>> ListarDescripciones() 
        {
            List<Tuple<int, string>> descs = new List<Tuple<int, string>>();
            foreach (DataRow dr in Rubro.Listar().Rows)
            {
                String desc = dr.Field<string>("descripcion");
                int id = dr.Field<int>("id");
                descs.Add(new Tuple<int, string>(id, desc));
            }
            return descs;
        }
    }
}
