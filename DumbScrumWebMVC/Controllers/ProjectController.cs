﻿using DataObjects;
using DumbScrumWebMVC.Models;
using LogicLayer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DumbScrumWebMVC.Controllers
{
    public class ProjectController : Controller {
        private MainManager _manager;

        public ProjectController() {
            _manager = MainManager.GetMainManager();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult MyProjects() {
            List<ProjectVM> projects = new List<ProjectVM>();
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindById(User.Identity.GetUserId());
            ViewBag.Message = "My Projects";
            try {
                // throw new ApplicationException();
                projects = _manager.ProjectManager.GetProjectsByUserID((int)user.UserID);
            } catch (Exception ex) {
                // we need to go to an error page
                TempData["Error"] = ex.Message;
            }
            return View(projects);
        }

        public ActionResult AllProjects() {
            List<ProjectVM> projects = null;
            try {
                projects = _manager.ProjectManager.GetAllProjects();
            } catch (Exception ex) {
                TempData["Error"] = ex.Message;
            }
            return View(projects);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ViewProject(string projectID) {
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindById(User.Identity.GetUserId());
            // get member
            ProjectMemberVM member = _manager.ProjectMemberManager.GetProjectMember((int)user.UserID, projectID);
            if(member == null) {
                TempData["Warning"] = "You are not a part of this project. Only project members can view this project.";
                return RedirectToAction("MyProjects");
            }

            Session["ProjectMember"] = member;

            ProjectVM projectVM = null;
            try {
                projectVM = _manager.ProjectManager.GetProjectVMByProjectID(projectID);
            } catch (Exception ex) {
                TempData["Error"] = ex.Message;
            }
            return View("Project", projectVM);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Project project) {
            try {
                ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = userManager.FindById(User.Identity.GetUserId());
                project.UserID = (int)user.UserID;
                project.DateCreated = DateTime.Now;
                if(_manager.ProjectManager.AddProject(project)) {
                    TempData["Success"] = "Successfully created project: " + project.ProjectID;
                    return RedirectToAction("MyProjects");
                } else {
                    TempData["Warning"] = "Something went wrong while creating project";
                }
            }
            catch(Exception ex) {
                TempData["Error"] = ex.Message;
            }
            return View(project);
        }

        [HttpPost]
        public ActionResult Delete(string projectID) {
            try {
                if(_manager.ProjectManager.RemoveProject(projectID)) {
                    TempData["Success"] = "Successfully deleted project.";
                } else {
                    TempData["Warning"] = "Something went wrong while deleting project";
                }
            }
            catch(Exception ex) {
                TempData["Error"] = "Failed to delete project. \n" + ex.Message;
            }
            return RedirectToAction("MyProjects");
        }
    }
}
