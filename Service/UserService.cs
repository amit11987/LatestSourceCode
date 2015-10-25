using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public class UserService : EntityService<User>, IUserService
    {
        IUnitOfWork _unitOfWork;
        IUserRepository _UserRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository UserRepository)
            : base(unitOfWork, UserRepository)
        {
            _unitOfWork = unitOfWork;
            _UserRepository = UserRepository;
        }

        public User GetById(long Id)
        {
            return _UserRepository.GetById(Id);
        }

        public IEnumerable<User> GetByISActive(bool IsActive)
        {
            return _UserRepository.FindBy(x => x.IsActive == IsActive);
        }
    }
}
