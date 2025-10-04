namespace BankApi.Contracts
{
    public record CustomerCreateDto(string FullName, string Email, string Phone, string? Address);
    public record CustomerDto(Guid Id, string FullName, string Email, string Phone, string? Address);
    public class CustomerDtos
    {
    }
}
