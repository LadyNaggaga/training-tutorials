public class Book  
{ 
    public int Id { get; set; } 
    public string Title { get; set; } 
    public string Genre { get; set; } 
    public int PublicationYear { get; set; } 
 
    public Author Author { get; set; } 
}