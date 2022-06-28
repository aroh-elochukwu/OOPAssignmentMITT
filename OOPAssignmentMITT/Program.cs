class  Hotel
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Room> Rooms { get; set; } = new List<Room>();
    public List<Client> Clients { get; set; } = new List<Client>();
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    public Hotel(string name, string address)
    {
        Name = name;
        Address = address;
    }   


}

class Room
{
    public string Number { get; set; }
    public int Capacity { get; set; }
    public bool Occupied { get; set; } = false;
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    public Room(string number, int capacity)
    {
        Number = number;
        Capacity = capacity;

    }

}

class Client
{
    public string Name { get; set; }
    public long CreditCard { get; set; }
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    public Client(string name, long creditCard)
    {
        Name = name;
        CreditCard = creditCard;
        
    }
}

class Reservation
{
    public DateTime Date { get; set; }
    public int Occupants { get; set; }
    public bool IsCurrent { get; set; } = false;
    public Client Client { get; set; }
    public Room Room { get; set; }

    public Reservation(DateTime date, int occupants, Client client, Room room)
    {
        Date = date;
        Occupants = occupants;
        Client = client;
        Room = room;
    }
}