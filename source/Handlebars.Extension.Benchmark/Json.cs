using System.IO;
using BenchmarkDotNet.Attributes;
using HandlebarsDotNet;
using HandlebarsDotNet.Extension.NewtonsoftJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HandlebarsNet.Extension.Benchmark
{
    public class Json
    {
        private string _json;
        private HandlebarsTemplate<TextWriter, object, object> _default;
        private HandlebarsTemplate<TextWriter, object, object> _newtonsoftJson;

        [Params(2, 5, 10)]
        public int N { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            const string template = @"
                {{#each level1}}
                    id={{id}}
                    {{#each level2}}
                        id={{id}}
                        {{#each level3}}
                            id={{id}}
                        {{/each}}
                    {{/each}}    
                {{/each}}";

            _json = JsonConvert.SerializeObject(new { level1 = new Utils(N).ObjectLevel1Generator()});

            {
                var handlebars = Handlebars.Create();
                handlebars.Configuration.UseNewtonsoftJson();

                using var reader = new StringReader(template);
                _newtonsoftJson = handlebars.Compile(reader);
            }
            
            {
                var handlebars = Handlebars.Create();

                using var reader = new StringReader(template);
                _default = handlebars.Compile(reader);
            }
        }
        
        [Benchmark]
        public void Default()
        {
            var document = JObject.Parse(_json);
            _default(TextWriter.Null, document);
        }
        
        [Benchmark]
        public void NewtonsoftJson()
        {
            var document = JObject.Parse(_json);
            _newtonsoftJson(TextWriter.Null, document);
        }
    }
}