using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CompanyFinder.Models;
using Newtonsoft.Json;

namespace CompanyFinder
{
    public class ExternalApi
    {
        public const string Query1 = @"https://data.brreg.no/enhetsregisteret/api/enheter?postadresse.landkode=NO&&forretningsadresse.landkode=NO&&naeringskode=71.129&&fraAntallAnsatte=3&&tilAntallAnsatte=5&&konkurs=false&&underAvvikling=false&&underTvangsavviklingEllerTvangsopplosning=false&&size=1000";
        public const string Query2 = @"https://data.brreg.no/enhetsregisteret/api/enheter?postadresse.landkode=NO&&forretningsadresse.landkode=NO&&naeringskode=62.020&&fraAntallAnsatte=3&&tilAntallAnsatte=5&&konkurs=false&&underAvvikling=false&&underTvangsavviklingEllerTvangsopplosning=false&&size=1000";


        public static async Task<IEnumerable<Company>> FetchDataFromAPI(string query)
        {
            using var client = new HttpClient();
            using var res = await client.GetAsync(query);
            using var content = res.Content;

            var data = await content.ReadAsStringAsync();
            var companyList = JsonConvert.DeserializeObject<Root>(data);

            var companies = new List<Company>();
            
            foreach (var s in companyList._embedded.Enheter)
            {
                companies.Add(new Company()
                {
                    AntallAnsatte = s.AntallAnsatte,
                    Hjemmeside = s.Hjemmeside,
                    Kode = s.Organisasjonsform.Kode,
                    Navn = s.Navn,
                    Organisasjonsnummer = s.Organisasjonsnummer,
                    StiftelsesDato = s.StiftelsesDato,
                    PostNummer = s.Postadresse.PostNummer,
                    PostSted = s.Postadresse.PostSted
                });
            }

            return companies;
        }
        
    }
}