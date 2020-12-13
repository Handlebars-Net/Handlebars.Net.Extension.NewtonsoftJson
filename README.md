# Handlebars.Net.Extension.NewtonsoftJson


#### [![CI](https://github.com/Handlebars-Net/Handlebars.Net.Extension.NewtonsoftJson/workflows/CI/badge.svg)](https://github.com/Handlebars-Net/Handlebars.Net.Extension.NewtonsoftJson/actions?query=workflow%3ACI) [![Nuget](https://img.shields.io/nuget/vpre/Handlebars.Net.Extension.NewtonsoftJson)](https://www.nuget.org/packages/Handlebars.Net.Extension.NewtonsoftJson/) [![performance](https://img.shields.io/badge/benchmark-statistics-blue)](http://handlebars-net.github.io/Handlebars.Net.Extension.NewtonsoftJson/dev/bench/)

---

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Handlebars-Net_Handlebars.Net.Extension.NewtonsoftJson&metric=alert_status)](https://sonarcloud.io/dashboard?id=Handlebars-Net_Handlebars.Net.Extension.NewtonsoftJson) [![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=Handlebars-Net_Handlebars.Net.Extension.NewtonsoftJson&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=Handlebars-Net_Handlebars.Net.Extension.NewtonsoftJson) [![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=Handlebars-Net_Handlebars.Net.Extension.NewtonsoftJson&metric=security_rating)](https://sonarcloud.io/dashboard?id=Handlebars-Net_Handlebars.Net.Extension.NewtonsoftJson)

[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=Handlebars-Net_Handlebars.Net.Extension.NewtonsoftJson&metric=bugs)](https://sonarcloud.io/dashboard?id=Handlebars-Net_Handlebars.Net.Extension.NewtonsoftJson) [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=Handlebars-Net_Handlebars.Net.Extension.NewtonsoftJson&metric=code_smells)](https://sonarcloud.io/dashboard?id=Handlebars-Net_Handlebars.Net.Extension.NewtonsoftJson) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=Handlebars-Net_Handlebars.Net.Extension.NewtonsoftJson&metric=coverage)](https://sonarcloud.io/dashboard?id=Handlebars-Net_Handlebars.Net.Extension.NewtonsoftJson) 

---
 
[![GitHub issues questions](https://img.shields.io/github/issues/handlebars-net/Handlebars.Net.Extension.NewtonsoftJson/question)](https://github.com/Handlebars-Net/Handlebars.Net.Extension.NewtonsoftJson/labels/question) 
[![GitHub issues help wanted](https://img.shields.io/github/issues/handlebars-net/Handlebars.Net.Extension.NewtonsoftJson/help%20wanted?color=green&label=help%20wanted)](https://github.com/Handlebars-Net/Handlebars.Net.Extension.NewtonsoftJson/labels/help%20wanted)

---

## Purpose

Adds proper [Newtonsoft.Json](https://www.newtonsoft.com/json) support to Handlebars.Net

### Install
```cmd
dotnet add package Handlebars.Net.Extension.NewtonsoftJson
```

### Usage
```c#
var handlebars = Handlebars.Create();
handlebars.Configuration.UseNewtonsoftJson();
```

### Example
```c#
[Fact]
public void JsonTestObjects()
{
    var model = JObject.Parse("{\"Key1\": \"Val1\", \"Key2\": \"Val2\"}");

    var source = "{{#each this}}{{@key}}{{@value}}{{/each}}";

    var handlebars = Handlebars.Create();
    handlebars.Configuration.UseNewtonsoftJson();

    var template = handlebars.Compile(source);

    var output = template(model);

    Assert.Equal("Key1Val1Key2Val2", output);
}
```

