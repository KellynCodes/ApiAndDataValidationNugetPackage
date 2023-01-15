using ApiFetcher;

do
{
    Console.WriteLine("Enter api url");
    string URL = Console.ReadLine() ?? string.Empty;
    string data = await Fetcher.FetchDataAsync(URL);
    Console.Write(data);
} while (true);