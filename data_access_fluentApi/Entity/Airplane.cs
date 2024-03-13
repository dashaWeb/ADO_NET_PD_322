namespace data_access_fluentApi.Entity
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassanger { get; set; }
        //Navigation properties
        //Relational type : Many to Many (*....*)
        public ICollection<Flight> Flights { get; set; }
    }
}
