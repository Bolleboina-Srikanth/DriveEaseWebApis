using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IUserRepo
    {
        public string UserRegisteration(UserRegisterationModel model);

        public Dictionary<string, string> UserLogin(UserLoginModel model);

        public abstract string ForgotPassword(ForgotPasswordModel model);

        public string ResetPassword(string Email, ResetPasswordModel resetModel);

        public List<UserEntity> GetAllUsers();

        public UserEntity UpdateUser(UpdateUserModel model);

        public string DeleteUser(int userId);

        public string UploadUserPhoto(UploadPhotoModel model);
    }
}
