using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.DbContext;
internal class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection dbConnection;
    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;

        string connectionstring = _configuration.GetConnectionString("PostgreConnection");
        dbConnection=new NpgsqlConnection(connectionstring);
    }
    public IDbConnection Connection=> dbConnection;
}
