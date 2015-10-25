using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public class TestService : EntityService<Test>, ITestService
    {
        IUnitOfWork _unitOfWork;
        ITestRepository _TestRepository;

        public TestService(IUnitOfWork unitOfWork, ITestRepository testReository)
            : base(unitOfWork, testReository)
        {
            _unitOfWork = unitOfWork;
            _TestRepository = testReository;
        }

        public Test GetById(long Id)
        {
            return _TestRepository.GetById(Id);
        }

        public void InsertORUpdateORDelete(Test test)
        {
             _TestRepository.InsertORUpdateORDelete(test);
        }

    }
}
