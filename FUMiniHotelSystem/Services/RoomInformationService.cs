using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomInformationService
    {
        private readonly IRoomInformationRepositories _repository;

        public RoomInformationService()
        {
            _repository = new RoomInformationRepositories();
        }

        public List<RoomInformation> GetAll()
        {
            return _repository.GetRoomInformations();
        }

        public RoomInformation Get(int id)
        {
            return _repository.GetRoomInformationById(id);
        }

        public void Update(RoomInformation RoomInformation)
        {
            _repository.UpdateRoomInformation(RoomInformation);
        }

        public void Delete(int id)
        {
            _repository.DeleteRoomInformation(id);
        }

        public void Add(RoomInformation RoomInformation)
        {
            _repository.AddRoomInformation(RoomInformation);
        }
    }
}
