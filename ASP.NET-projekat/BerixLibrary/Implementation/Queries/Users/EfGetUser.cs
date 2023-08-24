using Application.DTOs.Books;
using Application.DTOs.Users;
using Application.Exceptions;
using Application.Queries.Users;
using AutoMapper;
using Domain;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Users
{
    public class EfGetUser: IGetUserQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper _mapper;

        public int Id => 39;

        public string Name => "Get Book";

        public EfGetUser(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public UserDTO Execute(int id)
        {
            var users = _dbContext.Users
                .Include(user => user.Role);
            var user = users.Select(x => x).Where(x => x.Id == id).FirstOrDefault();

            if (user == null)
            {
                throw new EntityNotFoundException(id, typeof(User));
            }

            var response = _mapper.Map<UserDTO>(user);

            return response;
        }
    }
}
