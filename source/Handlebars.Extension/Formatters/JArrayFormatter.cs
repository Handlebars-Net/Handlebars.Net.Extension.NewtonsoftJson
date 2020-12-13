using HandlebarsDotNet.IO;
using Newtonsoft.Json.Linq;

namespace HandlebarsDotNet.Extension.NewtonsoftJson.Formatters
{
    public class JArrayFormatter : IFormatter
    {
        public void Format<T>(T value, in EncodedTextWriter writer)
        {
            var jArray = value as JArray;
            var lastIndex = jArray!.Count - 1;
            for (var index = 0; index < jArray.Count; index++)
            {
                writer.Write(jArray[index]);
                if (index != lastIndex)
                {
                    writer.Write(",", false);
                }
            }
        }
    }
}