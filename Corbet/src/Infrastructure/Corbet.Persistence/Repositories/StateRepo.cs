using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Domain.Entities;

using Microsoft.Extensions.Logging;

namespace Corbet.Persistence.Repositories
{
    public class StateRepo : BaseRepository<State>, IStateRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public StateRepo(ApplicationDbContext dbContext, ILogger<State> logger, IMapper mapper) : base(dbContext, logger)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
