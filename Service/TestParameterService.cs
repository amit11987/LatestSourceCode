using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public class TestParameterService : EntityService<TestParameter>, ITestParameterService
    {
        IUnitOfWork _unitOfWork;
        ITestParameterRepository _TestRepository;

        public TestParameterService(IUnitOfWork unitOfWork, ITestParameterRepository testReository)
            : base(unitOfWork, testReository)
        {
            _unitOfWork = unitOfWork;
            _TestRepository = testReository;
        }

        public void InsertORUpdateORDelete(long testID)
        {
        }

    }
}
