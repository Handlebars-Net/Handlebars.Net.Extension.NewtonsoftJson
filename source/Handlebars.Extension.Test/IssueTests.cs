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
    }
}