using System;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.Iterators;
using HandlebarsDotNet.ObjectDescriptors;
using HandlebarsDotNet.PathStructure;
using Newtonsoft.Json.Linq;

namespace HandlebarsDotNet.Extension.NewtonsoftJson
{
    internal class JValueIterator : IIterator
    {
        public void Iterate(
            in EncodedTextWriter writer, 
            BindingContext context, 
            ChainSegment[] blockParamsVariables, 
            object input,
            TemplateDelegate template, 
            TemplateDelegate ifEmpty)
        {
            var value = (input as JValue)?.Value;
            if(value == null || !ObjectDescriptorFactory.Current.TryGetDescriptor(value.GetType(), out var descriptor)) return;
            
            descriptor.Iterator.Iterate(writer, context, blockParamsVariables, value, template, ifEmpty);
        }
    }
}