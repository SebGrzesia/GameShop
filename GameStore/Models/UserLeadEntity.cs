namespace GameStore.Models
{
    public class UserLeadEntity
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }

        public UserLeadEntity() 
        {
            this.ID = Guid.NewGuid().ToString();
        }
    }
}
