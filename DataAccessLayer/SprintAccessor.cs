﻿using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer {
    public class SprintAccessor : ISprintAccessor {
        public int CreateSprint(Sprint sprint) {
            int result = 0;

            var conn = SqlConnectionProvider.GetConnection();
            var cmdText = "sp_insert_sprint";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@FeatureID", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);

            cmd.Parameters["@Name"].Value = sprint.Name;
            cmd.Parameters["@FeatureID"].Value = sprint.FeatureID;
            cmd.Parameters["@StartDate"].Value = sprint.StartDate;
            cmd.Parameters["@EndDate"].Value = sprint.EndDate;

            try {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return result;
        }

        public List<SprintVM> SelectSprintVMsByProjectID(string projectID) {
            List<SprintVM> result = new List<SprintVM>();

            // create connection object
            var conn = SqlConnectionProvider.GetConnection();

            // set the command text
            var commandText = "sp_select_project_sprints";

            // create command object
            var cmd = new SqlCommand(commandText, conn);

            // set command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters to command
            cmd.Parameters.Add("@ProjectID", SqlDbType.NVarChar, 50);

            // set parameter values
            cmd.Parameters["@ProjectID"].Value = projectID;

            try {
                // open connection
                conn.Open();

                // execute command
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        SprintVM s = new SprintVM();
                        s.SprintID = reader.GetInt32(0);
                        s.FeatureID = reader.GetString(1);
                        s.Name = reader.GetString(2);
                        s.StartDate = reader.GetDateTime(3);
                        s.EndDate = reader.GetDateTime(4);
                        s.Active = reader.GetBoolean(5);
                        s.FeatureName = reader.GetString(6);
                        result.Add(s);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return result;
        }

        public SprintVM SelectSprintVMBySprintID(int sprintID) {
            SprintVM result = null;

            // create connection object
            var conn = SqlConnectionProvider.GetConnection();

            // set the command text
            var commandText = "sp_select_sprint_by_sprintid";

            // create command object
            var cmd = new SqlCommand(commandText, conn);

            // set command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters to command
            cmd.Parameters.Add("@SprintID", SqlDbType.Int);

            // set parameter values
            cmd.Parameters["@SprintID"].Value = sprintID;

            try {
                // open connection
                conn.Open();

                // execute command
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    if (reader.Read()) {
                        result = new SprintVM();
                        result.SprintID = reader.GetInt32(0);
                        result.FeatureID = reader.GetString(1);
                        result.Name = reader.GetString(2);
                        result.StartDate = reader.GetDateTime(3);
                        result.EndDate = reader.GetDateTime(4);
                        result.Active = reader.GetBoolean(5);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return result;
        }

        public SprintVM SelectSprintVMByFeatureID(string featureID) {
            SprintVM result = null;

            // create connection object
            var conn = SqlConnectionProvider.GetConnection();

            // set the command text
            var commandText = "sp_select_sprint_by_featureid";

            // create command object
            var cmd = new SqlCommand(commandText, conn);

            // set command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters to command
            cmd.Parameters.Add("@FeatureID", SqlDbType.NVarChar, 50);

            // set parameter values
            cmd.Parameters["@FeatureID"].Value = featureID;

            try {
                // open connection
                conn.Open();

                // execute command
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    if (reader.Read()) {
                        result = new SprintVM();
                        result.SprintID = reader.GetInt32(0);
                        result.FeatureID = reader.GetString(1);
                        result.Name = reader.GetString(2);
                        result.StartDate = reader.GetDateTime(3);
                        result.EndDate = reader.GetDateTime(4);
                        result.Active = reader.GetBoolean(5);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return result;
        }

        public int DeleteSprint(int sprintID) {
            int result = 0;

            var conn = SqlConnectionProvider.GetConnection();
            var cmdText = "sp_delete_project_sprint";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SprintID", SqlDbType.Int);

            cmd.Parameters["@SprintID"].Value = sprintID;

            try {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return result;
        }

        public int UpdateSprint(Sprint newSprint, Sprint oldSprint) {
            int result = 0;

            var conn = SqlConnectionProvider.GetConnection();
            var cmdText = "sp_update_sprint";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SprintID", SqlDbType.Int);

            cmd.Parameters.Add("@OldName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@OldStartDate", SqlDbType.DateTime);
            cmd.Parameters.Add("@OldEndDate", SqlDbType.DateTime);

            cmd.Parameters.Add("@NewName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NewStartDate", SqlDbType.DateTime);
            cmd.Parameters.Add("@NewEndDate", SqlDbType.DateTime);

            cmd.Parameters["@SprintID"].Value = oldSprint.SprintID;

            cmd.Parameters["@OldName"].Value = oldSprint.Name;
            cmd.Parameters["@OldStartDate"].Value = oldSprint.StartDate;
            cmd.Parameters["@OldEndDate"].Value = oldSprint.EndDate;

            cmd.Parameters["@NewName"].Value = newSprint.Name;
            cmd.Parameters["@NewStartDate"].Value = newSprint.StartDate;
            cmd.Parameters["@NewEndDate"].Value = newSprint.EndDate;

            try {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return result;
        }
    }
}
