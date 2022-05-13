using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Interfaces
{
    public interface IMailService
    {
        void SendEmail(string To, string ConfirmLink, string Subject, string PartOfBody);
    }
}
