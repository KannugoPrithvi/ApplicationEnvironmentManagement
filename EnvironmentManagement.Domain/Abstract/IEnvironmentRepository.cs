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
        //Operations related to Components
        IEnumerable<Components> Components { get; }
        void SaveComponent(Components component);
        Components DeleteComponent(int componentID);

        //Operations related to EnvironmentUsers

        IEnumerable<EnvironmentUsers> EnvironmentUsers { get; }
        void SaveEnvironmentUser(EnvironmentUsers environmentUser);
        EnvironmentUsers DeleteEnvironmentUser(int environmentUserID);

        //Operations related to EnvironmentComponents

        IEnumerable<EnvironmentComponents> EnvironmentComponents { get; }
        void SaveEnvironmentComponent(EnvironmentComponents environmentComponents);
        EnvironmentComponents DeleteEnvironmentComponent(int environmentComponentID);

        //Operations related to ComponentAttributes

        IEnumerable<ComponentAttributes> ComponentAttributes { get; }
        void SaveComponentAttributes(ComponentAttributes componentAttributes);
        ComponentAttributes DeleteComponentAttribute(int componentAttributeID);
    }
}
