using BusinessLayer.Interface;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Controllers
{
  /*  [Route("api/[controller]")]
    [ApiController]*/
    public class CarController : Controller
    {
        private readonly ICarBusiness _carBusiness;

        public CarController(ICarBusiness carBusiness)
        {
            this._carBusiness = carBusiness;
        }

        [HttpPost]
        [Route("AddCar")]
        public IActionResult AddCars([FromForm] CarsModel carsModel)
        {
            var result = _carBusiness.AddCars(carsModel);
            if(result == "Car already exits")
            {
                return this.Ok(new { success = "false", Message = "Car already exits", data = result });
            }
           else if(result != null)
            {
                return this.Ok(new { success = "true", Message = "Car added successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = "false", Message = "Car added unsuccessfull", data = result });
            }
        }

        [HttpGet]
        [Route("GetAllCars")]
        public IActionResult GetAllCars()
        {
            var result = _carBusiness.GetAllCars();

            if(result !=null)
            {
                return this.Ok(new { success = "true", Message = "successfully fetched all cars", data = result });
            }
            else
            {
                return this.Ok(new { success = "false", Message = "Failed to retrieve all cars", data = result });
            }
        }

        [HttpPut]
        [Route("UpdateCar")]
        public IActionResult UpdateCars([FromForm] UpdateCarModel updateModel)
        {
            var result = _carBusiness.UpdateCar(updateModel);

            if (result != null)
            {
                return this.Ok(new { success = "true", Message = "car updated successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = "false", Message = "Failed to update car", data = result });
            }
        }

        [HttpDelete]
        [Route("DeleteCar")]
        public IActionResult DeleteCar(int carId)
        {
            var result = _carBusiness.DeleteCar(carId);

            if (result != null)
            {
                return this.Ok(new { success = "true", Message = "car deleted successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = "false", Message = "Failed to delete car", data = result });
            }
        }

        [HttpGet]
        [Route("CarByPlace")]
        public IActionResult CarByPlaces(string place)
        {
            var result = _carBusiness.CarByPlaces(place);

            if (result != null)
            {
                return this.Ok(new { success = "true", Message = "cars fetched successfully", data = result });
            }
            else
            {
                return this.Ok(new { success = "false", Message = "Failed to fetch cars", data = result });
            }
        }


        [HttpPut]
        [Route("Bookings")]
        public IActionResult BookingDetails(BookingsModel bookingmodel)
        {
            var result = _carBusiness.BookingDetails(bookingmodel);

            if (result != null)
            {
                return this.Ok(new { success = "true", Message = "booking successfull", data = result });
            }
            else
            {
                return this.Ok(new { success = "false", Message = "booking Failed", data = result });
            }
        }

        [HttpGet]
        [Route("GetAllBookings")]
        public IActionResult GetAllBooking()
        {
            var result = _carBusiness.GetAllBooking();

            if (result != null)
            {
                return this.Ok(new { success = "true", Message = " successfully fetched all bookings", data = result });
            }
            else
            {
                return this.Ok(new { success = "false", Message = " Failedto fecth all bookings", data = result });
            }
        }
        

        [HttpPost]
        [Route("Payments")]
        public IActionResult PaymentMethod(PaymentModel model)
        {
            var result = _carBusiness.PaymentMethod(model);

            if (result != null)
            {
                return this.Ok(new { success = "true", Message = "payment successfull", data = result });
            }
            else
            {
                return this.Ok(new { success = "false", Message = "payment Failed", data = result });
            }
        }
        [HttpPost]
        [Route("CarReport")]
        public IActionResult GenerateReport(int carId)
        {
            var result = _carBusiness.GenerateReport(carId);

            if (result != null)
            {
                return this.Ok(new { success = "true", Message = "report generated successfully", data = result });
            }
            else
            {
                return this.Ok(new { success = "false", Message = "report generattion  Failed", data = result });
            }
        }

        [HttpGet]
        [Route("GetAllReports")]
        public IActionResult GetAllReports()
        {
            var result = _carBusiness.GetAllCarReports();
            if(result != null)
            {
                return this.Ok(new { success = "true", Message = "reports fetched successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = "false", Message = "failed to fetch reports", data = result });
            }
        }

        [HttpGet]
        [Route("GetAllPayments")]
        public IActionResult GetAllPayments()
        {
            var result = _carBusiness.GetAllPayments();
            if (result != null)
            {
                return this.Ok(new { success = "true", Message = "payments fetched successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = "false", Message = "failed to fetch payments", data = result });
            }
        }

        [HttpGet]
        [Route("GetBookingID")]
        public IActionResult GetInvoiceByBookingID(string booking)
        {
            var result = _carBusiness.GetInvoiceByBookingID(booking);
            if (result != null)
            {
                return this.Ok(new { success = "true", Message = "bookingID fetched successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = "false", Message = "failed to fetch bookingID", data = result });
            }
        }
        
        [HttpPost]
        [Route("AddOrder")]
        public IActionResult AddOrders(OrderModel model)
        {
           /* var userId = User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            if (userId == null)
            {
                return Unauthorized(); // User not authenticated properly
            }

            int userIdClaim = int.Parse(userId);*/
            var result = _carBusiness.AddOrders(model);
            if (result != null)
            {
                return this.Ok(new { success = "true", Message = "order generated  successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = "false", Message = "failed to generated order", data = result });
            }
        }

        [HttpGet]
        [Route("GetAllOrders")]

        public IActionResult GetAllOrders(int userid)
        {
            var result = _carBusiness.GetAllOrders(userid);
            if (result != null)
            {
                return this.Ok(new { success = "true", Message = "orders fetched  successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = "false", Message = "failed to  orders", data = result });
            }
        }

        [HttpPost]
        [Route("CreateOrderId")]
        public IActionResult CreateOrder(int amount)
        {
            var result = _carBusiness.CreateOrder(amount);
            if(result != null)
            {
                return this.Ok(new { success = "true", Message = "orders created  successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = "false", Message = "failed to create order", data = result });
            }
        }

        
        [HttpPost]
        [Route("NewReport")]
        public IActionResult Generate(DateTime startDate, DateTime endDate)
        {
            var result = _carBusiness.Generate(startDate, endDate);
            if (result != null)
            {
                return this.Ok(new { success = "true", Message = "report generated  successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = "false", Message = "failed to generate report", data = result });
            }
        }


    }
}
