using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N_Tier.BusinessLogic.Logics;
using N_Tier.BusinessLogic.Models.DTO.Catagory;
using System.Threading.Tasks;

namespace N_Tier.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        private readonly CatagoryLogics _catagoryLogics;
        public CatagoryController(CatagoryLogics catagoryLogics)
        {
            _catagoryLogics = catagoryLogics;
        }

        [HttpGet]
        public async Task<IActionResult> GetCatagories()
        {
            return Ok(await _catagoryLogics.CatagoryList());
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> AddCatagory(AddCatagoryUIDTO catagory)
        {
            var operation = await _catagoryLogics.AddCatagory(catagory);
            if (operation)
            {
                return Ok("Successfully");
            }
            else
            {
                return BadRequest("Unsuccessfully");
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCatagory(UpdateCatagoryUIDTO catagory)
        {
            var operation = await _catagoryLogics.UpdateCatagory(catagory);
            if (operation)
            {
                return Ok("Successfully");
            }
            {
                return BadRequest("Unsuccessfully");
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCatagory(DeleteCatagoryUIDTO catagory)
        {
            var operation = await _catagoryLogics.DeleteCatagory(catagory);
            if (operation)
            {
                return Ok("Successfully");
            }
            {
                return BadRequest("Unsuccessfully");
            }
        }
    }
}
