using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public class SOPService : EntityService<SOP>, ISOPService
    {
        IUnitOfWork _unitOfWork;
        ISOPRepository _SOPRepository;

        public SOPService(IUnitOfWork unitOfWork, ISOPRepository SOPRepository)
            : base(unitOfWork, SOPRepository)
        {
            _unitOfWork = unitOfWork;
            _SOPRepository = SOPRepository;
        }

        public SOP GetById(long Id)
        {
            return _SOPRepository.GetById(Id);
        }
    }
}
