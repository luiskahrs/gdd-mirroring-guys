namespace PagoAgilFrba.Core
{
    using System;

    public abstract class EntidadBase
    {
        public int? Id { get; set; }

        /// <summary>
        /// Indica si la entidad ya existe en la base de datos o no, Si tiene Id existe, sino no
        /// </summary>
        /// <returns></returns>
        public bool EsNuevo()
        {
            return (Id == null || default(int) == Id);
        }

        /// <summary>
        /// Se debe overridear el método y realizar el INSERT para la entidad correspondiente
        /// </summary>
        public virtual void Guardar()
        {
            throw new NotImplementedException("Debe implementar el método Guardar.");
        }

        /// <summary>
        /// Se debe overridear el método y realizar el DELETE (si es baja fisica) o UPDATE (si es baja logica) para la entidad correspondiente
        /// </summary>
        public virtual void Eliminar()
        {
            throw new NotImplementedException("Debe implementar el método Eliminar.");
        }
    }
}
