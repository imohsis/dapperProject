using CrudDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDapper.Repository
{
     public interface IMemberRepository
    {
        Task<IEnumerable<Members>> GetUsers();

        Task<Members> GetUser(int Id);

        Task AddMember(Members member);

        Task UpdateMember(Members member);

        Task DeleteMember(int Id);
    }
}
