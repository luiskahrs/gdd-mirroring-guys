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
            Direccion = new Direccion();
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

                cliente.Direccion.Id = Convert.ToInt32(dtDireccion.Rows[0]["Id"]);
                cliente.Direccion.Calle = dtDireccion.Rows[0]["Calle"].ToString();
                cliente.Direccion.Codigo_Postal = dtDireccion.Rows[0]["Codigo_Postal"].ToString();

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

        public bool ValidarMail(string email)
        {
            using (Database dl = new Database())
            {
                int cantMail = dl.EjecutarEscalar<int>("SELECT COUNT(Email) FROM [MIRRORING_GUYS].[Cliente] WHERE Email = @Email AND Id <> @Id",
                    Database.CrearParametro("@Email", email),
                    Database.CrearParametro("@Id", this.Id.HasValue ? this.Id.Value : 0));

                return cantMail > 0 ? false : true; 
            }
        }

        public override void Guardar()
        {
            using (Database dl = new Database())
            {
                dl.IniciarTransaccion();

                try
                {
                    //Si el Cliente es nuevo, lo creo y obtengo el Id. Si no actualizo el existente.
                    if (this.EsNuevo())
                    {
                        this.Direccion.Id = dl.EjecutarEscalar<int>("INSERT INTO [MIRRORING_GUYS].[Direccion] (calle, codigo_postal) output INSERTED.ID VALUES (@Calle, @Codigo_Postal)",
                            Database.CrearParametro("@Calle", this.Direccion.Calle),
                            Database.CrearParametro("@Codigo_Postal", this.Direccion.Codigo_Postal));

                        this.Id = dl.EjecutarEscalar<int>("INSERT INTO [MIRRORING_GUYS].[Cliente] (dni, apellido, nombre, fecha_nacimiento, email, telefono, habilitado, id_direccion) output INSERTED.ID VALUES (@Dni, @Apellido, @Nombre, @Fecha_nacimiento, @Email, @Telefono, @Habilitado, @Id_direccion)",
                            Database.CrearParametro("@Dni", this.DNI),
                            Database.CrearParametro("@Apellido", this.Apellido),
                            Database.CrearParametro("@Nombre", this.Nombre),
                            Database.CrearParametro("@Fecha_nacimiento", this.Fecha_Nacimiento.ToString("yyyy-MM-dd")),
                            Database.CrearParametro("@Email", this.Email),
                            Database.CrearParametro("@Telefono", this.Telefono),
                            Database.CrearParametro("@Habilitado", 1),
                            Database.CrearParametro("@Id_direccion", this.Direccion.Id));
                    }
                    else
                    {
                        dl.EjecutarNonQuery("UPDATE [MIRRORING_GUYS].[Direccion] SET Calle = @Calle, Codigo_Postal = @Codigo_Postal WHERE Id = @Id", CommandType.Text,
                            Database.CrearParametro("@Calle", this.Direccion.Calle),
                            Database.CrearParametro("@Codigo_Postal", this.Direccion.Codigo_Postal),
                            Database.CrearParametro("@Id", this.Direccion.Id));

                        dl.EjecutarNonQuery("UPDATE [MIRRORING_GUYS].[Cliente] SET dni = @Dni, apellido = @Apellido, nombre = @Nombre, fecha_nacimiento = @Fecha_nacimiento, email = @Email, telefono = @Telefono, habilitado = @Habilitado, id_direccion = @Id_direccion WHERE id = @Id", CommandType.Text,
                            Database.CrearParametro("@Dni", this.DNI),
                            Database.CrearParametro("@Apellido", this.Apellido),
                            Database.CrearParametro("@Nombre", this.Nombre),
                            Database.CrearParametro("@Fecha_nacimiento", this.Fecha_Nacimiento.ToString("yyyy-MM-dd")),
                            Database.CrearParametro("@Email", this.Email),
                            Database.CrearParametro("@Telefono", this.Telefono),
                            Database.CrearParametro("@Habilitado", this.Habilitado ? 1 : 0),
                            Database.CrearParametro("@Id_direccion", this.Direccion.Id),
                            Database.CrearParametro("@Id", this.Id));
                    }
                }
                catch (Exception ex)
                {
                    dl.DeshacerTransaccion();
                    throw new PagoAgilException("Ha ocurrido un error al grabar el usuario, detalle: " + ex.Message);
                }

                //Impacto todos los cambios
                dl.ConfirmarTransaccion();
            }
        }
    }
}
