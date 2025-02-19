﻿using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer {
    public class UserManager : IUserManager {
        private IUserAccessor _userAccessor = null;

        public UserManager() {
            _userAccessor = new UserAccessor();
        }

        public UserManager(IUserAccessor userAccessor) {
            _userAccessor = userAccessor;
        }

        public bool AuthenticateUser(string email, string password) {
            bool result = false;
            try {
                password = HashSha256(password);
                result = (1 == _userAccessor.AuthenticateUserWithEmailAndPasswordHash(email, password));
            } catch (Exception ex) {
                throw new ArgumentException("Authentication Failed", ex);
            }
            return result;
        }

        public bool ChangeDisplayName(int userID, string newDisplayName) {
            bool result = false;

            try {
                result = (1 == _userAccessor.UpdateDisplayName(userID, newDisplayName));
            } catch (Exception ex) {
                throw new ArgumentException("Display name change failed", ex);
            }
            return result;
        }

        public bool ChangePassword(string email, string newPassword) {
            bool result = false;

            newPassword = HashSha256(newPassword);

            try {
                result = (1 == _userAccessor.UpdatePasswordHash(email, newPassword));
            } catch (Exception ex) {
                throw new ArgumentException("User or password not found.", ex);
            }

            return result;
        }

        public bool EditUser(User newUser, User oldUser) {
            bool result = false;
            try {
                result = (1 == _userAccessor.UpdateUser(newUser, oldUser));
            } catch (Exception ex) {
                throw ex;
            }
            return result;
        }

        public User GetUser(int userID) {
            User user = null;
            try {
                user = _userAccessor.SelectUserByUserID(userID);
            } catch (Exception ex) {
                throw new ApplicationException("User not found", ex);
            }
            return user;
        }

        public UserVM GetUserVMByEmail(string email) {
            UserVM userVM = null;
            try {
                userVM = _userAccessor.SelectUserVMByEmail(email);
            } catch (Exception ex) {
                throw new ApplicationException("User not found", ex);
            }
            return userVM;
        }

        public string HashSha256(string password) {
            string hashValue = "";
            // hash functions run at the bits and bytes level
            // so create a byte array
            byte[] data;

            // create .NET hash provider object
            using (SHA256 sha256Hasher = SHA256.Create()) {
                // hash the source string
                data = sha256Hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            // create an output string builder object
            var s = new StringBuilder();
            // loop through the byte array and build a return string
            for (int i = 0; i < data.Length; i++) {
                // outputs the byte as two hex digits
                s.Append(data[i].ToString("x2"));
            }
            hashValue = s.ToString();
            return hashValue;
        }

        public UserVM SignInUser(string email, string password) {
            UserVM userVM = null;
            try {
                if (AuthenticateUser(email, password)) {
                    userVM = GetUserVMByEmail(email);
                } else {
                    throw new ApplicationException("Bad email or password");
                }
            } catch (Exception ex) {
                throw new ApplicationException("Authentication Failed", ex);
            }
            return userVM;
        }

        public UserVM SignUpUser(User user) {
            UserVM userVM = null;
            try {
                if(0 == _userAccessor.CheckIfEmailHasBeenUsedAlready(user.Email)) { // new email
                    user.Password = HashSha256(user.Password);
                    _userAccessor.InsertUser(user);
                    userVM = GetUserVMByEmail(user.Email);
                } else {
                    throw new ApplicationException("An account already exists with this email");
                }
            } catch (Exception ex) {
                throw new ApplicationException("Sign Up Failed", ex);
            }
            return userVM;
        }

        public byte[] GetFileInBinary(string filePath) {
            using (System.IO.Stream stream = System.IO.File.OpenRead(filePath)) {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        public bool FindUser(string email) {
            try {
                return _userAccessor.SelectUserVMByEmail(email) != null;
            } catch(ApplicationException ax) {
                if(ax.Message == "User not found.") {
                    return false;
                } else {
                    throw;
                }
            } catch (Exception ex) {
                throw new ApplicationException("Database Error", ex);
            }
        }

        public List<string> GetAllRoles() {
            List<string> roles = new List<string>();
            try {
                roles = _userAccessor.SelectAllRoles();
            } catch (Exception ex) {
                throw new ApplicationException("Failed to retrieve roles", ex);
            }
            return roles;
        }

        public int GetUserIDFromEmail(string email) {
            try {
                return _userAccessor.SelectUserVMByEmail(email).UserID;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public bool RemoveUserRole(int userID, string roleID) {
            bool result = false;
            try {
                result = _userAccessor.DeleteUserRole(userID, roleID) == 1;
            } catch (Exception) {
                throw;
            }
            return result;
        }

        public bool AddUserRole(int userID, string roleID) {
            bool result = false;
            try {
                result = _userAccessor.InsertUserRole(userID, roleID) == 1;
            } catch (Exception) {
                throw;
            }
            return result;
        }

        public List<UserVM> GetAllUsers() {
            List<UserVM> users = new List<UserVM>();
            try {
                users = _userAccessor.SelectAllUsers();
            } catch (Exception ex) {
                throw ex;
            }
            return users;
        }
    }
}
