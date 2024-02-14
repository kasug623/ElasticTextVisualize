using UnityEngine;

namespace kasug623.Elasticsearch.Polling
{
    class MyQueryDSL<ElasticsearchResponseType> : ElasticsearchQueryDSL<ElasticsearchResponseType>
    {
        int nextQueryPatternId;
        string beginTime;
        string endTime;
        string size;

        public MyQueryDSL()
        {
            nextQueryPatternId = 0;
            beginTime = "2024-02-01T00:00";
            endTime = "2024-02-01T23:59";
            size = "10";
            CreateQueryDSL();
            nextQueryPatternId = 1;
        }

        public override void CreateQueryDSL()
        {
            queryDSL = "{" +
                            "\"query\": {" +
                                    "\"range\": {" +
                                            "\"@timestamp\": {" +
                                                    "\"gte\": \"" + beginTime + "\"," +
                                                    "\"lte\": \"" + endTime + "\"" +
                                            "}" +
                                        "}" +
                                "}," +
                            "\"size\": " + size.ToString() +
                        "}";
        }

        public override void UpdateQueryDSL(ElasticsearchResponseType response)
        {
            switch (nextQueryPatternId)
            {
                case 0:
                    beginTime = "2024-02-01T00:00";
                    endTime = "2024-02-01T23:59";
                    size = "10";
                    nextQueryPatternId = 1;
                    break;
                case 1:
                    beginTime = "2024-02-02T00:00";
                    endTime = "2024-02-02T23:59";
                    size = "10";
                    nextQueryPatternId = 0;
                    break;
                default:
                    beginTime = "2024-02-02T00:00";
                    endTime = "2024-02-02T23:59";
                    size = "10";
                    nextQueryPatternId = 0;
                    break;
            }
            CreateQueryDSL();
        }
    }
}