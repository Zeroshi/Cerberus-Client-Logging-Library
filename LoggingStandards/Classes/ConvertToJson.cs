using CerberusLogging.Interfaces.Objects;
using Newtonsoft.Json;

namespace CerberusLogging.Classes
{
    public class ConvertToJson
    {
        public string ConvertMessageToJson<T>(T log) where T : IEntityBase
        {
            var output = JsonConvert.SerializeObject(log);
            return output;
        }

        public string ConvertApplicationMessageToJson<T>(T log) where T : IApplicationEntity
        {
            var output = JsonConvert.SerializeObject(log);
            return output;
        }
    }
}
