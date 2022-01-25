using System;
using Microsoft.EntityFrameworkCore.Design;

namespace StmStartBibl
{
    class SampleContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            return new ApplicationContext(ApplicationContext.GetDb());
        }
    }
}
