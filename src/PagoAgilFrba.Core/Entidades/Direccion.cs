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

        public static DataTable Listar(string nombre, string apellido, decimal dni)
        {
            return new DataTable();
        }

        public override void Guardar()
        {
        }
    }
}
