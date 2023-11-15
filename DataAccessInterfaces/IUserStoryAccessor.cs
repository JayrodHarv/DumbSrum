﻿using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces {
    public interface IUserStoryAccessor {
        List<UserStory> SelectUserStoriesByFeatureID(int featureID);
        int CreateFeatureUserStory(int featureID, string person, string action, string reason);
    }
}
