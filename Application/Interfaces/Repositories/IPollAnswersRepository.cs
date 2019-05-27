using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface IPollAnswersRepository
    {
        PollAnswer GetById(int id);
        void Add(PollAnswer pollAnswer);
        void Delete(PollAnswer pollAnswer);
        void Update(PollAnswer pollAnswer);
    }
}
