using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBusiness
    {
        public string UserRegisteration(UserRegisterationModel model);

        public Dictionary<string, string> UserLogin(UserLoginModel model);

        public string ForgotPassword(ForgotPasswordModel model);

        public string ResetPassword(string Email, ResetPasswordModel resetModel);

        public List<UserEntity> GetAllUsers();

        public UserEntity UpdateUser(UpdateUserModel model);

        public string DeleteUser(int userId);

        public string UploadUserPhoto(UploadPhotoModel model);

    }
}
