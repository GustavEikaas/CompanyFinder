namespace CompanyFinder.Models
{
    public class Company
    {
        public int Organisasjonsnummer { get; set; }
        
        public int AntallAnsatte { get; set; }

        public string Hjemmeside { get; set; }
        
        public string Navn { get; set; }

        public string StiftelsesDato { get; set; }
        
        public string Kode { get; set; }
        
        public string PostNummer { get; set; }
        
        public string PostSted { get; set; }
    }
}