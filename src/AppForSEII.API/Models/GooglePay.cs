public class GooglePay : MetodoPago
    {

        public GooglePay() { }
        public GooglePay(string correoElectronico) : base()
        {
            CorreoElectronico = correoElectronico;
        }

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string CorreoElectronico { get; set; }
    }