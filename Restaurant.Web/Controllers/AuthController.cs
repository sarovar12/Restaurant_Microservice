using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Restaurant.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthServices _authServices;
        private readonly ITokenProvider _tokenProvider;
        public AuthController(IAuthServices authServices, ITokenProvider tokenProvider)
        {
            _authServices = authServices;
            _tokenProvider = tokenProvider;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO loginRequestDTO = new();
            return View(loginRequestDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
        {
            ResponseDTO responseDTO = await _authServices.Login<ResponseDTO>(loginRequestDTO);
            if (responseDTO != null & responseDTO.Success)
            {
                LoginResponseDTO loginResponseDTO = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(responseDTO.Result));
                _tokenProvider.SetToken(loginResponseDTO.Token);
                await SignInUser(loginResponseDTO);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("CustomError", responseDTO.DisplayMessage);
                return View(loginRequestDTO);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>() {
                new SelectListItem{Text= Standard.RoleAdmin, Value= Standard.RoleAdmin },
                new SelectListItem{Text= Standard.RoleCustomer, Value= Standard.RoleCustomer },
            };
            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            ResponseDTO result = await _authServices.Register<ResponseDTO>(registrationRequestDTO);
            ResponseDTO assignRole;
            if (result != null & result.Success)
            {
                if (string.IsNullOrEmpty(registrationRequestDTO.Role))
                {
                    registrationRequestDTO.Role = Standard.RoleCustomer;
                }
                assignRole = await _authServices.AssignRole<ResponseDTO>(registrationRequestDTO);
                if (assignRole != null && assignRole.Success)
                {
                    TempData["Success"] = "Registration Sucessful";
                    return RedirectToAction(nameof(Login));
                }

            }
            var roleList = new List<SelectListItem>() {
                new SelectListItem{Text= Standard.RoleAdmin, Value= Standard.RoleAdmin },
                new SelectListItem{Text= Standard.RoleCustomer, Value= Standard.RoleCustomer },
            };
            ViewBag.RoleList = roleList;
            return View(registrationRequestDTO);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();
            return RedirectToAction("Index","Home");
        }

        private async Task SignInUser(LoginResponseDTO loginResponseDTO)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(loginResponseDTO.Token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));
            identity.AddClaim(new Claim(ClaimTypes.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));


            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }


    }
}
