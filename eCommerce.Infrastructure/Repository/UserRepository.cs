using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoriesContract;
using eCommerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repository;
internal class UserRepository : IUserRepository
{
    private readonly DapperDbContext _dbcontext;
    public UserRepository(DapperDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();
        
        string Query= "Insert into public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\",\"Password\") " +
            "Values (@UserId, @Email,@PersonName, @Gender,@Password)";
        
       int rowaffectedcount= await _dbcontext.Connection.ExecuteAsync(Query, user);
        if (rowaffectedcount>0)
        {
            return user;

        }
        else
        {
            return null;
        }
        
    }

    public async Task<ApplicationUser?> GetUserByEmailandPassword(string? Email, string? Password)
    {
        return new ApplicationUser(){ Email = Email, Password = Password, PersonName = "person name", Gender = GenderOption.Male.ToString() }   ;
    }
}
