﻿namespace PetsFriends.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFriendService
    {
        IEnumerable<T> GetAllUsers<T>(string id);

        Task<IEnumerable<T>> GetAllUsersFriend<T>(string id);
    }
}
