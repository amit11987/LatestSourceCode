using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Interface;
namespace Service
{
    public class TestAllocationService : EntityService<TestAllocation>,ITestAllocationService
    {
        IUnitOfWork _unitOfWork;
        ITestAllocationRepository testAllocationRepository;

        public TestAllocationService(IUnitOfWork unitOfWork, ITestAllocationRepository testAllocationRepository)
            : base(unitOfWork, testAllocationRepository)
        {
            _unitOfWork = unitOfWork;
            this.testAllocationRepository = testAllocationRepository;
        }

        public TestAllocation GetById(long Id)
        {
            return testAllocationRepository.GetById(Id);
        }

        public void InsertORUpdateORDelete(List<TestAllocation> lstTestAllocation)
        {
            testAllocationRepository.InsertORUpdateORDelete(lstTestAllocation);
        }
       

    }
}
