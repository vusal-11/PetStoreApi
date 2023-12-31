﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStoreApi.DbContexts;
using PetStoreApi.Models;
using PetStoreApi.Models.JWT;
using PetStoreApi.Services;
using System.Security.Claims;

namespace PetStoreApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly UserManager<IdentityUser> _userManager;



    private readonly UsersContext _context;

    private readonly ITokenManagerService _tokenService;

    public AuthController(UserManager<IdentityUser> userManager,ITokenManagerService tokenService,UsersContext context)
    {
        
        _userManager = userManager;
        _tokenService = tokenService;
        _context = context;


    }


    [Route("/Register")]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
    {

        var user = new IdentityUser
        {
            UserName = request.Username,
            Email = request.Email,
        };


        var claims = await _userManager.GetClaimsAsync(user) as List<Claim>;


        var result = await _userManager.CreateAsync(user,request.Password);

        if(!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok();

    }

    [Route("/Login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] AuthRequest request)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var managedUser = await _userManager.FindByEmailAsync(request.Email);

        if (managedUser == null)
        {
            return BadRequest("Bar credentials");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);
        
        if(!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }


        var userInDb = _context.Users.FirstOrDefault(u=> u.Email == request.Email); 
        if(userInDb is null)
        {
            return Unauthorized();
        }

        var accessToken = _tokenService.CreateToken(userInDb);

        //var identityLogin = 

        await _context.SaveChangesAsync();

        return Ok(new {token=accessToken});
        

    }

}
