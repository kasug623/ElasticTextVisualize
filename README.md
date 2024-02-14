# ElasticTextVisualize

![gif](https://imgur.com/0mRTFdl.gif)
![png](https://imgur.com/lgx9l4a.png)
- queryDSL 1
    ```json
    GET my-test-index/_search
    {
    "query": {
        "range": {
            "@timestamp": {
                "gte": "2024-02-01T00:00",
                "lte": "2024-02-01T23:59"
            }
        }
    }
    }
    ```
- queryDSL 2
    ```json
    GET my-test-index/_search
    {
    "query": {
        "range": {
            "@timestamp": {
                "gte": "2024-02-02T00:00",
                "lte": "2024-02-02T23:59"
            }
        }
    }
    }
    ```
On Unity, display a text from Elasticsearch

## System Requirements
- Unity 2022.3.12f1
- URP 14.0.9

## Preparation
- `Unitask`  
    - add Package from `UPM`  
Package Manager > Add packager from git URL ...  
https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask

- `PolliingElasticsearch`  
    - add Package from `UPM`  
        Package Manager > Add packager from git URL ...  
        https://github.com/kasug623/PollingElasticsearch.git?path=Packages/PollingElasticsearch  
        ![png](https://imgur.com/YUnPUdB.png)
    - allow http
        Project Settings > Player > Allow donwload over HTTP*
        ![png](https://imgur.com/uuRiSqA.png)

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