﻿using ppedv.Rent_A_Wheel.Model.Domain;

namespace ppedv.Rent_A_Wheel.Model.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Car> CarRepository { get; }
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Rent> RentRepository { get; }


        void SaveAll();
    }
}
