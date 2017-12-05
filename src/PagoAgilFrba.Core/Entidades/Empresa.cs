namespace PagoAgilFrba.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Empresa : EntidadBase
	{
        public string Nombre { get; set; }
        public string Cuit { get; set; }
        public int IdDireccion { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public int IdRubro { get; set; }
        public string Rubro { get; set; }
        public bool IsActiva { get; set; }
        public string DiaRedencion { get; set; }

        public Empresa() { }

        public Empresa(
            int id,
            string Nombre, 
            string Cuit,
            int IdDireccion, 
            string Direccion, 
            string CodigoPostal,
            string Rubro, 
            int IdRubro, 
            bool IsActiva,
            string DiaRedencion)
        {
            this.Id = id;
            this.Nombre = Nombre;
            this.Cuit = Cuit;
            this.IdDireccion = IdDireccion;
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
                                                        D.id 'Direccion ID',
	                                                    D.calle 'Direccion',
                                                        D.codigo_postal 'Codigo Postal',
	                                                    R.descripcion 'Rubro',
                                                        R.id 'Rubro ID'
                                                    FROM [MIRRORING_GUYS].[Empresa] E, [MIRRORING_GUYS].[Direccion] D, [MIRRORING_GUYS].[Rubro] R
                                                    WHERE 
                                                        E.id_direccion = D.id AND 
                                                        E.id_rubro = R.id AND 
                                                        E.cuit LIKE @Cuit AND 
                                                        E.nombre LIKE @Nombre
                                                    Order by E.nombre",
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
                                                        D.id 'Direccion ID',
	                                                    D.calle 'Direccion',
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
                                                    D.id 'Direccion ID',
	                                                D.calle 'Direccion',
                                                    D.codigo_postal 'Codigo Postal',
	                                                R.descripcion 'Rubro',
                                                    R.id 'Rubro ID'
                                                FROM [MIRRORING_GUYS].[Empresa] E, [MIRRORING_GUYS].[Direccion] D, [MIRRORING_GUYS].[Rubro] R
                                                WHERE E.id_direccion = D.id AND E.id_rubro = R.id
                                                Order by E.id");
            }
        }

        public static List<Tuple<int, string>> ListarEmpresas()
        {
            List<Tuple<int, string>> descs = new List<Tuple<int, string>>();
            foreach (DataRow dr in Empresa.Listar().Rows)
            {
                String Nombre = dr.Field<string>("Nombre");
                String Cuit = dr.Field<string>("CUIT");
                int id = dr.Field<int>("id");

                descs.Add(new Tuple<int, string>(id, Nombre + " - " + Cuit));
            }
            return descs;
        }

        public override void Guardar()
        {
            using (Database Database = new Database())
            {
                Database.IniciarTransaccion();
                Direccion Direccion = new Direccion(this.Direccion, this.CodigoPostal);
                if (this.Id == null)
                {
                    int IdDireccion = Direccion.Insert();

                    this.Id = Database.EjecutarEscalar<int>(
                        "INSERT INTO [MIRRORING_GUYS].[Empresa](cuit, nombre, esta_activa, dia_rendicion, id_direccion, id_rubro) " +
                        "output INSERTED.ID " +
                        "VALUES (@Cuit, @Nombre, @Act, @DRed, @Dir, @Rub)",
                        Database.CrearParametro("@Cuit", this.Cuit),
                        Database.CrearParametro("@Nombre", this.Nombre),
                        Database.CrearParametro("@Act", this.IsActiva ? 1 : 0),
                        Database.CrearParametro("@DRed", this.DiaRedencion),
                        Database.CrearParametro("@Dir", IdDireccion),
                        Database.CrearParametro("@Rub", this.IdRubro));
                }
                else
                {
                    Direccion.Id = this.IdDireccion;
                    Direccion.Update();
                    Database.EjecutarNonQuery(
                        "UPDATE [MIRRORING_GUYS].[Empresa] SET "+
                        "nombre = @Nombre, " +
                        "esta_activa = @Act, "+
                        "dia_rendicion = @DRed, " +
                        "id_rubro = @Rub " +
                        " WHERE id = @EId",
                        CommandType.Text,
                        Database.CrearParametro("@Nombre", this.Nombre),
                        Database.CrearParametro("@Act", this.IsActiva ? 1 : 0),
                        Database.CrearParametro("@DRed", this.DiaRedencion),
                        Database.CrearParametro("@Rub", this.IdRubro),
                        Database.CrearParametro("@EId", this.Id));
                }
                Database.ConfirmarTransaccion();
            }
        }

    }
}
