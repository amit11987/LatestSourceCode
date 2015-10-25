using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public class ProductService : EntityService<Product>, IProductService
    {
        IUnitOfWork _unitOfWork;
        IProductRepository _ProductRepository;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository personRepository)
            : base(unitOfWork, personRepository)
        {
            _unitOfWork = unitOfWork;
            _ProductRepository = personRepository;
        }

        public Product GetById(long Id)
        {
            return _ProductRepository.GetById(Id);
        }
    }
}
