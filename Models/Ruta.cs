namespace NicaBusMVC.Models
{
    public class Ruta
    {
        public int Id { get; set; }
        public string Ubicacion { get; set; }
        public string Destino { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
