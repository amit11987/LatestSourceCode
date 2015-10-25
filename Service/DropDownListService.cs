using Model;
using Repository;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class DropDownListService : EntityService<DropDownList>,IDropDownListService
    {
          IUnitOfWork _unitOfWork;
          IDropdownListRepository _DropdownListRepository;

          public DropDownListService(IUnitOfWork unitOfWork, IDropdownListRepository DropdownListRepository)
              : base(unitOfWork, DropdownListRepository)
          {
              _unitOfWork = unitOfWork;
              _DropdownListRepository = DropdownListRepository;
          }

          public IEnumerable<DropDownList> GetAllByGroupNameANDIsActive(string groupName, bool IsActive)
        {
            return _DropdownListRepository.GetAllByGroupNameANDIsActive(groupName,IsActive);
        }
    }
}
