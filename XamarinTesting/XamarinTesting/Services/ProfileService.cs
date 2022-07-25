using System;
using System.Collections.Generic;
using System.Text;
using XamarinTesting.Models;

namespace XamarinTesting.Services
{
    public class ProfileService
    {
        public IEnumerable<Profile> GetProfiles()
        {
            var requestService = new BaseService<Profile>();
            return requestService.GetRequest("/Profile");
        }
        public Profile GetProfileByID(int id)
        {
            var requestService = new BaseService<Profile>();
            return requestService.GetByIdRequest($"/Profile/{id}");
        }

    }
}
