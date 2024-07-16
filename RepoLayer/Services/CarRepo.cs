using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Models;
using Razorpay.Api;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Services
{
    public class CarRepo : ICarRepo
    {
        private readonly CarContext _carContext;
        private readonly Cloudinary _cloudinary;

        private readonly string key = "rzp_test_ynlZlonNRZiT0a";
        private readonly string secretKey = "2dsaPSVl7dpP1pmOoidXcHiv";
        private readonly RazorpayClient razorpayClient;

        public CarRepo(CarContext carContext, Cloudinary cloudinary)
        {
            this._carContext = carContext;
            this._cloudinary = cloudinary;
            razorpayClient = new RazorpayClient(key, secretKey);
        }

        public string AddCars(CarsModel carModel)
        {
            if (_carContext.CarsTable.Any(x => x.CarNumber == carModel.carNumber))
            {
                return "Car already exits";
            }
            try
            {
                var upLoadParams = new ImageUploadParams
                {
                    File = new FileDescription(carModel.carPhoto.FileName, carModel.carPhoto.OpenReadStream())
                };
                var upLoadResult = _cloudinary.Upload(upLoadParams);


                CarEntity carTable = new CarEntity();
                carTable.CarName = carModel.carName;
                carTable.CarBrand = carModel.carBrand;
                carTable.CarNumber = carModel.carNumber;
                carTable.Transmission = carModel.transmission;
                carTable.Fuel = carModel.fuel;
                carTable.CarColor = carModel.carColor;
                carTable.Seating = carModel.seating;
                carTable.CarStatus = carModel.carStatus;
                carTable.PriceperHour = carModel.priceperHour;
                carTable.PriceperDay = carModel.priceperDay;
                carTable.CarPhoto = upLoadResult.SecureUrl.AbsoluteUri;
                carTable.State = carModel.state;
                carTable.District = carModel.dictrict;
                carTable.Place = carModel.place;

                _carContext.CarsTable.Add(carTable);
                _carContext.SaveChanges();

                return "Car added successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CarEntity> GetAllCars()
        {
            try
            {
                return _carContext.CarsTable.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CarEntity UpdateCar(UpdateCarModel updateModel)
        {
            var existingCar = _carContext.CarsTable.FirstOrDefault(x => x.CarID == updateModel.carId);
            try
            {
                if (existingCar != null)
                {

                    if (updateModel.carPhoto != null)
                    {
                        var upLoadParams = new ImageUploadParams
                        {
                            File = new FileDescription(updateModel.carPhoto.FileName, updateModel.carPhoto.OpenReadStream())
                        };
                        var upLoadResult = _cloudinary.Upload(upLoadParams);
                        existingCar.CarPhoto = upLoadResult.SecureUrl.AbsoluteUri;
                    }
                    existingCar.CarName = updateModel.carName;
                    existingCar.CarBrand = updateModel.carBrand;
                    existingCar.CarNumber = updateModel.carNumber;
                    existingCar.Transmission = updateModel.transmission;
                    existingCar.Fuel = updateModel.fuel;
                    existingCar.CarColor = updateModel.carColor;
                    existingCar.Seating = updateModel.seating;
                    existingCar.CarStatus = updateModel.carStatus;
                    existingCar.PriceperHour = updateModel.priceperHour;
                    existingCar.PriceperDay = updateModel.priceperDay;
                    existingCar.State = updateModel.state;
                    existingCar.District = updateModel.district;
                    existingCar.Place = updateModel.place;

                    _carContext.CarsTable.Update(existingCar);
                    _carContext.SaveChanges();
                    return existingCar;
                }
                else
                {
                    throw new Exception("car not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteCar(int carId)
        {
            try
            {
                var carExits = _carContext.CarsTable.FirstOrDefault(x => x.CarID == carId);
                if (carExits != null)
                {
                    _carContext.CarsTable.Remove(carExits);
                    _carContext.SaveChanges();
                    return "car deleted successfully";
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CarEntity> CarByPlaces(string place)
        {
            var currentDate = DateTime.Now;
            var checkReturnDate = currentDate.AddDays(2);
            var carRented = _carContext.BookingsTable.FirstOrDefault(x => x.RentDate.Date == currentDate.Date);
            var carReturn = _carContext.BookingsTable.Where(x => x.ReturnDate.Date < checkReturnDate.Date).ToList();
            if (carRented != null)
            {
                var id = carRented.CarId;
                var cardata = _carContext.CarsTable.FirstOrDefault(x => x.CarID == id);
                cardata.CarStatus = "NotAvailable";

                _carContext.CarsTable.Update(cardata);
                _carContext.SaveChanges();
            }
            /* if (carReturn != null)
             {
                 foreach(var rental in carReturn)
                 {
                     var id = rental.CarId;
                     var cardata = _carContext.CarsTable.FirstOrDefault(x => x.CarID == id);
                     if (cardata != null)
                     {
                         cardata.CarStatus = "Available";
                         _carContext.CarsTable.Update(cardata);
                         _carContext.SaveChanges();
                     }
                 }

             }*/
            try
            {
                var placeExits = _carContext.CarsTable.Where(x => x.Place == place).ToList();
                return placeExits;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BookingEntity BookingDetails(BookingsModel bookingmodel)
        {
            try
            {
                var carExist = _carContext.CarsTable.FirstOrDefault(car => car.CarID == bookingmodel.carId);
                var iscarBooked = _carContext.BookingsTable.FirstOrDefault(x => x.CarId == bookingmodel.carId && x.RentDate == bookingmodel.rentDate);
                if(iscarBooked != null)
                {
                    return null;
                }
                if (carExist != null)
                {
                    BookingEntity bookingTable = new BookingEntity();
                    bookingTable.BookingId = GeneratingBookingId();
                    bookingTable.CarId = bookingmodel.carId;
                    bookingTable.CarBrand = bookingmodel.CarBrand;
                    bookingTable.CarName = bookingmodel.CarName;
                    bookingTable.CustomerId = bookingmodel.customerId;
                    bookingTable.Name = bookingmodel.name;
                    bookingTable.Email = bookingmodel.email;
                    bookingTable.PhoneNumber = bookingmodel.phoneNumber;
                    bookingTable.RentDate = bookingmodel.rentDate;
                    bookingTable.ReturnDate = bookingmodel.returnDate;

                    _carContext.BookingsTable.Add(bookingTable);
                    _carContext.SaveChanges();

                    return bookingTable;

                }
                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string GeneratingBookingId()
        {
            Random randomId = new Random();
            var num = randomId.Next(1000, 10000);
            return String.Concat("BKID", num.ToString());
        }

        public List<BookingEntity> GetAllBooking()
        {
            try
            {
                return _carContext.BookingsTable.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PaymentEntity PaymentMethod(PaymentModel model)
        {
            var isBKIDExist = _carContext.BookingsTable.FirstOrDefault(x => x.BookingId == model.BookingId);
            try
            {
                if (isBKIDExist != null)
                {
                    PaymentEntity paymentTable = new PaymentEntity();
                    paymentTable.paymentId = GeneratePaymentID();
                    paymentTable.BookingId = model.BookingId;
                    paymentTable.CarId = model.CarId;
                    paymentTable.UserId = model.UserId;
                    paymentTable.paymentType = model.paymentType;
                    paymentTable.paymmentDate = model.paymmentDate;
                    paymentTable.Amount = model.Amount;

                    _carContext.PaymentsTable.Add(paymentTable);
                    _carContext.SaveChanges();

                    return paymentTable;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string GeneratePaymentID()
        {
            Random randomId = new Random();
            var num = randomId.Next(1000, 10000);
            return String.Concat("PYID", num.ToString());
        }


        public string GenerateReport(int carId)
        {
            var currentDate = DateTime.Now;
            var startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var nextMonthStartDate = startDate.AddMonths(1);
            var nextMonthEndDate = nextMonthStartDate.AddMonths(1).AddDays(-1);

            var Carexist = _carContext.ReportTable.FirstOrDefault(x => x.CarId == carId);
            var CarExistInBooking = _carContext.BookingsTable.Where(x => x.CarId == carId && x.RentDate >= startDate && x.RentDate <= endDate).ToList();
            var nextMonthCarExistInBooking = _carContext.BookingsTable.Where(x => x.CarId == carId && x.RentDate >= nextMonthStartDate && x.RentDate <= nextMonthEndDate).ToList();
            if (Carexist != null)
            {
                var nextMonthBookingCount = _carContext.BookingsTable.Count(x => x.CarId == carId && x.RentDate >= nextMonthStartDate && x.ReturnDate <= nextMonthEndDate);
                if (nextMonthBookingCount > 0)
                {
                    var nextMonthReport = _carContext.ReportTable.FirstOrDefault(x => x.CarId == carId && x.FromDate == nextMonthStartDate && x.EndDate == nextMonthEndDate);
                    if (nextMonthReport != null)
                    {
                        var newcount = nextMonthBookingCount;
                        nextMonthReport.NoOfBookings = newcount++;
                        _carContext.ReportTable.Update(nextMonthReport);
                        _carContext.SaveChanges();
                        return "car report updated";
                    }
                    else
                    {
                        ReportEntity newReport = new ReportEntity();
                        newReport.CarId = carId;
                        newReport.CarBrand = Carexist.CarBrand;
                        newReport.CarName = Carexist.CarName;
                        newReport.FromDate = nextMonthStartDate;
                        newReport.EndDate = nextMonthEndDate;
                        newReport.NoOfBookings = nextMonthBookingCount;
                        newReport.PresentDate = currentDate;
                        _carContext.ReportTable.Add(newReport);
                        _carContext.SaveChanges();

                        return "report generated";
                    }
                }
                var count = Carexist.NoOfBookings;
                Carexist.NoOfBookings = ++count;
                Carexist.PresentDate = currentDate;
                _carContext.ReportTable.Update(Carexist);
                _carContext.SaveChanges();
                return "car report updated";
            }
            else
            {
                if (CarExistInBooking.Any())
                {
                    ReportEntity newReport = new ReportEntity();
                    newReport.CarId = carId;
                    newReport.CarBrand = CarExistInBooking.First().CarBrand;
                    newReport.CarName = CarExistInBooking.First().CarName;
                    newReport.FromDate = startDate;
                    newReport.EndDate = endDate;
                    newReport.NoOfBookings = CarExistInBooking.Count;
                    newReport.PresentDate = currentDate;
                    _carContext.ReportTable.Add(newReport);
                    _carContext.SaveChanges();

                    return "report generated";
                }

                if (nextMonthCarExistInBooking.Any())
                {
                    ReportEntity newReport = new ReportEntity();
                    newReport.CarId = carId;
                    newReport.CarBrand = nextMonthCarExistInBooking.First().CarBrand;
                    newReport.CarName = nextMonthCarExistInBooking.First().CarName;
                    newReport.FromDate = nextMonthStartDate;
                    newReport.EndDate = nextMonthEndDate;
                    newReport.NoOfBookings = nextMonthCarExistInBooking.Count;
                    newReport.PresentDate = currentDate;
                    _carContext.ReportTable.Add(newReport);
                    _carContext.SaveChanges();
                    return "report generated";
                }
            }

            return "data not found";

        }

        public List<ReportEntity> GetAllCarReports()
        {
            try
            {
                return _carContext.ReportTable.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PaymentEntity> GetAllPayments()
        {
            try
            {
                return _carContext.PaymentsTable.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderEntity GetInvoiceByBookingID(string booking)
        {
            try
            {
                var result = _carContext.OrdersTable.FirstOrDefault(x => x.BookingId == booking);
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderEntity AddOrders(OrderModel model)
        {
            var userExist = _carContext.UserTable.FirstOrDefault(x => x.UserID == model.UserID);
            try
            {
                if (userExist != null)
                {
                    OrderEntity orderTable = new OrderEntity();
                    orderTable.UserID = model.UserID;
                    orderTable.BookingId = model.BookingId;
                    orderTable.Name = model.Name;
                    orderTable.PhoneNumber = model.PhoneNumber;
                    orderTable.Email = model.Email;
                    orderTable.CarPhoto = model.CarPhoto;
                    orderTable.CarBrand = model.CarBrand;
                    orderTable.CarName = model.CarName;
                    orderTable.Transmission = model.Transmission;
                    orderTable.Fuel = model.Fuel;
                    orderTable.CarColor = model.CarColor;
                    orderTable.Seating = model.Seating;
                    orderTable.RentDate = model.RentDate;
                    orderTable.ReturnDate = model.ReturnDate;
                    orderTable.BookingTime = model.BookingTime;
                    orderTable.Amount = model.Amount;
                    _carContext.OrdersTable.Add(orderTable);
                    _carContext.SaveChanges();
                    return orderTable;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderEntity> GetAllOrders(int userId)
        {
            try
            {
                return _carContext.OrdersTable.Where(x => x.UserID == userId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  string CreateOrder(int amount)
        {
            try
            {
                // Create order input parameters
                Dictionary<string, object> input = new Dictionary<string, object>();
                input.Add("amount", amount); // Transaction amount in paisa (e.g., 100 for 1 INR)
                input.Add("currency", "INR");
                input.Add("receipt", "12121");

                // Create the order
                Razorpay.Api.Order order =  razorpayClient.Order.Create(input);

                // Extract order ID from the response
                string orderId = order["id"].ToString();

                return orderId;
            }
            catch (Exception ex)
            {
                // Handle any errors and return null or throw an exception
                Console.WriteLine($"Failed to create order: {ex.Message}");
                return null;
            }


        }

        public List<Dictionary<string, object>> Generate(DateTime startDate, DateTime endDate)
        {
            try
            {
                var reportData = _carContext.BookingsTable
                    .Where(b => b.RentDate >= startDate && b.RentDate <= endDate)
                    .Join(_carContext.CarsTable,
                    booking => booking.CarId,
                    car => car.CarID,
                    (booking, car)=> new {CarId= car.CarID, CarBrand = car.CarBrand, carName = car.CarName, carcolor= car.CarColor, transmission = car.Transmission, fuel = car.Fuel, seating = car.Seating  })
                    .GroupBy(x  => new {x.CarId, x.CarBrand, x.carName, x.transmission, x.fuel, x.carcolor, x.seating})
                    .Select(g => new Dictionary<string, object>
                    {
                        {"carid", g.Key.CarId },
                        {"carbrand",  g.Key.CarBrand },
                        {"carname",  g.Key.carName },
                        {"transmission",  g.Key.transmission },
                        {"carcolor",  g.Key.carcolor },
                        {"fuel", g.Key.fuel },
                        {"seating", g.Key.seating },
                        {"fromDate", startDate },
                        {"endDate", endDate },
                        {"noOfbookings", g.Count() }
                    })
                    .ToList();
                return reportData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

      
    }
}
