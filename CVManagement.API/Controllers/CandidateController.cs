using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CVManagement.Service.CandidateServices;
using Microsoft.AspNetCore.Authorization;
using CVManagement.Service.Models;
using CVManagement.Service.CandidateLanguageServices;
using Microsoft.AspNetCore.Http;
using CVManagement.Service.Extensions;
using Newtonsoft.Json;

namespace CVManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CandidateController : ControllerBase
    {
        private readonly string currentUsername = "dungnguyen";
        private readonly ICandidateService _candidateService;
        private readonly ICandidateLanguageService _candidateLanguageService;
        public CandidateController( ICandidateService candidateService, ICandidateLanguageService candidateLanguageService)
        {
            _candidateService = candidateService;
            _candidateLanguageService = candidateLanguageService;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidate(Guid id)
        {
            var candidate = await _candidateService.GetCandidate(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return Ok(candidate);
        }

        [HttpGet("all")]
        public IActionResult GetCandidates()
        {
            var candidates = _candidateService.GetCandidates();

            return Ok(candidates);
        }
        [HttpPost]
        public async Task<IActionResult> PostCandidate(IFormFile image, IFormFile cv, [FromForm]string data)
        {
            var model = JsonConvert.DeserializeObject<CandidateInputModel>(data);
            await _candidateService.AddCandidate(image, cv,  model, currentUsername);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate (Guid id, IFormFile image, IFormFile cv, [FromForm]string data)
        {
            var model = JsonConvert.DeserializeObject<CandidateInputModel>(data);
            await _candidateService.PutCandidate(id, image, cv, model, currentUsername);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<IActionResult> DeleteCandidate(Guid id)
        {
            await _candidateService.DeleteCandidate(id, currentUsername);
            return Ok();
        }

        [HttpPost]
        [Route("send-email")]
        public async Task<IActionResult> Sendmail([FromForm]string data)
        {
            var model = JsonConvert.DeserializeObject<MailModel>(data);
            var result = await _candidateService.Sendmail(model);
            return Ok();
        }
    }
}