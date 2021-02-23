using HandlebarsDotNet.MemberAccessors;
using HandlebarsDotNet.ObjectDescriptors;
using HandlebarsDotNet.PathStructure;
using Newtonsoft.Json.Linq;

namespace HandlebarsDotNet.Extension.NewtonsoftJson
{
    internal class JValueMemberAccessor : IMemberAccessor
    {
        public bool TryGetValue(object instance, ChainSegment memberName, out object? value)
        {
            var obj = (instance as JValue)?.Value;
            if (obj == null || !ObjectDescriptorFactory.Current.TryGetDescriptor(obj.GetType(), out var descriptor))
            {
                value = null;
                return false;
            }

            return descriptor.MemberAccessor.TryGetValue(obj, memberName, out value);
        }
    }
}