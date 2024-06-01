namespace Application.Dtos
{
    public class InputSearchDto
    {
        public InputSearchDto()
        {
            page = 1;
            pageSize = 20;
            search = "";
            sort = "Default"; 
        }
        public string? search { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public string? sort { get; set; }
    }
}