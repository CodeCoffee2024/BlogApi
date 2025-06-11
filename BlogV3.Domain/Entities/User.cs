using BlogV3.Domain.Abstractions;

namespace BlogV3.Domain.Entities
{
    public record class User : AuditableEntity
    {
        #region Properties

        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Status { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public virtual IEnumerable<Post>? Posts { get; }

        #endregion Properties

        #region Private Constructors

        protected User() { }
        private User(string userName, string email, string password, string status, string firstName, string lastName, string middleName)
        {
            UserName = userName;
            Email = email;
            Password = password;
            Status = status;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        public static User Create(string userName, string email, string password, string status, string firstName, string lastName, string middleName, DateTime createdOn, Guid createdById, bool isSeed = false)
        {
            User user = new User(userName, email, password, status, firstName, lastName, middleName);
            if (!isSeed)
            {
                user.SetCreated(createdById, createdOn);
            }
            return user;
        }

        public static User Seed(string userName, string email, string password, string status, string firstName, string lastName, string middleName)
        {
            User user = new User(userName, email, password, status, firstName, lastName, middleName);
            return user;
        }

        public User Update(string userName, string email, string password, string status, string firstName, string lastName, string middleName, DateTime updatedOn, Guid updatedById)
        {
            UserName = userName;
            Email = email;
            Password = password;
            Status = status;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            SetUpdated(updatedById, updatedOn);
            return this;
        }

        #endregion Private Constructors
    }
}