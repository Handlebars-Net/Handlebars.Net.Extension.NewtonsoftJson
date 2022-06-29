using System.Linq;
using HandlebarsDotNet.Extension.NewtonsoftJson;
using Newtonsoft.Json.Linq;
using Xunit;

namespace HandlebarsDotNet.Extension.Test
{
    public class IssueTests
    {
        // issue: https://github.com/Handlebars-Net/Handlebars.Net/issues/411
        [Fact]
        public void UsingTheClassTestAsInputCheckingContentTest()
        {
            var source = "{{conTentTest}}";

            var handlebars = Handlebars.Create();
            handlebars.Configuration.UseNewtonsoftJson();

            var template = handlebars.Compile(source);
            var data = new ClassOfTest();

            var result = template(data);
            var expected = "{&quot;Nested1&quot;:{&quot;Prop&quot;:&quot;Prop&quot;},&quot;Nested2&quot;:null}";
            var actual = result
                .Replace("\n", string.Empty)
                .Replace("\r", string.Empty)
                .Replace(" ", string.Empty);
            
            Assert.Equal(expected, actual);
        }
        
        
        // issue: https://github.com/Handlebars-Net/Handlebars.Net/issues/411
        [Fact]
        public void UsingTheClassTestAsInputCheckingContentTestNested1()
        {
            var source = "{{conTentTest.Nested1}}";
            var handlebars = Handlebars.Create();
            handlebars.Configuration.UseNewtonsoftJson();
            var template = handlebars.Compile(source);
            var data = new ClassOfTest();

            var result = template(data);
            var expected = @"{&quot;Prop&quot;:&quot;Prop&quot;}";
            var actual = result
                .Replace("\n", string.Empty)
                .Replace("\r", string.Empty)
                .Replace(" ", string.Empty);
            
            Assert.Equal(expected, actual);
        }
        
        public class ClassOfTest
        {
            public JObject ContentTest { get; set; } = JObject.FromObject(new
            {
                Nested1 = new { Prop = "Prop" }, 
                Nested2 = (object)null
            });
        }
        
        // issue: https://github.com/Handlebars-Net/Handlebars.Net/issues/428
        [Fact]
        public void PartialParametersInsideEachTest()
        {
            var handlebars = Handlebars.Create();
            handlebars.Configuration.UseNewtonsoftJson();

            const string source = "{{#each itemType}}{{>partial item=this}}{{/each}}";
            const string partialContent = @"{{item}}";

            handlebars.RegisterTemplate("partial", partialContent);

            var template = handlebars.Compile(source);

            var data = new
            {
                itemType = new JObject()
                {
                    ["1"] = "1",
                    ["3"] = "3",
                    ["5"] = "5",
                    ["7"] = "7"
                }
            };
            
            var actual = template(data);
            var expected = data.itemType.Properties().Select(o => o.Value.Value<string>());
            
           Assert.Equal(actual, string.Join("", expected));
        }
        
        // issue: https://github.com/Handlebars-Net/Handlebars.Net.Extension.NewtonsoftJson/issues/5
        [Fact]
        public void EscapedPathWithDots()
        {
            var handlebars = Handlebars.Create();
            var template = handlebars.Compile("{{ withDots.[one.two.three] }}");

            var actual = template(new JObject
            {
                ["withDots"] = new JObject
                {
                    ["one.two.three"] = 42
                }
            });
    
            Assert.Equal("42", actual);
        }
    }
}