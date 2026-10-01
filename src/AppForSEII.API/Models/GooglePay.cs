public class GooglePay : MetodoPago
    {

        public GooglePay() { }
        public GooglePay(int id, string correoElectronico) : base(id)
        {
            CorreoElectronico = correoElectronico;
        }

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string CorreoElectronico { get; set; }
    }