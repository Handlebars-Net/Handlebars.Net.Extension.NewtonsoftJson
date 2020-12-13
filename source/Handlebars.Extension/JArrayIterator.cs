using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.Iterators;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;
using HandlebarsDotNet.ValueProviders;
using Newtonsoft.Json.Linq;

namespace HandlebarsDotNet.Extension.NewtonsoftJson
{
    public class JArrayIterator : IIterator
    {
        public void Iterate(
            in EncodedTextWriter writer, 
            BindingContext context, 
            ChainSegment[] blockParamsVariables, 
            object input,
            TemplateDelegate template, 
            TemplateDelegate ifEmpty
        )
        {
            var target = (JArray) input;
            
            using var innerContext = context.CreateFrame();
            var iterator = new IteratorValues(innerContext);
            var blockParamsValues = new BlockParamsValues(innerContext, blockParamsVariables);
            
            blockParamsValues.CreateProperty(0, out var _0);
            blockParamsValues.CreateProperty(1, out var _1);
            
            iterator.First = BoxedValues.True;
            iterator.Last = BoxedValues.False;

            var index = 0;
            var lastIndex = target.Count - 1;
            for (; index < target.Count; index++)
            {
                var value = target[index];
                var objectIndex = BoxedValues.Int(index);

                if (index == 1) iterator.First = BoxedValues.False;
                if (index == lastIndex) iterator.Last = BoxedValues.True;

                iterator.Index = objectIndex;

                object resolvedValue = value;

                blockParamsValues[_0] = resolvedValue;
                blockParamsValues[_1] = objectIndex;

                iterator.Value = resolvedValue;
                innerContext.Value = resolvedValue;

                template(writer, innerContext);
            }
            
            if (index == 0)
            {
                innerContext.Value = context.Value;
                ifEmpty(writer, innerContext);
            }
        }
    }
}