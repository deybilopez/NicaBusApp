namespace NicaBusMVC.Models
{
    public class DetallesViaje
    {
       public int Id { get; set; }
        public string NameBus { get; set; }

        public string Lugar { get; set; }
        public string HoraSalida { get; set; }
        public int HoraLlegada { get; set; }
        public int Destino { get; set; }


        public ICollection<User> Users { get; set; }
    }
}
