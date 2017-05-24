//using Dgi.Email.Delt.Dtoer;

namespace Dgi.Email.Delt.Interfaces
{
    public interface IEmailService
    {
        //QueryResultDto Lookup(QueryDto dto);

        bool Verify(string emailaddress);
    }
}