using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Services.Data
{
    public interface IPictureService
    {
        T GetById<T>(string id);
    }
}
