public class Visa : MetodoPago
    {

        public Visa(){}

        public Visa(string numeroTarjeta, DateTime fechaCaducidad) : base() // Lo modelo como string para a la larga poder hacer validaciones
        {
            NumeroTarjeta = numeroTarjeta;
            FechaCaducidad = fechaCaducidad;
        }

        [StringLength(16, MinimumLength = 16, ErrorMessage = "El número de tarjeta debe tener exactamente 16 caracteres.")]

        public string NumeroTarjeta { get; set; }

        public DateTime FechaCaducidad { get; set; }
    }