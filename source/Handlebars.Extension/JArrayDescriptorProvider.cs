using System;
using HandlebarsDotNet.MemberAccessors;
using HandlebarsDotNet.ObjectDescriptors;
using Newtonsoft.Json.Linq;

namespace HandlebarsDotNet.Extension.NewtonsoftJson
{
    internal class JArrayDescriptorProvider : IObjectDescriptorProvider
    {
        private static readonly string[] JArrayProperties = { "Count" };
        private static readonly Type Type = typeof(JArray);
        private static readonly JArrayMemberAccessor JArrayMemberAccessor = new JArrayMemberAccessor();
        
        private readonly ObjectDescriptorProvider _objectDescriptorProvider;
        
        public JArrayDescriptorProvider(ObjectDescriptorProvider objectDescriptorProvider)
        {
            _objectDescriptorProvider = objectDescriptorProvider;
        }
        
        public bool TryGetDescriptor(Type type, out ObjectDescriptor value)
        {
            if (Type != type)
            {
                value = ObjectDescriptor.Empty;
                return false;
            }

            if (!_objectDescriptorProvider.TryGetDescriptor(type, out var objectDescriptor))
            {
                value = ObjectDescriptor.Empty;
                return false;
            }
            
            var memberAccessor = new MergedMemberAccessor(JArrayMemberAccessor, objectDescriptor.MemberAccessor);
            value = new ObjectDescriptor(
                typeof(JArray), 
                memberAccessor, 
                (descriptor, o) => JArrayProperties,
                self => new JArrayIterator(),
                objectDescriptor.Dependencies
            );
            
            return true;
        }
    }
}