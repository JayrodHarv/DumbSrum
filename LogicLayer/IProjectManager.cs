﻿using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer {
    public interface IProjectManager {
        ProjectVM GetProjectVMByProjectID(string projectID);
        List<Project> GetProjectsByUserID(int userID);
        List<Project> GetAllProjects();
        bool AddProject(Project project, int userID);
        bool LeaveProject(int userID, string projectID);
    }
}
