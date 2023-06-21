using MovieReview.Database.Repositories.Interfaces.Base;
using MovieReview.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Database.Repositories.Interfaces
{
    public interface ITitleRepository : IBaseRepository<Title>
    {
    }
}
