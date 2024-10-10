namespace appmvcWithDB.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public virtual Sejour Sejour { get; set; }
    }
}
