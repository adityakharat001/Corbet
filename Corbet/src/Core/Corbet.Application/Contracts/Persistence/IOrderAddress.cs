﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Domain.Entities;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IOrderAddress : IAsyncRepository<OrderAddress>
    {
        //Task<bool> AddingAddress(OrderAddress orderAddress);
    }
}