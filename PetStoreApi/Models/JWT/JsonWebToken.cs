namespace PetStoreApi.Models.JWT;

public class JsonWebToken
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }

    public int Expires { get; set; }
}
