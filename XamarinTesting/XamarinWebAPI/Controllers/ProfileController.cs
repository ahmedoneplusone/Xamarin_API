using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinWebAPI.Data;
using XamarinWebAPI.Filter;
using XamarinWebAPI.Models;
using XamarinWebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XamarinWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;
        public ProfileController(IProfileService profileService, IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Profile>>> GetProfiles([FromQuery] EntityFilter ProfileFilter)
        {
            return base.Ok(
               // _mapper.Map<IEnumerable<Models.Profile>, IEnumerable<ProfileDto>>(
                    await _profileService.GetProfiles(ProfileFilter)
                   // )
                );
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Profile>> GetProfileByID(int id)
        {
            return base.Ok(
                //_mapper.Map<Models.Profile, ProfileDto>(
                await _profileService.GetProfileByID(id)
                //)
                );
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromBody] Models.Profile profile)
        {
            return base.Ok(
                //_mapper.Map<Models.Profile, ProfileDto>(
                    await _profileService.CreateProfile(profile)
                   // )
                );
        }

        // PUT api/<CourseController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] Models.Profile profile)
        {
            return base.Ok(
               // _mapper.Map<Models.Profile, ProfileDto>(
                    await _profileService.UpdateProfile(profile)
                    //)
                    );
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            return base.Ok(
                //_mapper.Map<Models.Profile, ProfileDto>(
                    await _profileService.DeleteProfile(id)
                   // )
                );
        }
    }
}
