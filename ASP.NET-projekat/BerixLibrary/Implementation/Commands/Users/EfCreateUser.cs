using Application.Commands.Users;
using Application.DTOs.Users;
using AutoMapper;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Password;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Users
{
    public class EfCreateUser : IAddUserCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly UserInsertDTOValidator _validator;

        public int Id => 19;

        public string Name => "Create User";

        public EfCreateUser(IMapper mapper, DBKnjizaraContext dbContext, UserInsertDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(UserInsertDTO request)
        {
            _validator.ValidateAndThrow(request);

            var user = _mapper.Map<User>(request);
            user.Password = PasswordHandler.ecrypt(user.Password);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
