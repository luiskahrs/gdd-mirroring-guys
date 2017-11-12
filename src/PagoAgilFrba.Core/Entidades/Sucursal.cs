namespace PagoAgilFrba.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Sucursal : EntidadBase
	{
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }
        public Direccion Direccion { get; set; }

        public Sucursal()
        {
            Habilitado = true;
            Direccion = new Direccion();
        }

        public static DataTable Listar(string nombre, string direccion, string codPostal)
        {
            using (Database dl = new Database())
            {
                return dl.EjecutarQuery(@"SELECT s.Id, s.Nombre, d.Calle, d.Codigo_Postal, s.Habilitado 
                                            FROM [MIRRORING_GUYS].Sucursal s
                                            INNER JOIN [MIRRORING_GUYS].Direccion d
                                            ON s.id_direccion = d.Id
                                            WHERE s.Nombre LIKE @Nombre AND d.Calle LIKE @Calle AND d.Codigo_Postal LIKE @CodPostal
                                            Order by Nombre",
                                        Database.CrearParametro("@Nombre", string.Format("%{0}%", nombre)),
                                        Database.CrearParametro("@Calle", string.Format("%{0}%", direccion)),
                                        Database.CrearParametro("@CodPostal", string.Format("%{0}%", codPostal)));
            }
        }

        public static Sucursal Obtener(int id)
        {
            using (Database dl = new Database())
            {
                DataTable dtSucursal = dl.EjecutarQuery(@"SELECT TOP 1 Id, Nombre, Habilitado 
                                            FROM [MIRRORING_GUYS].Sucursal
                                            WHERE Id = @Id",
                                            Database.CrearParametro("@Id", id));

                DataTable dtDireccion = dl.EjecutarQuery(@"SELECT TOP 1 d.Id, d.Calle, d.Codigo_Postal 
                                            FROM [MIRRORING_GUYS].Direccion d
                                            INNER JOIN [MIRRORING_GUYS].Sucursal s
                                            ON d.Id = s.id_direccion
                                            WHERE s.id = @Id",
                                       Database.CrearParametro("@Id", id));

                var sucursal = new Sucursal()
                {
                    Id = Convert.ToInt32(dtSucursal.Rows[0]["Id"]),
                    Nombre = dtSucursal.Rows[0]["Nombre"].ToString(),
                    Habilitado = bool.Parse(dtSucursal.Rows[0]["Habilitado"].ToString())
                };

                sucursal.Direccion.Id = Convert.ToInt32(dtDireccion.Rows[0]["Id"]);
                sucursal.Direccion.Calle = dtDireccion.Rows[0]["Calle"].ToString();
                sucursal.Direccion.Codigo_Postal = dtDireccion.Rows[0]["Codigo_Postal"].ToString();

                return sucursal;
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

                //Impacto todos los cambios
                dl.ConfirmarTransaccion();
            }
        }

        public bool ValidarCodigoPostal(string codPostal)
        {
            using (Database dl = new Database())
            {
                int cantCodPostal = dl.EjecutarEscalar<int>(@"SELECT COUNT(d.codigo_postal) 
                                                            FROM[MIRRORING_GUYS].[Direccion] d
                                                            INNER JOIN[MIRRORING_GUYS].[Sucursal] s
                                                            ON d.id = s.id_direccion
                                                            WHERE
                                                            d.codigo_postal = @CodPostal AND s.Id <> @Id",
                                                        Database.CrearParametro("@CodPostal", codPostal),
                                                        Database.CrearParametro("@Id", this.Id.HasValue ? this.Id.Value : 0));

                return cantCodPostal > 0 ? false : true;
            }
        }
    }
}
