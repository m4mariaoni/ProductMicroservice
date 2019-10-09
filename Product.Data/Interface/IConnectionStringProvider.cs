using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMicroservice.Data.Interface
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
    }
}
