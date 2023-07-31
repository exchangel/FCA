using FCA.Business.Dtos.SessionDtos;
using FCA.Business.Services;
using FCA.Data.Entities;
using FCA.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Business.Managers
{
    public class SessionManager : IPersonalSessionService
    {
        private readonly IRepository<PersonalSessionEntity> _sessionRepository;

        public SessionManager(IRepository<PersonalSessionEntity> sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        //DI


        public void AddSession(AddSessionDto addSessionDto)
        {
            var sessionEntity = new PersonalSessionEntity()
            {
                Note = addSessionDto.Note,
                CustomerId = addSessionDto.CustomerId,
                UserId = addSessionDto.UserId,
                SessionDate = addSessionDto.SessionDate,
                Price = addSessionDto.Price,
                SessionName = addSessionDto.SessionName,

            };

            _sessionRepository.Add(sessionEntity);
        }

        public void DeleteSession(int id)
        {
            _sessionRepository.Delete(id);
        }

        public void EditSession(EditSessionDto editSessionDto)
        {
            var sessionEntity = _sessionRepository.GetById(editSessionDto.Id);

            sessionEntity.Note = editSessionDto.Note;
            sessionEntity.Price = editSessionDto.Price;
            sessionEntity.CustomerId = editSessionDto.CustomerId;
            sessionEntity.UserId = editSessionDto.UserId;
            sessionEntity.SessionDate = editSessionDto.SessionDate;
            sessionEntity.SessionName = editSessionDto.SessionName;

            _sessionRepository.Update(sessionEntity);
        }

        public EditSessionDto GetSessionById(int id)
        {
            var sessionEntity = _sessionRepository.GetById(id);

            var editSessionDto = new EditSessionDto()
            {
                Id = sessionEntity.Id,
                SessionName= sessionEntity.SessionName,
                SessionDate= sessionEntity.SessionDate,
                UserId = sessionEntity.UserId,
                CustomerId = sessionEntity.CustomerId,
                Note = sessionEntity.Note,
                Price = sessionEntity.Price 
            };

            return editSessionDto;
        }

        public List<ListSessionDto> GetSessions()
        {
            var sessionEntities = _sessionRepository.GetAll().OrderBy(x => x.User.FirstName).ThenBy(x => x.Customer.FirstName);

            var sessionDtoList = sessionEntities.Select(x => new ListSessionDto
            {
                Id = x.Id,
                Price = x.Price,
                Note = x.Note,
                SessionDate = x.SessionDate,
                CustomerId = x.CustomerId,
                UserId = x.UserId,
                CustomerName = (x.Customer.FirstName + " " + x.Customer.LastName),
                UserName = x.User.FirstName,
                SessionName = x.SessionName

            }).ToList();

            return sessionDtoList;
        }


        public List<ListSessionDto> GetSessionsByUserId(int? userId)
        {
            if (userId.HasValue)
            {

                var sessionEntities = _sessionRepository.GetAll(x => x.UserId == userId).OrderBy(x => x.CustomerId);

                var sessionDtos = sessionEntities.Select(x => new ListSessionDto
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    UserId = x.UserId,
                    CustomerName = (x.Customer.FirstName + " " + x.Customer.LastName),
                    UserName = x.User.FirstName,
                    SessionName = x.SessionName,
                    Note = x.Note,
                    Price = x.Price,
                    SessionDate = x.SessionDate

                }).ToList();

                return sessionDtos;
            }
            else
            {
                return GetSessions();
            }

        }

    }
}
