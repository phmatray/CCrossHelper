using Newtonsoft.Json;

namespace CCrossHelper.Lib.Portable.Services.Serialization
{
    public static class IJsonSerializerService_Extensions
    {
        public static string Serialize(this IJsonSerializerService self)
        {
            return JsonConvert.SerializeObject(self);
        }
    }
}