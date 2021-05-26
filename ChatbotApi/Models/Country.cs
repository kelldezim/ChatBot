namespace ChatbotApi
{
    public partial class APIDataModel
    {
        public class Country
        {
            public string name { get; set; }
            public string[] topLevelDomain { get; set; }
            public string alpha2Code { get; set; }
            public string alpha3Code { get; set; }
            public string[] callingCodes { get; set; }
            public string capital { get; set; }
            public string[] altSpellings { get; set; }
            public string region { get; set; }
            public string subregion { get; set; }
            public int population { get; set; }
            public float[] latlng { get; set; }
            public string demonym { get; set; }
            public float area { get; set; }
            public float gini { get; set; }
            public string[] timezones { get; set; }
            public string[] borders { get; set; }
            public string nativeName { get; set; }
            public string numericCode { get; set; }
            public Currency[] currencies { get; set; }
            public Language[] languages { get; set; }
            public Translations translations { get; set; }
            public string flag { get; set; }
            public Regionalbloc[] regionalBlocs { get; set; }
            public string cioc { get; set; }
        }


    }
}
