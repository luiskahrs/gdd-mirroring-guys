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

        public override void Eliminar()
        {
            using (Database dl = new Database())
            {
                dl.IniciarTransaccion();

                // Inhabilito a los usuarios
                dl.EjecutarNonQuery(@"UPDATE u SET u.Habilitado = @Habilitado FROM [MIRRORING_GUYS].[Usuario] u
		                                    INNER JOIN [MIRRORING_GUYS].[UsuarioSucursal] us
		                                    on u.Id = us.id_usuario
		                                    WHERE us.id_sucursal = @Id", CommandType.Text,
                                            Database.CrearParametro("@Habilitado", false),
                                            Database.CrearParametro("@Id", this.Id));

                // Borro los registros de la tabla de relaciones
                dl.EjecutarNonQuery("DELETE FROM [MIRRORING_GUYS].[UsuarioSucursal] WHERE id_sucursal = @Id", CommandType.Text,
                                        Database.CrearParametro("@Id", this.Id));

                // Inhabilito la sucursal
                dl.EjecutarNonQuery("UPDATE [MIRRORING_GUYS].[Sucursal] SET Habilitado = @Habilitado WHERE Id = @Id", CommandType.Text,
                    Database.CrearParametro("@Habilitado", false),
                    Database.CrearParametro("@Id", this.Id));

                dl.ConfirmarTransaccion();
            }
        }

        public override void Guardar()
        {
            using (Database dl = new Database())
            {
                dl.IniciarTransaccion();

                try
                {
                    //Si es nuevo lo creo, si no, realizo la actualizacion de los datos.
                    if (this.EsNuevo())
                    {
                        this.Direccion.Id = dl.EjecutarEscalar<int>("INSERT INTO [MIRRORING_GUYS].[Direccion] (calle, codigo_postal) output INSERTED.ID VALUES (@Calle, @Codigo_Postal)",
                                            Database.CrearParametro("@Calle", this.Direccion.Calle),
                                            Database.CrearParametro("@Codigo_Postal", this.Direccion.Codigo_Postal));

                        this.Id = dl.EjecutarEscalar<int>("INSERT INTO [MIRRORING_GUYS].[Sucursal] (nombre, habilitado,id_direccion) output INSERTED.ID VALUES (@Nombre, @Habilitado, @Id_direccion)",
                            Database.CrearParametro("@Nombre", this.Nombre),
                            Database.CrearParametro("@Habilitado", 1),
                            Database.CrearParametro("@Id_direccion", this.Direccion.Id));
                    }
                    else
                    {
                        dl.EjecutarNonQuery("UPDATE [MIRRORING_GUYS].[Direccion] SET Calle = @Calle, Codigo_Postal = @Codigo_Postal WHERE Id = @Id", CommandType.Text,
                            Database.CrearParametro("@Calle", this.Direccion.Calle),
                            Database.CrearParametro("@Codigo_Postal", this.Direccion.Codigo_Postal),
                            Database.CrearParametro("@Id", this.Direccion.Id));

                        dl.EjecutarNonQuery("UPDATE [MIRRORING_GUYS].[Sucursal] SET nombre = @Nombre, habilitado = @Habilitado, id_direccion = @Id_direccion WHERE id = @Id", CommandType.Text,
                            Database.CrearParametro("@Nombre", this.Nombre),
                            Database.CrearParametro("@Habilitado", this.Habilitado ? 1 : 0),
                            Database.CrearParametro("@Id_direccion", this.Direccion.Id),
                            Database.CrearParametro("@Id", this.Id));
                    }
                }
                catch (Exception ex)
                {
                    dl.DeshacerTransaccion();
                    throw new PagoAgilException("Ha ocurrido un error al grabar la sucursal, detalle: " + ex.Message);
                }

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
