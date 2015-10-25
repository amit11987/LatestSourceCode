using Model;
using Repository;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
  
    public class SampleTestService : EntityService<SampleTest>, ISampleTestService
    {
        IUnitOfWork _unitOfWork;
        ISampleTestRepository _SampleTestRepository;

        public SampleTestService(IUnitOfWork unitOfWork, ISampleTestRepository SampleTestRepository)
            : base(unitOfWork, SampleTestRepository )
        {
            _unitOfWork = unitOfWork;
            _SampleTestRepository = SampleTestRepository;
        }

        public SampleTest GetById(long Id)
        {
            return _SampleTestRepository.GetById(Id);
        }
    }
}
