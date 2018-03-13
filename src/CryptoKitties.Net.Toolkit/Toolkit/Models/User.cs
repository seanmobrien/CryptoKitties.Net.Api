namespace CryptoKitties.Net.Toolkit.Models
{
    using Api.Models;

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


    }
}
