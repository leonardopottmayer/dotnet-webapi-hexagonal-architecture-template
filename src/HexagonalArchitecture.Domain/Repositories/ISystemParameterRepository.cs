using HexagonalArchitecture.Domain.Entities;

namespace HexagonalArchitecture.Domain.Repositories
{
    public interface ISystemParameterRepository : IRepository<SystemParameter>
    {
        /// <summary>
        /// Queries the parameter by its code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<SystemParameter> GetByCode(long code);
    }
}
