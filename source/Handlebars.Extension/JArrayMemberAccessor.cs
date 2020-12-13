using HandlebarsDotNet.MemberAccessors;
using HandlebarsDotNet.PathStructure;
using Newtonsoft.Json.Linq;

namespace HandlebarsDotNet.Extension.NewtonsoftJson
{
    internal class JArrayMemberAccessor : IMemberAccessor
    {
        public bool TryGetValue(object instance, ChainSegment memberName, out object? value)
        {
            if (
                int.TryParse(memberName.TrimmedValue, out var index)
                && index >= 0
                && instance is JArray jArray
                && index < jArray.Count
            )
            {
                value = jArray[index];
                return true;
            }

            value = null;
            return false;
        }
    }
}