using System;
using HandlebarsDotNet.ObjectDescriptors;
using HandlebarsDotNet.PathStructure;
using Newtonsoft.Json.Linq;

namespace HandlebarsDotNet.Extension.NewtonsoftJson
{
    internal class JValueDescriptorProvider : IObjectDescriptorProvider
    {
        private static readonly Type Type = typeof(JValue);
        private static readonly JValueMemberAccessor MemberAccessor = new JValueMemberAccessor();
        
        public bool TryGetDescriptor(Type type, out ObjectDescriptor value)
        {
            if (Type != type)
            {
                value = ObjectDescriptor.Empty;
                return false;
            }
            
            value = new ObjectDescriptor(
                typeof(JObject), 
                MemberAccessor,
                (d, o) =>
                {
                    var jValue = (o as JValue)?.Value;
                    if (jValue == null || !ObjectDescriptorFactory.Current.TryGetDescriptor(jValue.GetType(), out var localDescriptor))
                        return new ChainSegment[0];
                    
                    return new ObjectAccessor(jValue, localDescriptor).Properties;
                },
                self => new JValueIterator()
            );
            
            return true;
        }
    }
}