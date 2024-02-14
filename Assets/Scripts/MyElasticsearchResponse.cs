using System;
using System.Collections.Generic;

namespace kasug623.Elasticsearch.Polling.MyResponse
{

    [Serializable]
    public struct Response
    {
        public float took { get; set; }
        public bool timed_out { get; set; }
        public Shards _shards { get; set; }
        public Hits hits { get; set; }
    }

    [Serializable]
    public struct Shards
    {
        public int total { get; set; }
        public int successful { get; set; }
        public int skipped { get; set; }
        public int failed { get; set; }
    }

    [Serializable]
    public struct Hits
    {
        public Total total { get; set; }
        public float max_score { get; set; }
        public List<SubHits> hits { get; set; }
    }

    [Serializable]
    public struct Total
    {
        public int value { get; set; }
        public string relation { get; set; }
    }

    [Serializable]
    public struct SubHits
    {
        public string index { get; set; }
        public string _id { get; set; }
        public float _score { get; set; }
        public Source _source { get; set; }
    }

    [Serializable]
    public struct Source
    {
        public string timestamp { get; set; }
        public string message { get; set; }
        public string user { get; set; }
        public int weight { get; set; }
        public string mood { get; set; }
    }
}