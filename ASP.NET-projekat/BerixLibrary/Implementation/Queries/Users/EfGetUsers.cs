using Application;
using Application.DTOs.Books;
using Application.DTOs.Users;
using Application.Queries.Users;
using AutoMapper;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Users
{
    public  class EfGetUsers: IGetUsersQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper _mapper;
        public int Id => 38;

        public string Name => "Get Books";

        public EfGetUsers(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<UserDTO> Execute(string searchTerm)
        {
            var query = _dbContext.Users
                .Include(user => user.Role)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => (x.FirstName + " " + x.LastName).Contains(searchTerm));
            }
            else
            {

            }

            return query.Select(x => _mapper.Map<UserDTO>(x));
        }
    }
}
