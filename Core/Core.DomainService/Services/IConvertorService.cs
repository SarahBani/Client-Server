using System.ServiceModel;
using System.Threading.Tasks;

namespace Core.DomainService.Services
{
    [ServiceContract]
    public interface IConvertorService
    {
        
        [OperationContract]
        Task<string> ConvertNumberToWordAsync(string number);

    }
}