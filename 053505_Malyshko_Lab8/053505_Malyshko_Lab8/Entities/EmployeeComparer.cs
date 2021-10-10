using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053505_Malyshko_Lab8.Entities
{
    class EmployeeComparer:IComparer<Employee>
    {
        public int Compare(Employee? x, Employee? y) =>
            string.Compare(x?.Name, y?.Name, StringComparison.InvariantCulture);
    }
}
