using EnvironmentManagement.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentManagement.Domain.Entities;

namespace EnvironmentManagement.Domain.Concrete
{

    public class EnvironmentRepository : IEnvironmentRepository
    {
        private EFDbContext context = new EFDbContext();   
        

        //Concrete operations related to ComponentAttributes
        public IEnumerable<COMPONENTATTRIBUTE> ComponentAttributes
        {
            get { return context.COMPONENTATTRIBUTES; }
        }

        public void SaveComponentAttribute(COMPONENTATTRIBUTE componentAttribute)
        {
            if (componentAttribute.COMPONENTATTRIBUTEID == 0)
            {
                context.COMPONENTATTRIBUTES.Add(componentAttribute);
            }
            else
            {
                COMPONENTATTRIBUTE dbEntry = context.COMPONENTATTRIBUTES.Find(componentAttribute.COMPONENTATTRIBUTEID);
                if (dbEntry != null)
                {
                    dbEntry.ENVIRONMENTCOMPONENTID = componentAttribute.ENVIRONMENTCOMPONENTID;
                    dbEntry.ATTRIBUTEKEY = componentAttribute.ATTRIBUTEKEY;
                    dbEntry.ATTRIBUTEVALUE = componentAttribute.ATTRIBUTEVALUE;
                }
            }
            context.SaveChanges();
        }

        public COMPONENTATTRIBUTE DeleteComponentAttribute(int componentAttributeID)
        {
            COMPONENTATTRIBUTE dbEntry = context.COMPONENTATTRIBUTES.Find(componentAttributeID);
            if (dbEntry != null)
            {
                context.COMPONENTATTRIBUTES.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //Concrete operations related to ComponentConnection
        public IEnumerable<COMPONENTCONNECTION> ComponentConnections
        {
            get { return context.COMPONENTCONNECTIONS; }
        }

        public void SaveComponentConnection(COMPONENTCONNECTION componentConnection)
        {
            if (componentConnection.COMPONENTCONNECTIONID == 0)
            {
                context.COMPONENTCONNECTIONS.Add(componentConnection);
            }
            else
            {
                COMPONENTCONNECTION dbEntry = context.COMPONENTCONNECTIONS.Find(componentConnection.COMPONENTCONNECTIONID);
                if (dbEntry != null)
                {
                    dbEntry.ENVIRONMENTCOMPONENTID1 = componentConnection.ENVIRONMENTCOMPONENTID1;
                    dbEntry.ENVIRONMENTCOMPONENTID2 = componentConnection.ENVIRONMENTCOMPONENTID2;
                }
            }
            context.SaveChanges();
        }

        public COMPONENTCONNECTION DeleteComponentConnection(int componentConnectionID)
        {
            COMPONENTCONNECTION dbEntry = context.COMPONENTCONNECTIONS.Find(componentConnectionID);
            if (dbEntry != null)
            {
                context.COMPONENTCONNECTIONS.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //Concrete operations related to Environment
        public IEnumerable<ENVIRONMENT> Environments
        {
            get { return context.ENVIRONMENTs; }
        }

        public void SaveEnvironment(ENVIRONMENT environment)
        {
            if (environment.ENVIRONMENTID == 0)
            {
                context.ENVIRONMENTs.Add(environment);
            }
            else
            {
                ENVIRONMENT dbEntry = context.ENVIRONMENTs.Find(environment.ENVIRONMENTID);
                if (dbEntry != null)
                {
                    dbEntry.USERNAME = environment.USERNAME;
                    dbEntry.ENVIRONMENTNAME = environment.ENVIRONMENTNAME;
                    dbEntry.DESCRIPTION = environment.DESCRIPTION;
                    dbEntry.INTENDEDUSERS = environment.INTENDEDUSERS;
                    dbEntry.ENVIRONMENTZONE = environment.ENVIRONMENTZONE;
                    dbEntry.WORKINGSTATUS = environment.WORKINGSTATUS;
                    dbEntry.JUSTIFICATION = environment.JUSTIFICATION;
                }
            }
            context.SaveChanges();
        }

        public ENVIRONMENT DeleteEnvironment(int environmentID)
        {
            ENVIRONMENT dbEntry = context.ENVIRONMENTs.Find(environmentID);
            if (dbEntry != null)
            {
                context.ENVIRONMENTs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //Concrete operations related to EnvironmentAttribute
        public IEnumerable<ENVIRONMENTATTRIBUTE> EnvironmentAttributes
        {
            get { return context.ENVIRONMENTATTRIBUTES; }
        }

        public void SaveEnvironmentAttribute(ENVIRONMENTATTRIBUTE environmentAttribute)
        {
            if (environmentAttribute.ATTRIBUTEID == 0)
            {
                context.ENVIRONMENTATTRIBUTES.Add(environmentAttribute);
            }
            else
            {
                ENVIRONMENTATTRIBUTE dbEntry = context.ENVIRONMENTATTRIBUTES.Find(environmentAttribute.ATTRIBUTEID);
                if (dbEntry != null)
                {
                    dbEntry.ATTRIBUTETYPE = environmentAttribute.ATTRIBUTETYPE;
                    dbEntry.ATTRIBUTEVALUE = environmentAttribute.ATTRIBUTEVALUE;
                    dbEntry.ATTRIBUTEDESCRIPTION = environmentAttribute.ATTRIBUTEDESCRIPTION;
                }
            }
            context.SaveChanges();
        }

        public ENVIRONMENTATTRIBUTE DeleteEnvironmentAttribute(int environmentAttributeID)
        {
            ENVIRONMENTATTRIBUTE dbEntry = context.ENVIRONMENTATTRIBUTES.Find(environmentAttributeID);
            if (dbEntry != null)
            {
                context.ENVIRONMENTATTRIBUTES.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //Concrete operations related to EnvironmentComponent
        public IEnumerable<ENVIRONMENTCOMPONENT> EnvironmentComponents
        {
            get { return context.ENVIRONMENTCOMPONENTS; }
        }

        public void SaveEnvironmentComponent(ENVIRONMENTCOMPONENT environmentComponent)
        {
            if (environmentComponent.ENVIRONMENTCOMPONENTID == 0)
            {
                context.ENVIRONMENTCOMPONENTS.Add(environmentComponent);
            }
            else
            {
                ENVIRONMENTCOMPONENT dbEntry = context.ENVIRONMENTCOMPONENTS.Find(environmentComponent.ENVIRONMENTCOMPONENTID);
                if(dbEntry != null)
                {
                    dbEntry.ENVIRONMENTID = environmentComponent.ENVIRONMENTID;
                    dbEntry.ENVIRONMENTATTRIBUTE = environmentComponent.ENVIRONMENTATTRIBUTE;
                    dbEntry.COMPONENTNAME = environmentComponent.COMPONENTNAME;
                }
            }
            context.SaveChanges();
        }

        public ENVIRONMENTCOMPONENT DeleteEnvironmentComponent(int environmentComponentID)
        {
            ENVIRONMENTCOMPONENT dbEntry = context.ENVIRONMENTCOMPONENTS.Find(environmentComponentID);
            if(dbEntry != null)
            {
                context.ENVIRONMENTCOMPONENTS.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }        
    }
}
