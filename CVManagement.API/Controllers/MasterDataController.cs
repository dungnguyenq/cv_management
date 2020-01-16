using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVManagement.Service.FrameworkService;
using CVManagement.Service.LanguageServices;
using CVManagement.Service.MasterDataService;
using CVManagement.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CVManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class MasterDataController : ControllerBase
    {
        public readonly string currentUsername = "dungnguyen";

        private readonly IMasterDataService _masterDataService;
        private readonly ILanguageService _languageService;
        private readonly IFrameworkService _frameworkService;
        public MasterDataController(IMasterDataService masterDataService, ILanguageService languageService,
            IFrameworkService frameworkService)
        {
            _masterDataService = masterDataService;
            _languageService = languageService;
            _frameworkService = frameworkService;
        }

        [HttpGet("status/all")]
        public IActionResult GetStatusList()
        {
            var statusList = _masterDataService.GetStatusList();

            return Ok(statusList);
        }

        //masterdata Language
        [HttpGet("language/{id}")]
        public async Task<IActionResult> GetLanguage(Guid id)
        {
            var language = await _languageService.GetLanguage(id);
            if (language == null)
            {
                return NotFound();
            }
            return Ok(language);
        }

        [HttpGet("language/all")]
        public IActionResult GetLanguages()
        {
            var languages = _languageService.GetLanguages();

            return Ok(languages);
        }

        [HttpPost("language")]
        public async Task<IActionResult> PostLanguage([FromForm]LanguageInputModel languageInputModel)
        {
            await _languageService.AddLanguage(languageInputModel, currentUsername);
            return Ok();
        }

        [HttpPut("language/{id}")]
        public async Task<IActionResult> PutLanguage(Guid id, [FromForm]LanguageInputModel languageInputModel)
        {
            await _languageService.PutLanguage(id, languageInputModel, currentUsername);
            return Ok();
        }

        [HttpDelete("language/{id}/delete")]
        public async Task<IActionResult> DeleteLanguage(Guid id)
        {
            await _languageService.DeleteLanguage(id, currentUsername);
            return Ok();
        }

        //masterdata Framework
        [HttpGet("framework/{id}")]
        public async Task<IActionResult> GetFramework(Guid id)
        {
            var framework = await _frameworkService.GetFramework(id);
            if (framework == null)
            {
                return NotFound();
            }
            return Ok(framework);
        }

        [HttpGet("framework/all")]
        public IActionResult GetFrameworks()
        {
            var frameworks = _frameworkService.GetFrameworks();

            return Ok(frameworks);
        }

        [HttpPost("framework")]
        public async Task<IActionResult> PostFramework([FromForm]FrameworkInputModel frameworkInputModel)
        {
            await _frameworkService.AddFramework(frameworkInputModel, currentUsername);
            return Ok();
        }

        [HttpPut("framework/{id}")]
        public async Task<IActionResult> PutFramework(Guid id, [FromForm]FrameworkInputModel frameworkInputModel)
        {
            await _frameworkService.PutFramework(id, frameworkInputModel, currentUsername);
            return Ok();
        }

        [HttpDelete("framework/{id}/delete")]
        public async Task<IActionResult> DeleteFramework(Guid id)
        {
            await _frameworkService.DeleteFramework(id, currentUsername);
            return Ok();
        }
    }
}