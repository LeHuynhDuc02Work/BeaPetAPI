namespace Application.Dtos
{
    public class MenuDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Position { get; set; }
    }

    public class MenuViewDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Position { get; set; }
    }
}