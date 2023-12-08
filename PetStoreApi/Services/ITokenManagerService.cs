using Microsoft.AspNetCore.Identity;
using PetStoreApi.Models.JWT;

namespace PetStoreApi.Services;

public interface ITokenManagerService
{
    Task<bool> IsCurrentActiveTokenAsync();

    Task DeactivateCurrentAsync();

    Task<bool> IsActiveAsync(string token);

    Task DeactivateAsync(string token);

    public string CreateToken(IdentityUser user);


}
