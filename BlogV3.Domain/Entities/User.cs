using BlogV3.Common.Entities;
using BlogV3.Domain.Abstractions;

namespace BlogV3.Domain.Entities
{
    public class User : AuditableEntity
    {
        #region Properties

        public string UserName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string Status { get; private set; } = string.Empty;
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string MiddleName { get; private set; } = string.Empty;
        public bool IsSystemGenerated { get; private set; } = false;
        public virtual ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();
        public virtual IEnumerable<Post>? Posts { get; }

        #endregion Properties

        #region Private Constructors

        protected User()
        { }

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

        public static IEnumerable<Status> Statuses => new[]
                        {
            BlogV3.Common.Entities.Status.All,
            BlogV3.Common.Entities.Status.Active,
            BlogV3.Common.Entities.Status.Inactive,
        };

        public static User Create(string userName, string email, string password, string status, string firstName, string lastName, string middleName, DateTime createdOn, Guid createdById, bool isSeed = false)
        {
            User user = new User(userName, email, password, status, firstName, lastName, middleName);
            if (!isSeed)
            {
                user.SetCreated(createdById, createdOn);
            }
            return user;
        }

        public static User Register(string userName, string email, string password, string status, string firstName, string lastName, string middleName)
        {
            User user = new User(userName, email, password, status, firstName, lastName, middleName);
            return user;
        }

        public static User Seed(string userName, string email, string password, string status, string firstName, string lastName, string middleName)
        {
            User user = new User(userName, email, password, status, firstName, lastName, middleName);
            return user;
        }

        public void FlagAsSystemGenerated() => IsSystemGenerated = true;

        public User Update(string firstName, string lastName, string middleName, DateTime updatedOn, Guid updatedById)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            SetUpdated(updatedById, updatedOn);
            return this;
        }

        public void AssignRole(Role role)
        {
            UserRoles.Add(new UserRole { User = this, Role = role });
        }

        #endregion Private Constructors
    }
}