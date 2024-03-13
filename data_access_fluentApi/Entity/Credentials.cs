namespace data_access_fluentApi.Entity
{
    public class Credentials
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? ClientId { get; set; }
        // one to one
        public Client Client { get; set; }
    }
}
