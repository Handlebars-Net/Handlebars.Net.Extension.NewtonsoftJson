using System.Collections.Generic;

namespace HandlebarsNet.Extension.Benchmark
{
    public class Utils
    {
        private readonly int _n;

        public Utils(int n) => _n = n;

        public List<object> ObjectLevel1Generator()
        {
            var level = new List<object>();
            for (int i = 0; i < _n; i++)
            {
                level.Add(new
                {
                    id = $"{i}",
                    level2 = ObjectLevel2Generator(i)
                });
            }

            return level;
        }
            
        public List<object> ObjectLevel2Generator(int id1)
        {
            var level = new List<object>();
            for (int i = 0; i < _n; i++)
            {
                level.Add(new
                {
                    id = $"{id1}-{i}",
                    level3 = ObjectLevel3Generator(id1, i)
                });
            }

            return level;
        }
            
        public List<object> ObjectLevel3Generator(int id1, int id2)
        {
            var level = new List<object>();
            for (int i = 0; i < _n; i++)
            {
                level.Add(new
                {
                    id = $"{id1}-{id2}-{i}"
                });
            }

            return level;
        }
    }
}