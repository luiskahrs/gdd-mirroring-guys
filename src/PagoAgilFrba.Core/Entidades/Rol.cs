using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PagoAgilFrba.Core
{
    public class Rol : EntidadBase
	{
        public Rol()
        {
            Habilitado = true;
            Funcionalidades = new List<int>();
        }
		public string Nombre { get; set; }
        public bool Habilitado { get; set; }
        public List<int> Funcionalidades { get; set; }

        public static DataTable Listar(string nombre, string estado)
        {
            using (Database dl = new Database())
            {
                return dl.EjecutarQuery(@"SELECT * FROM [MIRRORING_GUYS].[Rol] 
                                    WHERE Nombre LIKE @Nombre 
                                    AND (@Estado = 'Todos' OR Habilitado = CASE @Estado WHEN 'Habilitados' THEN 1 WHEN 'Deshabilitados' THEN 0 END) 
                                    Order by Id",
                Database.CrearParametro("@Nombre", string.Format("%{0}%", nombre)),
                Database.CrearParametro("@Estado", estado));
            }
        }
        public DataTable ObtenerFuncionalidades() 
        {
            using (Database dl = new Database())
            {
                return dl.EjecutarQuery(@"SELECT CASE WHEN rp.RolID IS NULL THEN 0 ELSE 1 END as S, 
                                    f.Nombre as Funcionalidad,
                                    f.Id as FuncionalidadId
                                    FROM [MIRRORING_GUYS].[Funcionalidad] f 
                                    LEFT JOIN [MIRRORING_GUYS].[FuncPorRol] fpr ON fpr.id_func = f.id AND fpr.id_rol  = @RolId",
                                    Database.CrearParametro("@RolId", this.Id));
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
                    this.Id = dl.EjecutarEscalar<int>("INSERT INTO [MIRRORING_GUYS].[Rol] (Nombre, Habilitado)  output INSERTED.ID VALUES (@Nombre, @Habilitado)",
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
                        dl.EjecutarNonQuery("DELETE FROM [MIRRORING_GUYS].[UsuarioRol] WHERE RolId = @RolId", CommandType.Text,
                           Database.CrearParametro("@RolId", this.Id));
                }
                //Elimino todos los funcionalidades que tenga
                dl.EjecutarNonQuery("DELETE FROM[MIRRORING_GUYS].[FuncPorRol] WHERE RolId = @RolId", CommandType.Text, Database.CrearParametro("@RolId", this.Id));
                //Inserto los que quedaron seleccionados de la grilla
                foreach (int funcionalidadId in this.Funcionalidades)
                {
                    dl.EjecutarNonQuery("INSERT INTO [MIRRORING_GUYS].[FuncPorRol] VALUES (@RolId, @FuncionalidadId)",
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
