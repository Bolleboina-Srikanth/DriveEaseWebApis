using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepoLayer.Services
{
    public class UserRepo : IUserRepo
    {
        private readonly CarContext _carContext;
        private readonly IConfiguration _configuration;
        private readonly Cloudinary _cloudinary;

        public UserRepo(CarContext carContext, IConfiguration configuration, Cloudinary cloudinary)
        {
            this._carContext = carContext;
            this._configuration = configuration;
            this._cloudinary = cloudinary;
        }
        public string UserRegisteration(UserRegisterationModel model)
        {
            if(_carContext.UserTable.Any(u => u.Email == model.email) || _carContext.UserTable.Any(u => u.PhoneNumber == model.phoneNumber))
            {
                return "You already have an account";
            }
            try
            {
                
               UserEntity userTable = new UserEntity();
                userTable.Name = model.name;
                userTable.PhoneNumber = model.phoneNumber;
                userTable.State = model.state;
                userTable.City = model.city;
                userTable.Address = model.address;
                userTable.Role = model.role;
                userTable.Status = model.status;
                userTable.LicenseNumber = model.licenseNumber;
                userTable.Email = model.email;
                userTable.Password = model.password;

                _carContext.UserTable.Add(userTable);
                _carContext.SaveChanges();

                if(userTable != null)
                {
                    return "successfully registered";
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
        public Dictionary<string, string>  UserLogin(UserLoginModel model)
        {
            try
            {
                var credentials = _carContext.UserTable.FirstOrDefault(x => x.Email == model.email && x.Password == model.password);
                if( credentials != null)
                {
                    var token = GenerateJwtToken(credentials.Email, credentials.UserID);
                    var data = new Dictionary<string, string>
                    {
                        {"token", token },
                        {"userId", credentials.UserID.ToString()},
                        {"name", credentials.Name},
                        {"email", credentials.Email},
                        {"phonenumber", credentials.PhoneNumber},
                        {"address", credentials.Address},
                        {"role", credentials.Role},
                        {"UserPhoto", credentials.UserPhoto}
                    };
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GenerateJwtToken(string Email, long UserId)
        {
            var claims = new List<Claim>
                {
                new Claim("UserId", UserId.ToString()),
                new Claim("Email" , Email)
                };
            // You can add more claims as needed, such as roles or custom claims.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["JwtSettings:Issuer"], _configuration["JwtSettings:Audience"], claims, DateTime.Now, DateTime.Now.AddHours(12), creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public string ForgotPassword(ForgotPasswordModel model)
        {
            try
            {
                var EmailValidity = _carContext.UserTable.FirstOrDefault(x => x.Email == model.email);
                if(EmailValidity != null)
                {
                    var token = GenerateJwtToken(EmailValidity.Email, EmailValidity.UserID);
                    return token;
                }
                else
                {
                    return null;
                }
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
                var oldPassword = _carContext.UserTable.FirstOrDefault(x => x.Email == Email);
                if (oldPassword.Password != resetModel.NewPassword)
                {
                    if (resetModel.NewPassword == resetModel.ConfirmPassword)
                    {
                        var emailValidity = _carContext.UserTable.FirstOrDefault(x => x.Email == Email);
                        if (emailValidity != null)
                        {
                            emailValidity.Password = resetModel.NewPassword;
                            _carContext.UserTable.Update(emailValidity);
                            _carContext.SaveChanges();
                        }
                        return "password reset successful";

                    }
                    else
                    {
                        return "password does not match";
                    }
                }
                else
                {
                    return "New password cannot be the same as old password";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public List<UserEntity> GetAllUsers()
        {
            try
            {
                return _carContext.UserTable.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public UserEntity UpdateUser(UpdateUserModel model)
        {
            var existingUser = _carContext.UserTable.FirstOrDefault(x => x.UserID == model.userId);
            try
            {
                if(existingUser != null)
                {
                    existingUser.Name = model.name;
                    existingUser.PhoneNumber = model.phoneNumber;
                    existingUser.State = model.state;
                    existingUser.City = model.city;
                    existingUser.Address = model.address;
                    existingUser.Role = model.role;
                    existingUser.Status = model.status;
                    existingUser.LicenseNumber = model.licenseNumber;
                    existingUser.Email = model.email;
                    existingUser.Password = model.password;

                    _carContext.UserTable.Update(existingUser);
                    _carContext.SaveChanges();
                    return existingUser;

                }
                else
                {
                    throw new Exception("User not found");
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteUser(int userId)
        {
            try
            {
                var userExits = _carContext.UserTable.FirstOrDefault(x => x.UserID == userId);
                if (userExits != null)
                {
                    _carContext.UserTable.Remove(userExits);
                    _carContext.SaveChanges();
                    return "User deleted successfully";
                }
                return "User doest not exist";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UploadUserPhoto(UploadPhotoModel model)
        {
            var id = _carContext.UserTable.FirstOrDefault(x => x.UserID == model.userid);
            try
            {
                if (id != null)
                {
                    var upLoadParams = new ImageUploadParams
                    {
                        File = new FileDescription(model.image.FileName, model.image.OpenReadStream())
                    };

                    var upLoadResult = _cloudinary.Upload(upLoadParams);
                    id.UserPhoto = upLoadResult.SecureUrl.AbsoluteUri;

                    _carContext.UserTable.Update(id);
                    _carContext.SaveChanges();
                    var data = _carContext.UserTable.FirstOrDefault(x => x.UserID == model.userid);
                    var result = data.UserPhoto;

                    return  result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
