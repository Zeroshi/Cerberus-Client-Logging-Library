using CerberusLogging.Interfaces.Objects;
using Newtonsoft.Json;

namespace CerberusLogging.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public class ConvertToJson
    {
        /// <summary>
        /// Converts the message to json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="log">The log.</param>
        /// <returns></returns>
        public string ConvertMessageToJson<T>(T log) where T : IEntityBase
        {
            var output = JsonConvert.SerializeObject(log);
            return output;
        }

        /// <summary>
        /// Converts the application message to json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="log">The log.</param>
        /// <returns></returns>
        public string ConvertApplicationMessageToJson<T>(T log) where T : IApplicationEntity
        {
            var output = JsonConvert.SerializeObject(log);
            return output;
        }
    }
}
