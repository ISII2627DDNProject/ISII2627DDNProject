public class PayPal : MetodoPago
    {

        public PayPal(){}
        public PayPal(int id, string telefono) : base(id)
        {
            Telefono = telefono;
        }

        [StringLength(9, MinimumLength =9, ErrorMessage = "El número de teléfono tiene que tener 9 dígitos.")]
        public string Telefono { get; set; }
    }