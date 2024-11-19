using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static PraticalTest.Server.Models.DataModel;
using System.Text.Json;

namespace PraticalTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data.json");

        [HttpGet]
        public async Task<IActionResult> GetJsonData()
        {
            var json = await System.IO.File.ReadAllTextAsync(_filePath);
            return Ok(JsonSerializer.Deserialize<JsonPayload>(json));
        }

        //[HttpPost]
        //public async Task<IActionResult> UpdateJsonData([FromBody] JsonPayload payload)
        //{
        //    var json = JsonSerializer.Serialize(payload);
        //    await System.IO.File.WriteAllTextAsync(_filePath, json);
        //    return Ok();
        //}

        [HttpPost]
        public async Task<IActionResult> UpdateJsonData([FromBody] JsonPayload payload)
        {
            // Read the existing data from the file
            var existingDataJson = await System.IO.File.ReadAllTextAsync(_filePath);
            var existingData = JsonSerializer.Deserialize<JsonPayload>(existingDataJson);

            // Loop through the existing data and update only the matching samplingTime properties
            foreach (var updatedDataItem in payload.Datas)
            {
                var existingItem = existingData.Datas
                    .FirstOrDefault(item => item.SamplingTime == updatedDataItem.SamplingTime);

                if (existingItem != null)
                {
                    // Update properties only for the matching samplingTime
                    existingItem.Properties = updatedDataItem.Properties;
                }
            }

            // Serialize the updated data and save it back to the file
            var updatedJson = JsonSerializer.Serialize(existingData);
            await System.IO.File.WriteAllTextAsync(_filePath, updatedJson);

            return Ok();
        }


    }
}
