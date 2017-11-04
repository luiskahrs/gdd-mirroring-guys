namespace PagoAgilFrba.Core
{
    using System;

    public class PagoAgilException : Exception
    {
        public PagoAgilException() : base() { }
        public PagoAgilException(string message) : base(message) { }
        public PagoAgilException(string message, Exception ex) : base(message, ex) { }
    }
}
