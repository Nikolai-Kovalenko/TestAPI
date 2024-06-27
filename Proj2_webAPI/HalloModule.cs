using Nancy;

namespace Proj2_webAPI
{
    public class HalloModule : NancyModule
    {
        public HalloModule()
        {
            Get("/nancy-api/{name}", parameters =>
            {
                return string.Concat("Hallo ", parameters.Name);
            });
        }
    }
}
