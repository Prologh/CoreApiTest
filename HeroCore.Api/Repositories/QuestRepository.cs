using HeroCore.Api.Data.Context;
using HeroCore.Api.Models;
using HeroCore.Api.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroCore.Api.Repositories
{
    public class QuestRepository : EntityBaseRepository<Quest>, IQuestRepository
    {
        public QuestRepository(ApiDbContext context)
            : base(context)
        { }
    }
}
