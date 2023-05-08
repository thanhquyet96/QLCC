namespace QLCC.Entities
{
    public class ROLE
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public virtual ICollection<USER_ROLE> USER_ROLES { get; set;}
    }
}
