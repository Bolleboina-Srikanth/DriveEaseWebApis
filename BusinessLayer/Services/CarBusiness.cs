using BusinessLayer.Interface;
using CommonLayer.Models;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class CarBusiness : ICarBusiness
    {
        private readonly ICarRepo _carRepo;

        public CarBusiness(ICarRepo carRepo)
        {
            this._carRepo = carRepo;
        }
        public string AddCars(CarsModel carModel)
        {
            try
            {
                return _carRepo.AddCars(carModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<CarEntity> GetAllCars()
        {
            try
            {
                return _carRepo.GetAllCars();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CarEntity UpdateCar(UpdateCarModel updateModel)
        {
            try
            {
                return _carRepo.UpdateCar(updateModel);
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
                return _carRepo.DeleteCar(carId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CarEntity> CarByPlaces(string place)
        {
            try
            {
                return _carRepo.CarByPlaces(place);
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
                return _carRepo.BookingDetails(bookingmodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BookingEntity> GetAllBooking()
        {
            try
            {
                return _carRepo.GetAllBooking();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PaymentEntity PaymentMethod(PaymentModel model)
        {
            try
            {
                return _carRepo.PaymentMethod(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GenerateReport(int carId)
        {
            try
            {
                return _carRepo.GenerateReport(carId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<ReportEntity> GetAllCarReports()
        {
            try
            {
                return _carRepo.GetAllCarReports();
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
                return _carRepo.GetAllPayments();
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
                return _carRepo.GetInvoiceByBookingID(booking);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderEntity AddOrders(OrderModel model)
        {
            try
            {
                return _carRepo.AddOrders(model);
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
                return _carRepo.GetAllOrders(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CreateOrder(int amount)
        {
            try
            {
                return _carRepo.CreateOrder(amount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Dictionary<string, object>> Generate(DateTime startDate, DateTime endDate)
        {
            try
            {
                return _carRepo.Generate(startDate, endDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
