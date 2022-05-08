﻿using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public interface ISexRepository
    {
        public Task<IEnumerable<SexModel>> GetSexModels();
    }
}
