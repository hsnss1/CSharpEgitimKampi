﻿using CSharpEgitimKampi.BusinessLayer.Abstract;
using CSharpEgitimKampi.DataAccessLayer.Abstract;
using CSharpEgitimKampi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public void TDelete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public List<Customer> TGetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer TGetById(int id)
        {
           return _customerDal.GetById(id); 
        }

        public void TInsert(Customer entity)
        {
            if (entity.CustomerName != "" && entity.CustomerName.Length > 3 && entity.CustomerCity != null && entity.CustomerSurname != "" && entity.CustomerName.Length <= 30)

            {
               _customerDal.Insert(entity);
            }
            else
            {
                // hata mesajı ver
            }
        }

        public void TUpdate(Customer entity)
        {
            if (entity.CustomerId != 0 && entity.CustomerCity.Length >= 3)
            {
                _customerDal.Update(entity);
            }
            else
            {
                // hata mesajı ver
            }

        }
    }
}
