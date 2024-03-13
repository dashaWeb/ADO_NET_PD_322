namespace data_access_fluentApi.Entity
{
    public class Flight
    {
        //Primary key naming : Id/id/ID / EntityName+Id = FlightId
        public int Number { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        //Navigation properties
        //Relational type : One to Many (1....*)
        //Foreign key naming : RelatedEntityName + RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; }//foreign key
        public Airplane Airplane { get; set; }//null
                                              //Relational type : Many to Many (*....*)

        //Navigation properties
        public ICollection<Client> Clients { get; set; }

    }
}
