using System.Linq;
using HandlebarsDotNet.Extension.NewtonsoftJson.Formatters;
using HandlebarsDotNet.Features;
using HandlebarsDotNet.ObjectDescriptors;

namespace HandlebarsDotNet.Extension.NewtonsoftJson
{
    /// <summary>
    /// 
    /// </summary>
    public static class JsonFeatureExtensions
    {
        private static readonly JsonFeature JsonFeature = new JsonFeature();

        /// <summary>
        /// Adds <see cref="IObjectDescriptorProvider"/>s required to properly support <c>Newtonsoft.Json</c>. 
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static HandlebarsConfiguration UseNewtonsoftJson(this HandlebarsConfiguration configuration)
        {
            configuration.CompileTimeConfiguration.Features.Add(JsonFeature);
            
            return configuration;
        }
    }
    
    internal class JsonFeature : IFeature, IFeatureFactory
    {
        public void OnCompiling(ICompiledHandlebarsConfiguration configuration)
        {
            var providers = configuration.ObjectDescriptorProviders;
            var objectDescriptorProvider = providers.OfType<ObjectDescriptorProvider>().Single();
            providers.Add(new JArrayDescriptorProvider(objectDescriptorProvider));
            providers.Add(new JObjectDescriptorProvider());
            providers.Add(new JValueDescriptorProvider());
            
            configuration.FormatterProviders.Add(new JFormatterProvider());
        }

        public void CompilationCompleted()
        {
            // do nothing
        }

        public IFeature CreateFeature() => this;
    }
}