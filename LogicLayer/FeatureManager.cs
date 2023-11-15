﻿using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer {
    public class FeatureManager : IFeatureManager {

        private IFeatureAccessor _featureAccessor = null;

        public FeatureManager() {
            _featureAccessor = new FeatureAccessor();
        }

        public FeatureManager(IFeatureAccessor featureAccessor) {
            _featureAccessor = featureAccessor;
        }

        public bool AddProjectFeature(string projectID, string name, string description, string priority) {
            bool result = false;

            try {
                if(1 == _featureAccessor.CreateProjectFeature(projectID, name, description, priority)) {
                    result = true;
                }    
            } catch (Exception ex) {
                throw ex;
            }
            return result;
        }

        public Feature GetFeatureByFeatureID(int featureID) {
            throw new NotImplementedException();
        }

        public List<Feature> GetFeaturesByProjectID(string projectID) {
            List<Feature> result = new List<Feature>();
            try {
                result = _featureAccessor.SelectFeaturesByProjectID(projectID);
            } catch (Exception ex) {
                throw ex;
            }
            return result;
        }
    }
}
