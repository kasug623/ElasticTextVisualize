# ElasticTextVisualize

![Imgur](https://imgur.com/BHdyrNb.gif)

On Unity, display a text from Elasticsearch

## Preparation
- `Unitask`  
    - add Package from `UPM`  
Package Manager > Add packager from git URL ...  
https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask

- `PolliingElasticsearch`  
    - add Package from `UPM`  
Package Manager > Add packager from git URL ...  
https://github.com/kasug623/PollingElasticsearch.git?path=Packages/PollingElasticsearch  

- `Json.NET (NuGet)`  
    1. preapare for `NuGet`  
        `manifest.json`
        ```json
        ...
        "scopedRegistries": [
        {
        "name": "Unity NuGet",
        "url": "https://unitynuget-registry.azurewebsites.net",
        "scopes": [
            "org.nuget"
            ]
            }
        ]
        ```
    2. reboot `Unity Editor`  
    3. add Package from `UPM`  
        Package Manager > Packages: My Registries > search "json"

# Procedures  
1. build `Elasticsearch`  
IP: XXX.XXX.XXX.XXX  
2. ingest sample data  

# Ref  
- https://www.newtonsoft.com/json  