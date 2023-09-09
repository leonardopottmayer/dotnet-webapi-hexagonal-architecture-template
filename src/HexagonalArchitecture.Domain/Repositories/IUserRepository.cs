using HexagonalArchitecture.Domain.Entities;

namespace HexagonalArchitecture.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Queries the first user with the specified username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<User> GetUserByUsername(string username);
    }
}
