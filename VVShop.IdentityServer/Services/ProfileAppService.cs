using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using VVShop.IdentityServer.Data;

namespace VVShop.IdentityServer.Services
{
    public class ProfileAppService : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ProfileAppService(UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _roleManager = roleManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //id usuario no IS
            string id = context.Subject.GetSubjectId();

            //localizar pelo id
            ApplicationUser user = await _userManager.FindByIdAsync(id);

            //cria claimsPrincipal para o usuario
            ClaimsPrincipal userClaims = await _userClaimsPrincipalFactory.CreateAsync(user);

            //define uma coleção de claims para o usuário e inclui o sobrenome e o nome do usuario
            List<Claim> claims = userClaims.Claims.ToList();
            claims.Add(new Claim(JwtClaimTypes.FamilyName, user.LastName));
            claims.Add(new Claim(JwtClaimTypes.GivenName, user.FirstName));

            // se o userManager do identtiy suporta role
            if (_userManager.SupportsUserRole)
            {
                //obtem a lista dos nomes da roles para o usuario
                IList<string> roles = await _userManager.GetRolesAsync(user);

                //percorre a lista
                foreach (string role in roles)
                {
                    //adicione a role a claim
                    claims.Add(new Claim(JwtClaimTypes.Role, role));

                    //se o roleManager suporta claims para roles
                    if (_roleManager.SupportsRoleClaims)
                    {

                        //localiza o perfil
                        IdentityRole identityRole = await _roleManager.FindByNameAsync(role);

                        //inclui o perfil
                        if (identityRole != null)
                        {
                            //inclui as claims associadas a role
                            claims.AddRange(await _roleManager.GetClaimsAsync(identityRole));
                        }

                    }
                }
            }
            //Retorna as claims no contexto;
            context.IssuedClaims = claims;  
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            //obtem o id do usuario no is
            string userId = context.Subject.GetSubjectId();

            //localiza o usuario
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            //verifica se esta ativo
            context.IsActive = user is not null;
        }
    }
}
