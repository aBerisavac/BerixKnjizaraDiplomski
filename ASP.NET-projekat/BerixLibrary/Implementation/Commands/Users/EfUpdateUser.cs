using Application.Commands.Users;
using Application.DTOs.Books;
using Application.DTOs.Users;
using Application.Exceptions;
using AutoMapper;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Password;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Users
{
    public class EfUpdateUser : IEditUserCommand
    {

        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly UserUpdateDTOValidator _validator;

        public int Id => 18;

        public string Name => "Update Book";

        public EfUpdateUser(IMapper mapper, DBKnjizaraContext dbContext, UserUpdateDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(UserUpdateDTO request)
        {
            var users = _dbContext.Users
                .Include(user => user.Role);
            var user = users.Select(x => x).Where(x => x.Id == request.Id).FirstOrDefault();

            if (user == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Book));
            }

            _validator.ValidateAndThrow(request);

            var changed = false;

            if (user.FirstName != request.FirstName)
            {
                user.FirstName = request.FirstName;
                changed = true;
            }

            if (user.LastName != request.LastName)
            {
                user.LastName = request.LastName;
                changed = true;
            }

            if (user.Address != request.Address)
            {
                user.Address = request.Address;
                changed = true;
            }

            if (user.Email != request.Email)
            {
                user.Email = request.Email;
                changed = true;
            }

            if (user.Password != request.Password)
            {
                user.Password = request.Password;
                changed = true;
            }

            if (user.RoleId != request.RoleId)
            {
                user.RoleId = request.RoleId;
                changed = true;
            }

            if (changed)
            {
                user.Password = PasswordHandler.ecrypt(user.Password);
                _dbContext.SaveChanges();
            }
        }
    }
}
