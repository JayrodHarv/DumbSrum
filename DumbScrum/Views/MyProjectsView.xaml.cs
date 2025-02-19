﻿using DataObjects;
using LogicLayer;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DumbScrum.Views {
    /// <summary>
    /// Interaction logic for MyProjectsView.xaml
    /// </summary>
    public partial class MyProjectsView : UserControl {
        MainManager _manager;
        public MyProjectsView() {
            _manager = MainManager.GetMainManager();
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            lvProjects.ItemsSource = _manager.ProjectManager.GetProjectsByUserID(_manager.LoggedInUser.UserID);
        }

        private void OpenProject() {
            if (lvProjects.SelectedItem == null) {
                MessageBox.Show("Please select a project to open it.");
                return;
            }
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);

            ProjectVM selectedProject = (ProjectVM)lvProjects.SelectedItem;

            parentWindow.CurrentView = new ProjectView(selectedProject.ProjectID, _manager.LoggedInUser);
        }

        private void btnOpenProject_Click(object sender, RoutedEventArgs e) {
            OpenProject();
        }

        private void btnCreateProject_Click(object sender, RoutedEventArgs e) {
            try {
                var createProjectWindow = new CreateProjectWindow();
                var result = createProjectWindow.ShowDialog();
                if (result == true) {
                    MessageBox.Show("Project Successfully Created.", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    lvProjects.ItemsSource = _manager.ProjectManager.GetProjectsByUserID(_manager.LoggedInUser.UserID);
                } else {
                    MessageBox.Show("Project Not Created", "Operation Aborted",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message,
                    "Failed To Create Project", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLeaveProject_Click(object sender, RoutedEventArgs e) {
            if(lvProjects.SelectedItem != null) {
                try {
                    Project project = lvProjects.SelectedItem as Project;
                    if(project.UserID == _manager.LoggedInUser.UserID) {
                        MessageBox.Show("You can't leave your own project. If you wish to delete your project, you can do so in its project settings.");
                        return;
                    }
                    if (_manager.ProjectMemberManager.MemberLeaveProject(_manager.LoggedInUser.UserID, project.ProjectID)) {
                        MessageBox.Show("Project Successfully Left.", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                        lvProjects.ItemsSource = _manager.ProjectManager.GetProjectsByUserID(_manager.LoggedInUser.UserID);
                    } else {
                        MessageBox.Show("Project Was Not Left", "Operation Aborted",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            } else {
                MessageBox.Show("You must have a project selected in order to leave it.");
            }
        }

        private void lvProjects_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            OpenProject();
        }
    }
}
