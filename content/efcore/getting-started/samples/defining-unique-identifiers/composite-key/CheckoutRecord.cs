using System;

public class CheckoutRecord
{
    public int Id { get; set; }
    public DateTime CheckoutDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public DateTime DueDate { get; set; }
    
    public int BookId { get; set; }
    public int ReaderId { get; set; }
}