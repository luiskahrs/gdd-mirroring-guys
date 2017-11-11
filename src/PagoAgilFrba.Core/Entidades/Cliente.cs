namespace PagoAgilFrba.Core
{
    using System.Collections.Generic;
    using System.Data;

    public class Cliente : EntidadBase
	{
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }
        public List<int> Funcionalidades { get; set; }

        public Cliente()
        {
            Habilitado = true;
            Funcionalidades = new List<int>();
        }

        public static DataTable Listar(string nombre, string apellido, decimal dni)
        {
            using (Database dl = new Database())
            {
                return dl.EjecutarQuery(@"SELECT Apellido, Nombre, DNI FROM [MIRRORING_GUYS].[Cliente] 
                                    WHERE Nombre LIKE @Nombre 
                                    Order by Apellido",
                                        Database.CrearParametro("@Nombre", string.Format("%{0}%", nombre)));
            }
        }

        public override void Guardar()
        {
            using (Database dl = new Database())
            {
                dl.IniciarTransaccion();
                //Si el rol es nuevo, lo creo y obtengo el Id
                if (this.EsNuevo())
                {
                    this.Id = dl.EjecutarEscalar<int>("INSERT INTO [MIRRORING_GUYS].[Rol] (nombre, habilitado) output INSERTED.ID VALUES (@Nombre, @Habilitado)",
                        Database.CrearParametro("@Nombre", this.Nombre),
                        Database.CrearParametro("@Habilitado", this.Habilitado));
                }
                else //Si no es nuevo, actualizo los campos
                {
                    dl.EjecutarNonQuery("UPDATE [MIRRORING_GUYS].[Rol] SET Nombre = @Nombre, Habilitado = @Habilitado WHERE Id = @RolId", CommandType.Text,
                        Database.CrearParametro("@Nombre", this.Nombre),
                        Database.CrearParametro("@Habilitado", this.Habilitado),
                        Database.CrearParametro("@RolId", this.Id));
                    //si lo deshabilito, tengo que borrarle el acceso a los usuarios.
                    if(!this.Habilitado)
                        dl.EjecutarNonQuery("DELETE FROM [MIRRORING_GUYS].[UsuarioRol] WHERE id_rol = @RolId", CommandType.Text,
                           Database.CrearParametro("@RolId", this.Id));
                }
                //Elimino todos los funcionalidades que tenga
                dl.EjecutarNonQuery("DELETE FROM [MIRRORING_GUYS].[FuncPorRol] WHERE id_rol = @RolId", CommandType.Text, Database.CrearParametro("@RolId", this.Id));
                //Inserto los que quedaron seleccionados de la grilla
                foreach (int funcionalidadId in this.Funcionalidades)
                {
                    dl.EjecutarNonQuery("INSERT INTO [MIRRORING_GUYS].[FuncPorRol] (id_func, id_rol) VALUES (@FuncionalidadId, @RolId)",
                        CommandType.Text,
                        Database.CrearParametro("@RolId", this.Id),
                        Database.CrearParametro("@FuncionalidadId", funcionalidadId));
                }
                //Impacto todos los cambios
                dl.ConfirmarTransaccion();
            }
        }
    }
}
