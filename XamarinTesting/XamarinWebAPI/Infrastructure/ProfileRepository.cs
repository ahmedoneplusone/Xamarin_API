using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinWebAPI.Data;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.Infrastructure
{
    public class ProfileRepository : BaseRepository<Profile, XamarinWebDbContext>
    {
        public ProfileRepository(XamarinWebDbContext dBcontext) : base(dBcontext)
        {
        }
    }
}
