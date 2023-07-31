using FCA.Business.Dtos.SessionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Business.Services
{
    public interface IPersonalSessionService
    {
        void AddSession(AddSessionDto addSessionDto);

        List<ListSessionDto> GetSessions();

        EditSessionDto GetSessionById(int id);

        void EditSession(EditSessionDto editSessionDto);

        void DeleteSession(int id);

        List<ListSessionDto> GetSessionsByUserId(int? userId);

       
    }
}
