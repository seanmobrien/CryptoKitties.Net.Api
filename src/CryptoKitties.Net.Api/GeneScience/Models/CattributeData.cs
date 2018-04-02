
namespace CryptoKitties.Net.GeneScience.Models
{
    /// <summary>
    /// The <see cref="CattributeData"/> class describes a cattribute
    /// </summary>
    public class CattributeData
    {
        /// <summary>
        /// Initializes a new cattribute
        /// </summary>
        /// <param name="name"></param>
        /// <param name="kai"></param>
        public CattributeData(string name, char kai)
        {
            CattributeName = name;
            Kai = kai;
        }
        /// <summary>
        /// Name of the cattribute
        /// </summary>
        public string CattributeName { get; }
        /// <summary>
        /// Cattributes kai code
        /// </summary>
        public char Kai { get; }
    }
}
