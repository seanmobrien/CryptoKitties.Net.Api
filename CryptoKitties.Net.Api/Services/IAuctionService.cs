using System.Threading.Tasks;
using CryptoKitties.Net.Api.Services.Messages;

namespace CryptoKitties.Net.Api.Services
{
    public interface IAuctionService
    {
        Task<AuctionQueryResponseMessage> GetAuctions(AuctionQueryRequestMessage request);
    }
}