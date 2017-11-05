namespace PagoAgilFrba.Core
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class Database : IDisposable
    {
        // Variables
        private SqlConnection connection;
        private SqlTransaction transaction;
        private static String connectionString;

        // Constantes
        private const string CONNECTION_STRING = "ConnectionString";
        private const string ERROR_YA_HAY_TRX = "Ya hay una transacción en ejecución en este momento.";
        private const string ERROR_NO_HAY_TRX = "No hay transacción en ejecución en este momento";

        private static string ConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(connectionString))
                {
                    connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING].ConnectionString;
                }

                return connectionString;
            }
        }

        public Database()
        {
            try
            {
                connection = new SqlConnection(
                                    ConfigurationManager.ConnectionStrings[CONNECTION_STRING].ConnectionString);
                connection.Open();
            }
            catch
            {
                throw;
            }
        }

        public void IniciarTransaccion(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            if (transaction != null)
            {
                throw new PagoAgilException(ERROR_YA_HAY_TRX);
            }

            try
            {
                this.transaction = connection.BeginTransaction(isolationLevel);
            }
            catch
            {
                throw;
            }
        }

        public void ConfirmarTransaccion()
        {
            if (transaction == null)
            {
                throw new PagoAgilException(ERROR_NO_HAY_TRX);
            }

            try
            {
                transaction.Commit();
                transaction = null;
            }
            catch
            {
                throw;
            }
        }

        public void DeshacerTransaccion()
        {
            try
            {
                if (this.transaction != null)
                {
                    this.transaction.Rollback();
                }
            }
            finally
            {
                transaction = null;
            }
        }

        public DataTable EjecutarCommand(string texto, CommandType tipo, params SqlParameter[] parametros)
        {
            try
            {
                SqlCommand command = new SqlCommand(texto, connection);
                command.CommandType = tipo;
                command.Transaction = transaction;

                foreach (var item in parametros)
                {
                    command.Parameters.Add(item);
                }

                SqlDataReader dr = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                return dt;
            }
            catch
            {
                throw;
            }
        }

        public int EjecutarNonQuery(string texto, CommandType tipo, params SqlParameter[] parametros)
        {
            try
            {
                SqlCommand command = new SqlCommand(texto, connection);
                command.CommandType = tipo;
                command.Transaction = transaction;

                foreach (var item in parametros)
                {
                    command.Parameters.Add(item);
                }

                return command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public DataTable EjecutarQuery(string query, params SqlParameter[] parametros)
        {
            return EjecutarCommand(query, CommandType.Text, parametros);
        }

        public DataTable EjecutarProcedure(string query, params SqlParameter[] parametros)
        {
            return EjecutarCommand(query, CommandType.StoredProcedure, parametros);
        }

        public static SqlParameter CrearParametro(string nombre, object valor)
        {
            return new SqlParameter(nombre, valor);
        }

        public T EjecutarEscalar<T>(string query, params SqlParameter[] parametros)
        {
            try
            {
                return EjecutarEscalar<T>(query, CommandType.Text, parametros);
            }
            catch
            {
                throw;
            }
        }

        public T EjecutarEscalar<T>(string query, CommandType tipo, params SqlParameter[] parametros)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = tipo;
                command.Transaction = transaction;

                foreach (var item in parametros)
                {
                    command.Parameters.Add(item);
                }

                var result = command.ExecuteScalar();
                if (Convert.IsDBNull(result))
                {
                    return default(T);
                }

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        public void Dispose()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
