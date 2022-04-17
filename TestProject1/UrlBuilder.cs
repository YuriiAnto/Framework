namespace ApiTestFramework
{
    public class UrlBuilder
    {
        private string version;
        private string pet;
        private string store;
        private string user;
        private string petId;
        private string findByStatus;
        private string order;
        private string orderId;
        private string inventory;
        private string username;

        public UrlBuilder()
        {
            this.version = "";
            this.pet = "";
            this.store = "";
            this.user = "";
            this.petId = "";
            this.findByStatus = "";
            this.order = "";
            this.orderId = "";
            this.inventory = "";
            this.username = "";
        }
        //public AddressBuilder WithBody(object body)
        //{
        //    street.AddJsonBody(body);
        //    return this;
        //}
        public UrlBuilder WithVersion(string newVersion)
        {
            this.version = newVersion;
            return this;
        }
        public UrlBuilder WithPet(string newPet)
        {
            this.pet = newPet;
            return this;
        }

        public UrlBuilder WithStore(string newStore)
        {
            this.store = newStore;
            return this;
        }

        public UrlBuilder WithUser(string newUser)
        {
            this.user = newUser;
            return this;
        }
        public UrlBuilder WithPetId(string newPetId)
        {
            this.petId = newPetId;
            return this;
        }
        public UrlBuilder WithFindByStatus(string newFindByStatus)
        {
            this.findByStatus = newFindByStatus;
            return this;
        }
        public UrlBuilder WithOrder(string newOrder)
        {
            this.order = newOrder;
            return this;
        }
        public UrlBuilder WithOrderId(string newOrderId)
        {
            this.orderId = newOrderId;
            return this;
        }
        public UrlBuilder WithInventory(string newInventory)
        {
            this.inventory = newInventory;
            return this;
        }
        public UrlBuilder WithUsername(string newUsername)
        {
            this.username = newUsername;
            return this;
        }

        public RequestUrl Build()
        {
            return new RequestUrl(this.version, this.pet, this.store, this.user, this.petId, this.findByStatus, this.order, this.orderId, this.inventory, this.username);
        }
    }
}

