﻿using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer {
    public class FeatureAccessor : IFeatureAccessor {
        public int CreateProjectFeature(string projectID, string name, string description, string priority, string status) {
            int result = 0;

            var conn = SqlConnectionProvider.GetConnection();
            var cmdText = "sp_insert_project_feature";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ProjectID", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@Priority", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50);

            cmd.Parameters["@ProjectID"].Value = projectID;
            cmd.Parameters["@Name"].Value = name;
            cmd.Parameters["@Description"].Value = description;
            cmd.Parameters["@Priority"].Value = priority;
            cmd.Parameters["@Status"].Value = status;

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

        public Feature SelectFeatureByFeatureID(int featureID) {
            throw new NotImplementedException();
        }

        public List<Feature> SelectFeaturesByProjectID(string projectID) {
            List<Feature> result = new List<Feature>();

            // create connection object
            var conn = SqlConnectionProvider.GetConnection();

            // set the command text
            var commandText = "sp_select_project_features";

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
                        Feature f = new Feature();
                        f.FeatureID = reader.GetInt32(0);
                        f.ProjectID = reader.GetString(1);
                        f.Name = reader.GetString(2);
                        f.Description = reader.GetString(3);
                        f.Priority = reader.GetString(4);
                        f.Status = reader.GetString(5);
                        
                        result.Add(f);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return result;
        }
    }
}
