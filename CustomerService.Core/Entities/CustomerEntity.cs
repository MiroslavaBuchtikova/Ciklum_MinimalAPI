namespace CustomerService.Core.Entities;

public class CustomerEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    
    public Gender Gender { get; set; }
}

public enum Gender
{
    Unknown,
    Male,
    Female
}