using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CrudDapper.Models;
using Dapper;

namespace CrudDapper.Repository
{
    public class MemberRepository : IMemberRepository
    {

        private readonly string connectionString = "Server=DESKTOP-GJEI4K0;Database=lateWork;Trusted_Connection=True;";

        private SqlConnection sqlConnection;

        public async Task AddMember(Members member)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", member.Id);
                dynamicParameters.Add("@Name", member.Name);
                dynamicParameters.Add("@Comment", member.Comment);
                dynamicParameters.Add("@Phone", member.Phone);
                dynamicParameters.Add("@City", member.City);

                await sqlConnection.ExecuteAsync(
                    "spAddMember",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteMember(int Id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", Id);
                await sqlConnection.ExecuteAsync(
                    "spDeleteById",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
      //  test

        public async Task<Members> GetUser(int Id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", Id);
              return await sqlConnection.QuerySingleOrDefaultAsync<Members>(
                    "spGetMemberById",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Members>> GetUsers()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<Members>(
                    "spGetAllMembers",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        
    }

        public async Task UpdateMember(Members member)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", member.Id);
                dynamicParameters.Add("@Name", member.Name);
                dynamicParameters.Add("@Comment", member.Comment);
                dynamicParameters.Add("@Phone", member.Phone);
                dynamicParameters.Add("@City", member.City);
                await sqlConnection.ExecuteAsync(
                    "spUpdateMemberById",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
