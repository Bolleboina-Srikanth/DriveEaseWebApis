using BusinessLayer.Interface;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            this._userBusiness = userBusiness;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Registeration(UserRegisterationModel model)
        {
            var result = _userBusiness.UserRegisteration(model);
            if (result == "successfully registered")
            {
                return this.Ok(new { success = true, Message = "Registeration successfull", data = result });
            }
            else if(result == "You already have an account")
            {
                return this.Ok(new { success = false, Message = "Registeration failed", data = result });
            }
            else
            {
                return this.BadRequest(new { Success = false, Message = "Registeration unsuccessfull", data = result });
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserLoginModel model)
        {
            var result = _userBusiness.UserLogin(model);
            if (result != null)
            {
                return this.Ok(new { success = true, Message = "Login successfull", data = result });
            }
            else
            {
                return this.BadRequest(new { Success = false, Message = "invalid email or password", Data = result });
            }
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordModel model)
        {
            var result = _userBusiness.ForgotPassword(model);
            if(result != null)
            {
                return this.Ok(new { success = true, Message = "Token sent Successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Invalid credentials", data = result });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(string NewPassword, ResetPasswordModel resetModel)
        {
            var email = User.Claims.FirstOrDefault(s => s.Type == "Email").Value;
           
            if (email != null)
            {
                var result = _userBusiness.ResetPassword(email, resetModel);
                if (result == "password reset successful")
                {
                    return Ok(new { success = true, message = "Reset Password  Successfully", result=result });
                }
                else
                {
                    return this.Ok(new { success = false, message = "Invalid Credentials Reset Password  UnSuccessfull", result
                    =result});
                }

            }
            return null;
        }

        [HttpGet]
        [Route("GetAllUSers")]
        public IActionResult GetAllUsers()
        {
            var result = _userBusiness.GetAllUsers();
            if (result != null)
            {
                
               return Ok(new { success = true, message = "Users fetched successfuly", data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Failed to retrive users", data = result});
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(UpdateUserModel model)
        {
            var result = _userBusiness.UpdateUser(model);

            if (result != null)
            {
                return this.Ok(new { success = "true", Message = "user updated successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = "false", Message = "Failed to update user details", data = result });
            }
        }

        [HttpDelete]
        [Route("deleteUser")]
        public IActionResult DeleteUser(int userId)
        {
            var result = _userBusiness.DeleteUser(userId);

            if (result != null)
            {
                return this.Ok(new { success = "true", Message = "user delete successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = "false", Message = "Failed to delete user", data = result });
            }
        }

        [HttpPut]
        [Route("UploadUserPhoto")]
        public IActionResult UploadUserPhoto([FromForm] UploadPhotoModel model)
        {
            var result = _userBusiness.UploadUserPhoto(model);

            if (result != null)
            {
                return this.Ok(new { success = "true", Message = "user uploaded successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = "false", Message = "Failed to upload photo user", data = result });
            }
        }


    }
}
