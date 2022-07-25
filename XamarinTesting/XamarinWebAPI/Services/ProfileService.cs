using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinWebAPI.Filter;
using XamarinWebAPI.Infrastructure;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.Services
{
    public interface IProfileService
    {
        bool ProfileExists(string Name);
        Task <IEnumerable<Models.Profile>> GetProfiles();
        Task<IEnumerable<Models.Profile>> GetProfiles(EntityFilter profileFilter);
        Task<Models.Profile> GetProfileByID(int profileID);
        Task<Models.Profile> CreateProfile(Models.Profile profile);
        Task<Models.Profile> UpdateProfile(Models.Profile profile);
        Task<Models.Profile> DeleteProfile(int profileID);

    }

    public class ProfileService : IProfileService
    {
        private readonly ProfileRepository repo;
        public ProfileService(ProfileRepository repo)
        {
            this.repo = repo;
        }

        public bool ProfileExists(string Name)
        {
            return repo.Get(x => x.Name == Name).Result.Any();
        }

        public Task<Models.Profile> CreateProfile(Models.Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));
            if (ProfileExists(profile.Name))
                throw new Exception("Employee with same name already exists");
            return repo.Add(profile);
        }

        public async Task<Models.Profile> DeleteProfile(int profileID)
        {
            var profile = await GetProfileByID(profileID);
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));
            return await repo.Delete(profileID);
        }

        public async Task<IEnumerable<Models.Profile>> GetProfiles()
        {
            return await repo.GetAll();
        }
        public async Task<IEnumerable<Models.Profile>> GetProfiles(EntityFilter profileFilter)
        {
            if (string.IsNullOrWhiteSpace(profileFilter.EntityID) && string.IsNullOrWhiteSpace(profileFilter.SearchQuery) && string.IsNullOrWhiteSpace(profileFilter.SortByParam))
            {
                return await GetProfiles();
            }
            var profiles = await repo.GetAll();
            if (!string.IsNullOrWhiteSpace(profileFilter.EntityID))
            {
                int.TryParse(profileFilter.EntityID, out int profileID);
                profiles = profiles.Where(x => x.ProfileID == profileID);
            }
            if (!string.IsNullOrWhiteSpace(profileFilter.SearchQuery))
            {
                profiles = profiles.Where(x => x.Name.Contains(profileFilter.SearchQuery));
            }
            if (!string.IsNullOrWhiteSpace(profileFilter.SortByParam))
            {
                if (profileFilter.SortByParam.ToLower() == "hire_date")
                {
                    if (!string.IsNullOrWhiteSpace(profileFilter.SortByMethod) && profileFilter.SortByMethod.ToLower() == "asc")
                    {
                        profiles = profiles.OrderBy(x => x.FirstHireDate);
                    }
                    else
                    {
                        profiles = profiles.OrderByDescending(x => x.FirstHireDate);
                    }
                }
                if (profileFilter.SortByParam.ToLower() == "name")
                {
                    if (!string.IsNullOrWhiteSpace(profileFilter.SortByMethod) && profileFilter.SortByMethod.ToLower() == "asc")
                    {
                        profiles = profiles.OrderBy(x => x.Name);
                    }
                    else
                    {
                        profiles = profiles.OrderByDescending(x => x.Name);
                    }
                }
            }
            return profiles.ToList();
        }

        public async Task<Models.Profile> GetProfileByID(int profileID)
        {
            var profile = await repo.Get(profileID);
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));
            return profile;
        }


        public async Task<Models.Profile> UpdateProfile(Models.Profile profile)
        {
            var existsProfile = await GetProfileByID(profile.ProfileID);
            if (ProfileExists(profile.Name))
            {
                throw new Exception("Employee with same name already exists");
            }
            existsProfile.FirstName = profile.FirstName;
            existsProfile.LastName = profile.LastName;
            existsProfile.Name = profile.FirstName+" "+profile.LastName;
            existsProfile.Job = profile.Job;
            existsProfile.Mobile = profile.Mobile;
            return await repo.Update(existsProfile);
        }
    }
}
