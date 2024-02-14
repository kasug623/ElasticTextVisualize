using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using UnityEngine;

namespace kasug623.Elasticsearch.Polling
{
    public class Main : MonoBehaviour
    {
        ElasticsearchPollingAgent<MyResponse.Response, MyDrawQueue> agent1;

        string[] drawList;

        public TextMeshPro textMeshPro;

        MyDrawQueue mappingElasticResponseToObject(MyResponse.Response elasticResponse, int d)
        {
            var doc = elasticResponse.hits.hits[d];

            MyDrawQueue newDrawQueue = new MyDrawQueue();
            newDrawQueue.Message = doc._source.message;
            return newDrawQueue;
        }

        void Start()
        {
            drawList = new string[1000];

            AccessInfo accessInfo = new AccessInfo(
                user: "elastic",
                password: "changeme",
                ipAddress: "XXX.XXX.XXX.XXX",
                index: "my-test-index",
                pollingIntervalSec: 3,
                currentBeginTime: "",
                shiftSpanTime: "",
                receiveQueueSize: 100);

            MyQueryDSL<MyResponse.Response> elasticsearchQueryDSL = new MyQueryDSL<MyResponse.Response>();

            agent1 = new ElasticsearchPollingAgent<MyResponse.Response, MyDrawQueue>(
                                                    accessInfo,
                                                    elasticsearchQueryDSL,
                                                    (MyResponse.Response document) => document.hits.hits.Count(),
                                                    (MyResponse.Response document) => document.hits.total.value,
                                                    mappingElasticResponseToObject
            );

            startAllPolling();

        }


        void Update()
        {

            int c = 0;
            (MyDrawQueue[] drawQueue, bool hasNewQueue, int newFirstQueueIndexNum, int newNumQueue, int drawQueueSize)
                = agent1.GetLastEnqueuedDataGroup();
            if(hasNewQueue)
            {
                textMeshPro.text = "";
                for (int i = newFirstQueueIndexNum; i < (newFirstQueueIndexNum + newNumQueue); i++)
                {
                    int j = i % drawQueueSize;
                    drawList[c] = drawQueue[j].Message;
                    textMeshPro.text += drawQueue[j].Message;
                    textMeshPro.text += "\n";
                    c++;
                }
            }
        }

        public void startAllPolling()
        {
            agent1.StartPolling();
        }


        async public void cancelAllPolling()
        {
            await agent1.Cancel();
        }

        private void OnApplicationQuit()
        {
            cancelAllPolling();
        }
    }
}
