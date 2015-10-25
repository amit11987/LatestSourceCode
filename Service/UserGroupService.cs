using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public class UserGroupService : EntityService<UserGroup>, IUserGroupService
    {
        IUnitOfWork _unitOfWork;
        IUserGroupRepository _UserGroupRepository;

        public UserGroupService(IUnitOfWork unitOfWork, IUserGroupRepository userRepository)
            : base(unitOfWork, userRepository)
        {
            _unitOfWork = unitOfWork;
            _UserGroupRepository = userRepository;
        }

        public UserGroup GetById(long Id)
        {
            return _UserGroupRepository.GetById(Id);
        }

         public IEnumerable<UserGroup> GetByISActive(bool ISActive)
        {
            return _UserGroupRepository.FindBy(x => x.IsActive == ISActive).AsEnumerable();
        }
    }
}
