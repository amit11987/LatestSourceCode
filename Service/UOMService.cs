using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public class UOMService : EntityService<UOM>, IUOMService
    {
        IUnitOfWork _unitOfWork;
        IUOMRepository _UOMRepository;

        public UOMService(IUnitOfWork unitOfWork, IUOMRepository UOMRepository)
            : base(unitOfWork, UOMRepository)
        {
            _unitOfWork = unitOfWork;
            _UOMRepository = UOMRepository;
        }

        public UOM GetById(long UOMID)
        {
            return _UOMRepository.GetById(UOMID);
        }

        public IEnumerable<UOM> GetAllByIsStandardUOM(bool ISStandardUOM)
        {
            return _UOMRepository.GetAllByIsStandardUOM(ISStandardUOM);
           
        }
       
    }
}
