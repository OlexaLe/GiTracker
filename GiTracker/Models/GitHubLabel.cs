using Newtonsoft.Json;
using Xamarin.Forms;

namespace GiTracker.Models
{
    public class GitHubLabel : ILabel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string _color { get; set; }

        [JsonIgnore]
        public Color Color => Color.FromHex(_color);
    }
}