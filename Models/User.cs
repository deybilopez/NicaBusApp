namespace NicaBusMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int DetallesViajeId  { get; set; }
        public int RutaId { get; set; }
        public DetallesViaje DetallesViaje { get; set; }
        public Ruta Ruta  { get; set; }
    }
}
