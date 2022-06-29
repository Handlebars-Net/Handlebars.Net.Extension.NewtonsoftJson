using HandlebarsDotNet.IO;
using Newtonsoft.Json.Linq;

namespace HandlebarsDotNet.Extension.NewtonsoftJson.Formatters
{
    public class JValueFormatter : IFormatter
    {
        public void Format<T>(T value, in EncodedTextWriter writer)
        {
            var token = value as JValue;
            writer.Write(token!.Value);
        }
    }
}