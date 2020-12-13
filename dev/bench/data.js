window.BENCHMARK_DATA = {
  "lastUpdate": 1607898911910,
  "repoUrl": "https://github.com/Handlebars-Net/Handlebars.Net.Extension.NewtonsoftJson",
  "entries": {
    "Benchmark.Net.Extension Benchmark": [
      {
        "commit": {
          "author": {
            "email": "zjklee@gmail.com",
            "name": "Oleh Formaniuk",
            "username": "zjklee"
          },
          "committer": {
            "email": "zjklee@gmail.com",
            "name": "Oleh Formaniuk",
            "username": "zjklee"
          },
          "distinct": true,
          "id": "db4de7522932d71a5a55b98380327615d029d509",
          "message": "Update Readme",
          "timestamp": "2020-12-14T00:31:37+02:00",
          "tree_id": "d74f8809e354dd41c69aaddefa12075eb7d1f6a1",
          "url": "https://github.com/Handlebars-Net/Handlebars.Net.Extension.NewtonsoftJson/commit/db4de7522932d71a5a55b98380327615d029d509"
        },
        "date": 1607898911025,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "HandlebarsNet.Extension.Benchmark.Json.Default(N: 2)",
            "value": 32107.983138020834,
            "unit": "ns",
            "range": "± 759.7748206444982"
          },
          {
            "name": "HandlebarsNet.Extension.Benchmark.Json.Default(N: 5)",
            "value": 251254.16271033653,
            "unit": "ns",
            "range": "± 1919.608345396244"
          },
          {
            "name": "HandlebarsNet.Extension.Benchmark.Json.Default(N: 10)",
            "value": 1903967.1338541666,
            "unit": "ns",
            "range": "± 53949.54772605014"
          },
          {
            "name": "HandlebarsNet.Extension.Benchmark.Json.NewtonsoftJson(N: 2)",
            "value": 29408.802645169773,
            "unit": "ns",
            "range": "± 600.001261051728"
          },
          {
            "name": "HandlebarsNet.Extension.Benchmark.Json.NewtonsoftJson(N: 5)",
            "value": 234843.091343471,
            "unit": "ns",
            "range": "± 2134.6536791053445"
          },
          {
            "name": "HandlebarsNet.Extension.Benchmark.Json.NewtonsoftJson(N: 10)",
            "value": 1715649.8927176339,
            "unit": "ns",
            "range": "± 30415.10117446554"
          },
          {
            "name": "HandlebarsNet.Extension.Benchmark.EndToEnd.Default(N: 5, DataType: \"json\")",
            "value": 248287.62692057292,
            "unit": "ns",
            "range": "± 7693.415627174247"
          }
        ]
      }
    ]
  }
}