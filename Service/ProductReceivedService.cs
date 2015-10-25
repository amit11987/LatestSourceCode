using Model;
using Repository;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class ProductReceivedService : EntityService<ProductRecieved>, IProductReceivedService
    {
          IUnitOfWork _unitOfWork;
          IProductRecievedRepository _IProductRecievedRepository;

          public ProductReceivedService(IUnitOfWork unitOfWork, IProductRecievedRepository ProductRepository)
              : base(unitOfWork, ProductRepository)
          {
              _unitOfWork = unitOfWork;
              _IProductRecievedRepository = ProductRepository;
          }

        public ProductRecieved GetById(long Id)
        {
            return _IProductRecievedRepository.GetById(Id);
        }
    }
}
