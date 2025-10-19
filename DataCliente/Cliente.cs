namespace DataCliente
{
    // Esta clase es la "Entidad"
    public class Cliente
    {
        // Propiedades que NO pueden ser nulas
        public string CustomerID { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public string ContactTitle { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        // Propiedades que SÍ pueden ser nulas 
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
    }
}