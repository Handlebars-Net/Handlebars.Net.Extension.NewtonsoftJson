using System;
using HandlebarsDotNet.MemberAccessors;
using HandlebarsDotNet.PathStructure;
using Newtonsoft.Json.Linq;

namespace HandlebarsDotNet.Extension.NewtonsoftJson
{
    internal class JObjectMemberAccessor : IMemberAccessor
    {
        public bool TryGetValue(object instance, ChainSegment memberName, out object? value)
        {
            var jObject = (JObject) instance;
            if (jObject.TryGetValue(memberName.TrimmedValue, StringComparison.OrdinalIgnoreCase, out var token))
            {
                value = token is JValue jValue 
                    ? jValue.Value 
                    : token;

                return true;
            }

            value = null;
            return false;
        }
    }
}