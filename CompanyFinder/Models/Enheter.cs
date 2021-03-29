using System.Collections.Generic;

namespace CompanyFinder.Models
{

    public record Root(Embedded _embedded);

    public record Embedded(List<Enheter> Enheter);
    
    public class Enheter
    {
        public int Organisasjonsnummer { get; set; }
        
        public int AntallAnsatte { get; set; }
        
        public Postadresse Postadresse { get; set; }
        
        public string Hjemmeside { get; set; }
        
        public string Navn { get; set; }
        
        public Organisasjonsform Organisasjonsform { get; set; }
        
        public string StiftelsesDato { get; set; }
        
        
    }
}