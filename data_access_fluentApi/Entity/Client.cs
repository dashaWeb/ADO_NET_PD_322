namespace data_access_fluentApi.Entity
{
    //Entities
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }//not null ===> null
        //Navigation properties

        //Relational type : Many to Many (*....*)
        public ICollection<Flight> Flights { get; set; }
        public Credentials Credentials { get; set; }
    }
}
