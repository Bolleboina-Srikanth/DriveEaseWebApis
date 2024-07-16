using CommonLayer.Models;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface ICarRepo
    {
        public string AddCars(CarsModel carModel);

        public List<CarEntity> GetAllCars();

        public CarEntity UpdateCar(UpdateCarModel updateModel);

        public string DeleteCar(int carId);

        public List<CarEntity> CarByPlaces(string place);

        public BookingEntity BookingDetails(BookingsModel bookingmodel);

        public List<BookingEntity> GetAllBooking();

        public PaymentEntity PaymentMethod(PaymentModel model);

        public string GenerateReport(int carId);

        public List<ReportEntity> GetAllCarReports();

        public List<PaymentEntity> GetAllPayments();

        public OrderEntity GetInvoiceByBookingID(string booking);

        public OrderEntity AddOrders(OrderModel model);

        public List<OrderEntity> GetAllOrders(int userId);

        public string CreateOrder(int amount);

        public List<Dictionary<string, object>> Generate(DateTime startDate, DateTime endDate);
    }
}
