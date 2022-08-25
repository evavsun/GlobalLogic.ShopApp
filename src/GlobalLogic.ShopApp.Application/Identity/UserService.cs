﻿using Microsoft.AspNetCore.Identity;
using GlobalLogic.ShopApp.Core.AggregatesModel.ApplicationUserAggregate;
using GlobalLogic.ShopApp.Core.Exceptions;
using GlobalLogic.ShopApp.Core.Interfaces;

namespace GlobalLogic.ShopApp.Application.Identity
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        private readonly ITokenProvider _tokenProvider;

        public UserService(IUnitOfWork unitOfWork, IPasswordHasher<ApplicationUser> passwordHasher, ITokenProvider tokenProvider)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _tokenProvider = tokenProvider;
        }

        public async Task<string> LoginAsync(string login, string password)
        {
            var dbUser = await _unitOfWork.ApplicationUsers.GetAsync(u => u.Login == login);
            if (dbUser == null)
                throw new UserDoesNotExistException();
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(dbUser, dbUser.Password, password);
            if (passwordVerificationResult == PasswordVerificationResult.Success)
                return _tokenProvider.GetToken(dbUser);
            throw new LoginOrPasswordIncorrectException();
        }

        public async Task RegisterAsync(string login, string password)
        {
            var dbUser = await _unitOfWork.ApplicationUsers.GetAsync(u => u.Login == login);
            if (dbUser is not null)
                throw new UserAlreadyExistsException();
            var newUser = new ApplicationUser();
            var hashedPassword = _passwordHasher.HashPassword(newUser, password);
            newUser.SetLogin(login);
            newUser.SetPassword(hashedPassword);
            await _unitOfWork.ApplicationUsers.AddAsync(newUser);
            await _unitOfWork.SaveAsync();
        }
    }
}
