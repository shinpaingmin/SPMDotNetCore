using DotNetTrainingBatch3.BirdWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace DotNetTrainingBatch3.BirdWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        private readonly string _url = "https://burma-project-ideas.vercel.app/birds";

        [HttpGet]
        
        public async Task<IActionResult> Get()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(_url);

            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                List<BirdDataModel> birds = JsonConvert.DeserializeObject<List<BirdDataModel>>(json)!;

                List<BirdViewModel> lst = birds.Select(bird => Change(bird)).ToList();

                return Ok(lst);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"{_url}/{id}");

            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                BirdDataModel bird = JsonConvert.DeserializeObject<BirdDataModel>(json)!;

                BirdViewModel item = Change(bird);

                return Ok(item);
            }
            else
            {
                return BadRequest();
            }
        }

        // Private Data Model Change Function
        private BirdViewModel Change(BirdDataModel bird)
        {
            var item = new BirdViewModel
            {
                BirdId = bird.Id,
                BirdName = bird.BirdMyanmarName,
                Desp = bird.Description,
                PhotoUrl = $"https://burma-project-ideas.vercel.app/{bird.ImagePath}"
            };

            return item;
        }
    }
}
