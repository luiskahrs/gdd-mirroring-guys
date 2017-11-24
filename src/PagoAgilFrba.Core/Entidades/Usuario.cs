namespace PagoAgilFrba.Core
{
    using System;
    using System.Data;

    public class Usuario : EntidadBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int LoginsFallidos { get; set; }
        public bool Habilitado { get; set; }

        public DataTable ObtenerPrivilegios(int rolId)
        {
            try
            {
                using (Database dl = new Database())
                {
                    return dl.EjecutarQuery(@"SELECT DISTINCT f.*
                                                FROM MIRRORING_GUYS.Usuario u
                                                INNER JOIN MIRRORING_GUYS.UsuarioRol ur ON u.id = ur.id_usuario
                                                INNER JOIN MIRRORING_GUYS.FuncPorRol fpr ON fpr.id_rol = ur.id_rol
                                                INNER JOIN MIRRORING_GUYS.Funcionalidad f ON fpr.id_func = f.id
                                                WHERE u.id = @UsuarioId AND ur.id_rol = @RolId", 
                                                Database.CrearParametro("@UsuarioId", this.Id),
                                                Database.CrearParametro("@RolId", rolId));
                }
            }
            catch
            {
                throw;
            }
        }

        public DataTable ObtenerPrivilegios()
        {
            try
            {
                using (Database dl = new Database())
                {
                    return dl.EjecutarQuery(@"SELECT DISTINCT f.*
                                                FROM MIRRORING_GUYS.Usuario u
                                                INNER JOIN MIRRORING_GUYS.UsuarioRol ur ON u.id = ur.id_usuario
                                                INNER JOIN MIRRORING_GUYS.FuncPorRol fpr ON fpr.id_rol = ur.id_rol
                                                INNER JOIN MIRRORING_GUYS.Funcionalidad f ON fpr.id_func = f.id
                                                WHERE u.id = @UsuarioId", Database.CrearParametro("@UsuarioId", this.Id));
                }
            }
            catch
            {
                throw;
            }
        }

        public DataTable ObtenerRoles()
        {
            try
            {
                using (Database dl = new Database())
                {
                    return dl.EjecutarQuery(@"SELECT DISTINCT r.Id, r.nombre
                                                FROM MIRRORING_GUYS.Usuario u
                                                INNER JOIN MIRRORING_GUYS.UsuarioRol ur ON u.id = ur.id_usuario
                                                INNER JOIN MIRRORING_GUYS.Rol r ON ur.id_rol = r.id
                                                WHERE u.id = @UsuarioId", 
                                                Database.CrearParametro("@UsuarioId", this.Id));
                }
            }
            catch
            {
                throw;
            }
        }

        public DataTable ObtenerSucursales()
        {
            try
            {
                using (Database dl = new Database())
                {
                    return dl.EjecutarQuery(@"SELECT DISTINCT s.Id, s.nombre
                                                FROM MIRRORING_GUYS.Usuario u
                                                INNER JOIN MIRRORING_GUYS.UsuarioSucursal us ON u.id = us.id_usuario
                                                INNER JOIN MIRRORING_GUYS.Sucursal s ON us.id_sucursal = s.id
                                                WHERE u.id = @UsuarioId",
                                                Database.CrearParametro("@UsuarioId", this.Id));
                }
            }
            catch
            {
                throw;
            }
        }

        public static Usuario Loguear(string username, string password)
        {
            try
            {
                string passEncriptado = Encriptacion.EncrptarSHA256(password);
                DataTable dt; 
                using (Database database = new Database())
                {
                    dt = database.EjecutarProcedure("MIRRORING_GUYS.Usuario_Login", Database.CrearParametro("@Username", username), Database.CrearParametro("@Password", passEncriptado));
                }

                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("No se obtuvieron datos.");
                }

                return new Usuario() 
                { 
                    Id = Convert.ToInt32(dt.Rows[0]["id"]),
                    Username = username,
                    Password = string.Empty,
                    Habilitado = Convert.ToBoolean(dt.Rows[0]["habilitado"]),
                    LoginsFallidos = Convert.ToInt32(dt.Rows[0]["logins_Fallidos"])
                };
            }
            catch (Exception ex)
            {
                throw new PagoAgilException(ex.Message);
            }
            
        }
    }
}