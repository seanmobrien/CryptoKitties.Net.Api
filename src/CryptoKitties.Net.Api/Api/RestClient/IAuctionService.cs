using System.Threading.Tasks;
using CryptoKitties.Net.Api.RestClient.Messages;

namespace CryptoKitties.Net.Api.RestClient
{
    public interface IAuctionService
    {
        Task<AuctionQueryResponseMessage> GetAuctions(AuctionQueryRequestMessage request);
    }
}