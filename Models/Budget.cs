namespace dotnet_crud_api.Models
{
        public class Budget
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public decimal Amount { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
    }