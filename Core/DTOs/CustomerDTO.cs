namespace Core.DTOs;

public class CustomerDTO
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
<<<<<<< HEAD
    public DateTime? BirthDate { get; set; } 
=======
    public string BirthDate { get; set; } = string.Empty;
>>>>>>> bd96a8821552a737241f1e57ac48f1778b78ef8e
}
