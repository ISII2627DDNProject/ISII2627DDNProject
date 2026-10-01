public abstract class MetodoPago
    {

        public MetodoPago()
        {
            
        }

        public MetodoPago(int id)
        {
            Id = id;
        }


        [Key]
        public int Id { get; set; }

        public List<Reposicion> Reposiciones { get; set; } = new List<Reposicion>(); //inicializamos por defecto

    

    }