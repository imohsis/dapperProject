using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudDapper.Models;
using CrudDapper.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : Controller
    {
         private readonly IMemberRepository _memberRepository;

        public MembersController(IMemberRepository memberRepository)
        {
            this._memberRepository = memberRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<Members>> Get()
        {
            return await this._memberRepository.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<Members> Get(int Id)
        {
            return await this._memberRepository.GetUser(Id);
        }

        [HttpPost]
        public async Task Post([FromBody]Members members)
        {
            await this._memberRepository.AddMember(members);
        }

        [HttpPut("{id}")]
        public async Task Put(int UserId, [FromBody]Members members)
        {
            await this._memberRepository.UpdateMember(members);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int Id)
        {
            await this._memberRepository.DeleteMember(Id);
        }

    }
}