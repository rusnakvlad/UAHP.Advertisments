using Newtonsoft.Json;

namespace AdvertismentAPI.Exceptions;

public class Error
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string ErrorDetails { get; set; }
    public string Endpoint { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
