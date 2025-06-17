using EcoMonitor.Api.Repositories;
using EcoMonitor.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoMonitor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepository _deviceRepo;

        public DeviceController(IDeviceRepository deviceRepo)
        {
            _deviceRepo = deviceRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _deviceRepo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var device = await _deviceRepo.GetByIdAsync(id);
            return device is not null ? Ok(device) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Device device)
        {
            await _deviceRepo.AddAsync(device);
            return CreatedAtAction(nameof(GetById), new { id = device.Id }, device);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Device updated)
        {
            if (id != updated.Id) return BadRequest();
            await _deviceRepo.UpdateAsync(updated);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _deviceRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
