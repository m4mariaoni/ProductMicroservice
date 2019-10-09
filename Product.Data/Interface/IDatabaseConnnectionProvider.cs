using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProductMicroservice.Data.Interface
{
    public interface IDatabaseConnnectionProvider
    {
        IDbConnection GetDbConnection();
    }
}
