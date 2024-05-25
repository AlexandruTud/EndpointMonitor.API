using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace iTEC_Hackathon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly string _assetsPath = "C:\\Users\\Ionut\\Documents\\GitHub\\iTecHackathon.WebApplication\\static\\images\\main\\applications";

        public ImageController()
        {
           
        }

        [HttpPost("upload-from-url")]
        public async Task<IActionResult> UploadFromUrl(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("No image uploaded.");
            }

            try
            {

                string fileName = image.FileName;
                string filePath = Path.Combine(_assetsPath, fileName);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                string savedImageUrl = $"{fileName}";
                return Ok(new { url = savedImageUrl });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

