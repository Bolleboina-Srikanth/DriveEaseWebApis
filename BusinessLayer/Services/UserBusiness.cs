using BusinessLayer.Interface;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.Services;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class UserBusiness : IUserBusiness
    {

        private readonly IUserRepo _userRepo;

        public UserBusiness(IUserRepo userRepo)
        {
            this._userRepo = userRepo;
        }

        public string UserRegisteration(UserRegisterationModel model)
        {
            try
            {
                return _userRepo.UserRegisteration(model);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, string> UserLogin(UserLoginModel model)
        {
            try
            {
                return _userRepo.UserLogin(model);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string ForgotPassword(ForgotPasswordModel model)
        {
            try
            {
                return _userRepo.ForgotPassword(model);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public string ResetPassword(string Email, ResetPasswordModel resetModel)
        {
            try
            {
                return _userRepo.ResetPassword(Email, resetModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserEntity> GetAllUsers()
        {
            try
            {
                return _userRepo.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserEntity UpdateUser(UpdateUserModel model)
        {
            try
            {
                return _userRepo.UpdateUser(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteUser(int userId)
        {
            try
            {
                return _userRepo.DeleteUser(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UploadUserPhoto(UploadPhotoModel model)
        {

            try
            {
                return _userRepo.UploadUserPhoto(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
