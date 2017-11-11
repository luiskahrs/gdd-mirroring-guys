namespace PagoAgilFrba.Core
{
    using System;
    using System.Data;

    public class Cliente : EntidadBase
	{
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal DNI { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Direccion Direccion { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public bool Habilitado { get; set; }

        public Cliente()
        {
            Habilitado = true;
        }

        public static DataTable Listar(string nombre, string apellido, decimal dni)
        {
            using (Database dl = new Database())
            {
                return dl.EjecutarQuery(@"SELECT Id, Apellido, Nombre, DNI, Habilitado FROM [MIRRORING_GUYS].Cliente
                                            WHERE Nombre LIKE @Nombre AND Apellido LIKE @Apellido
                                            AND
                                            ((@dni > 0 and dni = @dni) OR @dni = 0)
                                            Order by Apellido",
                                        Database.CrearParametro("@Nombre", string.Format("%{0}%", nombre)),
                                        Database.CrearParametro("@Apellido", string.Format("%{0}%", apellido)),
                                        Database.CrearParametro("@dni", dni));
            }
        }

        public static Cliente Obtener(int id)
        {
            using (Database dl = new Database())
            {
                DataTable dtCliente = dl.EjecutarQuery(@"SELECT TOP 1 Id, Apellido, Nombre, DNI, Email, Telefono, Fecha_Nacimiento, Habilitado 
                                            FROM [MIRRORING_GUYS].Cliente
                                            WHERE Id = @Id",
                                            Database.CrearParametro("@Id", id));

                DataTable dtDireccion = dl.EjecutarQuery(@"SELECT TOP 1 d.Id, d.Calle, d.Codigo_Postal 
                                            FROM [MIRRORING_GUYS].Direccion d
                                            INNER JOIN [MIRRORING_GUYS].Cliente c
                                            ON d.Id = c.id_direccion
                                            WHERE c.id = @Id",
                                       Database.CrearParametro("@Id", id));

                var cliente = new Cliente()
                {
                    Id = Convert.ToInt32(dtCliente.Rows[0]["Id"]),
                    Apellido = dtCliente.Rows[0]["Apellido"].ToString(),
                    Nombre = dtCliente.Rows[0]["Nombre"].ToString(),
                    DNI = decimal.Parse(dtCliente.Rows[0]["DNI"].ToString()),
                    Email = dtCliente.Rows[0]["Email"].ToString(),
                    Telefono = dtCliente.Rows[0]["Telefono"].ToString(),
                    Fecha_Nacimiento = DateTime.Parse(dtCliente.Rows[0]["Fecha_Nacimiento"].ToString()),
                    Habilitado = bool.Parse(dtCliente.Rows[0]["Habilitado"].ToString())
                };

                cliente.Direccion = new Direccion()
                {
                    Id = Convert.ToInt32(dtCliente.Rows[0]["Id"]),
                    Calle = dtDireccion.Rows[0]["Calle"].ToString(),
                    Codigo_Postal = dtDireccion.Rows[0]["Codigo_Postal"].ToString()
                };

                return cliente;
            }
        }

        public override void Eliminar()
        {
            using (Database dl = new Database())
            {
                dl.IniciarTransaccion();

                dl.EjecutarNonQuery("UPDATE [MIRRORING_GUYS].[Cliente] SET Habilitado = @Habilitado WHERE Id = @Id", CommandType.Text,
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

                //Impacto todos los cambios
                dl.ConfirmarTransaccion();
            }
        }
    }
}
