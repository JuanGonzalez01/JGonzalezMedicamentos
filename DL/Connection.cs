using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Connection
    {
        public static string GetConnectionString()
        {
            return "Data Source=.;Initial Catalog=JGonzalezMedicamentos;User ID=sa;Password=pass@word1";
        }
    }
}
