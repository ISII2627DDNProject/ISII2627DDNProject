public abstract class MetodoPago
    {

        public MetodoPago()
        {
            
        }

        [Key]
        public int Id { get; set; }

        public List<Reposicion> Reposiciones { get; set; } = new List<Reposicion>(); //inicializamos por defecto

        //Relación con Compra
        public List<Compra> Compras { get; set; } = new List<Compra>(); //inicializamos por defecto

    

    }