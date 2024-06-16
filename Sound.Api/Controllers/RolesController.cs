using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Sound.Api.Controllers
{
    [Controller, Route("api/[controller]"), AllowAnonymous]
    public class RolesController : ControllerBase
    {
        public RoleManager<IdentityRole> RoleManager { get; }

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }

        [HttpGet("get-roles")]
        public IActionResult GetRoles()
        {
            return Ok(RoleManager.Roles);
        }
        [HttpDelete("delete-role-by-id/{id}")]
        public async Task<IActionResult> DeleteRoleById(Guid id)
        {
            var role = await RoleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return NotFound();
            await RoleManager.DeleteAsync(role);
            return Ok();
        }
        [HttpPost("create-role/{roleName}")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var role = new IdentityRole { Name = roleName };
            await RoleManager.CreateAsync(role);
            return Ok(role);
        }

    }
}