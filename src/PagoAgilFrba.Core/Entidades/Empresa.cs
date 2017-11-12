namespace PagoAgilFrba.Core
{
    using System.Collections.Generic;
    using System.Data;

    public class Empresa : EntidadBase
	{
        public string Nombre { get; set; }
        public string Cuit { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string IdRubro { get; set; }
        public string Rubro { get; set; }
        public bool IsActiva { get; set; }
        public string DiaRedencion { get; set; }

        public Empresa() { }

        public Empresa(
            int id,
            string Nombre, 
            string Cuit, 
            string Direccion, 
            string CodigoPostal,
            string Rubro, 
            string IdRubro, 
            bool IsActiva,
            string DiaRedencion)
        {
            this.Id = id;
            this.Nombre = Nombre;
            this.Cuit = Cuit;
            this.Direccion = Direccion;
            this.CodigoPostal = CodigoPostal;
            this.Rubro = Rubro;
            this.IdRubro = IdRubro;
            this.IsActiva = IsActiva;
            this.DiaRedencion = DiaRedencion;
        }

        public static DataTable Listar(string Nombre, string Cuit, int IdRubro)
        {
            using (Database database = new Database())
            {
                if (IdRubro == -1)
                {
                    return database.EjecutarQuery(@"SELECT 
                                                        E.id,
	                                                    E.cuit 'CUIT',
	                                                    E.nombre 'Nombre',
	                                                    CASE WHEN E.esta_activa = 1 THEN 'si' ELSE 'no' END 'Esta activa',
	                                                    E.dia_rendicion 'Dia de rendencion',
	                                                    D.direccion 'Direccion',
                                                        D.codigo_postal 'Codigo Postal',
	                                                    R.descripcion 'Rubro',
                                                        R.id 'Rubro ID'
                                                    FROM [MIRRORING_GUYS].[Empresa] E, [MIRRORING_GUYS].[Direccion] D, [MIRRORING_GUYS].[Rubro] R
                                                    WHERE 
                                                        E.id_direccion = D.id AND 
                                                        E.id_rubro = R.id AND 
                                                        E.cuit LIKE @Cuit AND 
                                                        E.nombre LIKE @Nombre
                                                    Order by E.id",
                                                    Database.CrearParametro("@Nombre", string.Format("%{0}%", Nombre)),
                                                    Database.CrearParametro("@Cuit", string.Format("%{0}%", Cuit)));
                }
                else
                {
                    return database.EjecutarQuery(@"SELECT 
                                                        E.id,
	                                                    E.cuit 'CUIT',
	                                                    E.nombre 'Nombre',
	                                                    CASE WHEN E.esta_activa = 1 THEN 'si' ELSE 'no' END 'Esta activa',
	                                                    E.dia_rendicion 'Dia de rendencion',
	                                                    D.direccion 'Direccion',
                                                        D.codigo_postal 'Codigo Postal',
	                                                    R.descripcion 'Rubro',
                                                        R.id 'Rubro ID'
                                                    FROM [MIRRORING_GUYS].[Empresa] E, [MIRRORING_GUYS].[Direccion] D, [MIRRORING_GUYS].[Rubro] R
                                                    WHERE 
                                                        E.id_direccion = D.id AND 
                                                        E.id_rubro = R.id AND 
                                                        E.cuit LIKE @Cuit AND 
                                                        E.nombre LIKE @Nombre AND 
                                                        E.id_rubro = @IdRubro
                                                    Order by E.id",
                                                    Database.CrearParametro("@Nombre", string.Format("%{0}%", Nombre)),
                                                    Database.CrearParametro("@Cuit", string.Format("%{0}%", Cuit)),
                                                    Database.CrearParametro("@IdRubro", IdRubro));
                }
            }
        }

        public static DataTable Listar()
        {
            using (Database database = new Database())
            {
                return database.EjecutarQuery(@"SELECT 
                                                    E.id,
	                                                E.cuit 'CUIT',
	                                                E.nombre 'Nombre',
	                                                CASE WHEN E.esta_activa = 1 THEN 'si' ELSE 'no' END 'Esta activa',
	                                                E.dia_rendicion 'Dia de rendencion',
	                                                D.direccion 'Direccion',
                                                    D.codigo_postal 'Codigo Postal',
	                                                R.descripcion 'Rubro',
                                                    R.id 'Rubro ID'
                                                FROM [MIRRORING_GUYS].[Empresa] E, [MIRRORING_GUYS].[Direccion] D, [MIRRORING_GUYS].[Rubro] R
                                                WHERE E.id_direccion = D.id AND E.id_rubro = R.id
                                                Order by E.id");
            }
        }

        public override void Guardar()
        {
            //using (Database Database = new Database())
            //{
            //    Database.IniciarTransaccion();
            //    if (this.EsNuevo())
            //    {
            //        this.Id = Database.EjecutarEscalar<int>("INSERT INTO [MIRRORING_GUYS].[Rol] (nombre, habilitado) output INSERTED.ID VALUES (@Nombre, @Habilitado)",
            //            Database.CrearParametro("@Nombre", this.Nombre),
            //            Database.CrearParametro("@Habilitado", this.Habilitado));
            //    }
            //    else //Si no es nuevo, actualizo los campos
            //    {
            //        Database.EjecutarNonQuery("UPDATE [MIRRORING_GUYS].[Rol] SET Nombre = @Nombre, Habilitado = @Habilitado WHERE Id = @RolId", CommandType.Text,
            //            Database.CrearParametro("@Nombre", this.Nombre),
            //            Database.CrearParametro("@Habilitado", this.Habilitado),
            //            Database.CrearParametro("@RolId", this.Id));
            //        //si lo deshabilito, tengo que borrarle el acceso a los usuarios.
            //        if (!this.Habilitado)
            //            Database.EjecutarNonQuery("DELETE FROM [MIRRORING_GUYS].[UsuarioRol] WHERE id_rol = @RolId", CommandType.Text,
            //               Database.CrearParametro("@RolId", this.Id));
            //    }
            //    //Elimino todos los funcionalidades que tenga
            //    Database.EjecutarNonQuery("DELETE FROM [MIRRORING_GUYS].[FuncPorRol] WHERE id_rol = @RolId", CommandType.Text, Database.CrearParametro("@RolId", this.Id));
            //    //Inserto los que quedaron seleccionados de la grilla
            //    foreach (int funcionalidadId in this.Funcionalidades)
            //    {
            //        Database.EjecutarNonQuery("INSERT INTO [MIRRORING_GUYS].[FuncPorRol] (id_func, id_rol) VALUES (@FuncionalidadId, @RolId)",
            //            CommandType.Text,
            //            Database.CrearParametro("@RolId", this.Id),
            //            Database.CrearParametro("@FuncionalidadId", funcionalidadId));
            //    }
            //    //Impacto todos los cambios
            //    Database.ConfirmarTransaccion();
            //}
        }
    }
}
