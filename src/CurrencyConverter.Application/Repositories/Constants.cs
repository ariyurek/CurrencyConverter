namespace CurrencyConverter.Application.Repositories
{
    public static class Constants
    {
        public static string ApiUrl => "https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest";
        //TODO: should be keep at azure key vault
        public static string ApiKey => "eb7c6935-5199-4488-86aa-53cd442ec3cc";
    }
}
