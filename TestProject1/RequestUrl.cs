public class RequestUrl
{
    public string Version { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Pet { get; set; }
    public string Store { get; set; }
    public string User { get; set; }
    public string PetId { get; set; }
    public string FindByStatus { get; set; }
    public string Order { get; set; }
    public string OrderId { get; set; }
    public string Inventory { get; set; }
    public string Username { get; set; }

    public RequestUrl(string version, string pet, string store, string user, string petId, string findByStatus, string order, string orderId, string inventory, string username)
    {
        this.Version = version;
        this.Pet = pet;
        this.Store = store;
        this.User = user;
        this.PetId = petId;
        this.FindByStatus = findByStatus;
        this.Order = order;
        this.OrderId = orderId;
        this.Inventory = inventory;
        this.Username = username;
    }
    public string GetUrlString()
    {
        return $"{Version}{Pet}{Store}{User}{PetId}{FindByStatus}{Order}{OrderId}{Inventory}{Username}";
    }
}