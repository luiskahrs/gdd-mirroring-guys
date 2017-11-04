namespace PagoAgilFrba
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;

    public class Generico
    {
        public static void MostrarError(Exception ex)
        {
            MostrarError(ex.Message);
        }
        public static void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void MostrarInformacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static DialogResult MostrarPregunta(string mensaje)
        {
            return MessageBox.Show(mensaje, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static void ConfigurarComboBox(ComboBox cbo, DataTable dtValores, string valueMember = "Id", string displayMember = "Nombre", bool incluyeNull = false, string textoNull = "[Seleccione]")
        {
            if (cbo == null || dtValores == null || dtValores.Rows.Count == 0) return;

            if (incluyeNull)
            {
                DataRow dr = dtValores.NewRow();
                foreach (DataColumn dc in dtValores.Columns)
                {
                    dr[dc] = dtValores.Rows[0][dc];
                }
                dr[valueMember] = -1;
                dr[displayMember] = textoNull;
                dtValores.Rows.InsertAt(dr, 0);
            }
            cbo.DataSource = dtValores;
            cbo.ValueMember = valueMember;
            cbo.DisplayMember = displayMember;
        }
        public static void ConfigurarDateTimePicker(DateTimePicker dateTimePicker, DateTime? fecha)
        {
            if (dateTimePicker == null) return;

            if (!fecha.HasValue)
                dateTimePicker.Checked = false;
            else
            {
                dateTimePicker.Checked = true;
                dateTimePicker.Value = fecha.Value;
            }
        }
        public static DateTime? ObtenerFecha(DateTimePicker dateTimePicker)
        {
            if (dateTimePicker == null) return null;

            if (!dateTimePicker.Checked) return null;

            return dateTimePicker.Value;

        }
    }
}
