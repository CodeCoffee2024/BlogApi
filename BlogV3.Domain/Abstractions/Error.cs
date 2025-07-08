namespace BlogV3.Domain.Abstractions
{
    public record Error(string Name, string Description)
    {
        public static readonly Error None = new(string.Empty, string.Empty);
        public static readonly Error DifferentEntity = new("DifferentEntityException", "Entity with same name already exists");
        public static readonly Error DuplicateEntity = new("DuplicateEntityException", "Entity with same fields already exists");
        public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");
        public static readonly Error Validation = new("ValidationException", "One or more values has failed");
        public static Error Notfound(string entity) => new($"{entity}.NotFound", entity + " not found.");
        public static Error Invalid(string entity, string message) => new($"{entity}.Invalid", message);
    }
}