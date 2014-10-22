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
        //Concrete operations related to Components
        public IEnumerable<Components> Components
        {
            get { return context.Components; }
        }

        public void SaveComponent(Components component)
        {
            if (component.ComponentID == 0)
            {
                context.Components.Add(component);
            }
            else
            {
                Components dbEntry = context.Components.Find(component.ComponentID);
                if (dbEntry != null)
                {
                    dbEntry.ComponentName = component.ComponentName;
                    dbEntry.ComponentDescription = component.ComponentDescription;
                }
            }
        }

        public Components DeleteComponent(int componentID)
        {
            Components dbEntry = context.Components.Find(componentID);
            if(dbEntry != null)
            {
                context.Components.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //Concrete operations related to EnvironmentUser
        public IEnumerable<EnvironmentUsers> EnvironmentUsers
        {
            get { return context.EnvironmentUsers; }
        }

        public void SaveEnvironmentUser(EnvironmentUsers environmentUser)
        {
            if (environmentUser.EnvironmentUserID == 0)
            {
                context.EnvironmentUsers.Add(environmentUser);
            }
            else
            {
                EnvironmentUsers dbEntry = context.EnvironmentUsers.Find(environmentUser.EnvironmentUserID);
                if (dbEntry != null)
                {
                    dbEntry.UserName = environmentUser.UserName;
                    dbEntry.EnvironmentName = environmentUser.EnvironmentName;
                    dbEntry.EnvironmentDescription = environmentUser.EnvironmentDescription;
                    dbEntry.IntendedUsers = environmentUser.IntendedUsers;
                    dbEntry.Justification = environmentUser.Justification;
                }
            }
            context.SaveChanges();
        }

        public EnvironmentUsers DeleteEnvironmentUser(int environmentUserID)
        {
            EnvironmentUsers dbEntry = context.EnvironmentUsers.Find(environmentUserID);
            if(dbEntry != null)
            {
                context.EnvironmentUsers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //Concrete operations related to EnvironmentComponents
        public IEnumerable<EnvironmentComponents> EnvironmentComponents
        {
            get { return context.EnvironmentComponents; }
        }

        public void SaveEnvironmentComponent(EnvironmentComponents environmentComponents)
        {
            if (environmentComponents.EnvironmentComponentID == 0)
            {
                context.EnvironmentComponents.Add(environmentComponents);
            }
            else
            {
                EnvironmentComponents dbEntry = context.EnvironmentComponents.Find(environmentComponents.EnvironmentComponentID);
                if (dbEntry != null)
                {
                    dbEntry.EnvironmentUserID = environmentComponents.EnvironmentUserID;
                    dbEntry.ComponentID = environmentComponents.ComponentID;
                    dbEntry.ComponentOrder = environmentComponents.ComponentOrder;
                    dbEntry.ComponentQuantity = environmentComponents.ComponentQuantity;
                    dbEntry.Name = environmentComponents.Name;
                }
            }
            context.SaveChanges();
        }

        public EnvironmentComponents DeleteEnvironmentComponent(int environmentComponentID)
        {
            EnvironmentComponents dbEntry = context.EnvironmentComponents.Find(environmentComponentID);
            if(dbEntry != null)
            {
                context.EnvironmentComponents.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


        //Concrete operations related to ComponentAttributes
        public IEnumerable<ComponentAttributes> ComponentAttributes
        {
            get { return context.ComponentAttributes; }
        }

        public void SaveComponentAttributes(ComponentAttributes componentAttributes)
        {
            if (componentAttributes.ComponentAttributeID == 0)
            {
                context.ComponentAttributes.Add(componentAttributes);
            }
            else
            {
                ComponentAttributes dbEntry = context.ComponentAttributes.Find(componentAttributes.ComponentAttributeID);
                if (dbEntry != null)
                {
                    dbEntry.EnvironmentComponentID = componentAttributes.EnvironmentComponentID;
                    dbEntry.AttributeDescription = componentAttributes.AttributeDescription;
                }
            }
            context.SaveChanges();
        }

        public ComponentAttributes DeleteComponentAttribute(int componentAttributeID)
        {
            ComponentAttributes dbEntry = context.ComponentAttributes.Find(componentAttributeID);
            if(dbEntry != null)
            {
                context.ComponentAttributes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
