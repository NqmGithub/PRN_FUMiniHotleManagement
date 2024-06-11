using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomTypeService
    {
        private readonly IRoomTypeRepositories _repository;

        public RoomTypeService()
        {
            _repository = new RoomTypeRepositories();
        }

        public List<RoomType> GetAll()
        {
            return _repository.GetRoomTypes();
        }

        public RoomType Get(int id)
        {
            return _repository.GetRoomTypeById(id);
        }

        public void Update(RoomType RoomType)
        {
            _repository.UpdateRoomType(RoomType);
        }

        public void Delete(int id)
        {
            _repository.DeleteRoomType(id);
        }

        public void Add(RoomType RoomType)
        {
            _repository.AddRoomType(RoomType);
        }
    }
}
