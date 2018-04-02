using System.Collections.Generic;
using System.Runtime.Serialization;
using CryptoKitties.Net.Blockchain.Models;

namespace CryptoKitties.Net.Toolkit.Models
{
    using Api.Models;

    [DataContract]
    public class User
        : Profile
    {
        public User()
        {
            
        }

        public User(Profile profile)
        {
            if (profile != null)
            {
                Nickname = profile.Nickname;
                Address = profile.Address;
                Image = profile.Image;
            }
        }
        [DataMember]
        public Dictionary<string, Transaction[]> InternalTranactions { get; set; }

    }
}
