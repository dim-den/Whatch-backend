using Volo.Abp;

namespace Whatch;

public static class WhatchDomainErrorCodes
{
    /* You can add your business exception error codes here, as constants */
    
    public const string NotValidUserOfFilm = "ERR:00001";

}


public static class BusinessExceptionExtensions 
{
    public static void ThrowIfNull(this BusinessException exception, object entity, string code, string message = null)
    {
        if (entity is null)
        {
            throw new BusinessException(code, message);
        }
    }
}