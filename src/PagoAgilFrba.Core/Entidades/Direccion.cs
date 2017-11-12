namespace PagoAgilFrba.Core
{
    using System.Data;

    public class Direccion : EntidadBase
	{
        public string Calle { get; set; }
        public string Codigo_Postal { get; set; }

        public Direccion()
        {
        }

        public Direccion(string Calle, string Codigo_Postal)
        {
            this.Calle = Calle;
            this.Codigo_Postal = Codigo_Postal;
        }

        public static DataTable Listar(string nombre, string apellido, decimal dni)
        {
            return new DataTable();
        }

        public override void Guardar()
        {
        }

        public int Insert()
        {
            using (Database Database = new Database())
            {
                Database.IniciarTransaccion();
                int InsertedId = Database.EjecutarEscalar<int>(
                    "INSERT INTO MIRRORING_GUYS.Direccion(direccion, codigo_postal) output INSERTED.ID " +
                    "VALUES (@Calle, @CodigoPostal)",
                    Database.CrearParametro("@Calle", this.Calle),
                    Database.CrearParametro("@CodigoPostal", this.Codigo_Postal));
                Database.ConfirmarTransaccion();
                return InsertedId;
            }
        }

        public void Update()
        {
            using (Database Database = new Database())
            {
                Database.IniciarTransaccion();
                Database.EjecutarNonQuery(
                    "UPDATE [MIRRORING_GUYS].[Direccion] SET "+
                    "direccion = @Calle, " +
                    "codigo_postal = @CP "+
                    " WHERE id = @DId",
                    CommandType.Text,
                    Database.CrearParametro("@Calle", this.Calle),
                    Database.CrearParametro("@CP", this.Codigo_Postal),
                    Database.CrearParametro("@DId", this.Id));
                Database.ConfirmarTransaccion();
            }
        }

        public static DataTable GetById(int Id)
        {
            using (Database database = new Database())
            {
                return database.EjecutarQuery(@"SELECT
                                                    D.id
	                                                D.direccion 'Calle'
	                                                D.codigo_postal 'CodigoPostal'
                                                FROM [MIRRORING_GUYS].[Direccion] D
                                                WHERE 
                                                    d.id = @Id",
                                                Database.CrearParametro("@Id", Id));               
            }
        }
    }
}
