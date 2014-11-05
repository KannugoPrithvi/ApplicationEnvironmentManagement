using EnvironmentManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentManagement.Domain.Abstract
{
    public interface IEnvironmentRepository
    {
        //Operations related to ComponentAttribute
        IEnumerable<COMPONENTATTRIBUTE> ComponentAttributes { get; }
        void SaveComponentAttribute(COMPONENTATTRIBUTE componentAttribute);
        COMPONENTATTRIBUTE DeleteComponentAttribute(int componentAttributeID);

        //Operations related to ComponentConnection

        IEnumerable<COMPONENTCONNECTION> ComponentConnections { get; }
        void SaveComponentConnection(COMPONENTCONNECTION componentConnection);
        COMPONENTCONNECTION DeleteComponentConnection(int componentConnectionID);

        //Operations related to Environment

        IEnumerable<ENVIRONMENT> Environments { get; }
        void SaveEnvironment(ENVIRONMENT environment);
        ENVIRONMENT DeleteEnvironment(int environmentID);

        //Operations related to EnvironmentAttribute

        IEnumerable<ENVIRONMENTATTRIBUTE> EnvironmentAttributes { get; }
        void SaveEnvironmentAttribute(ENVIRONMENTATTRIBUTE environmentAttribute);
        ENVIRONMENTATTRIBUTE DeleteEnvironmentAttribute(int environmentAttributeID);


        //Operations related to EnvironmentComponent

        IEnumerable<ENVIRONMENTCOMPONENT> EnvironmentComponents { get; }
        void SaveEnvironmentComponent(ENVIRONMENTCOMPONENT environmentComponent);
        ENVIRONMENTCOMPONENT DeleteEnvironmentComponent(int environmentComponentID);
    }
}
