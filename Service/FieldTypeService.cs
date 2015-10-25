using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public class FieldTypeService : EntityService<FieldType>, IFieldTypeService
    {
        IUnitOfWork _unitOfWork;
        IFieldTypeRepository _FieldTypeRepository;

        public FieldTypeService(IUnitOfWork unitOfWork, IFieldTypeRepository fieldTypeRepository)
            : base(unitOfWork, fieldTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _FieldTypeRepository = fieldTypeRepository;
        }

        public IEnumerable<FieldType> GetAllByIsActive(bool IsActive)
        {
            return _FieldTypeRepository.GetAllByIsActive(IsActive);
        }
       
    }
}
