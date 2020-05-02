using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using uwprek.Model;

namespace uwprek
{
    class NetworkTask
    {

        private NetworkTask instance = null;

        private HttpClient HttpClient;

        private IReceivingHeader iReceivingHeader;

        public NetworkTask() { }
        public NetworkTask(IReceivingHeader receivingHeader) {
            if (instance == null)
            {
                instance = new NetworkTask();
                HttpClient = new HttpClient();
                iReceivingHeader = receivingHeader;
            }
        }

        public async void DownloadReceivingData() {
            List<ReceivingHeader> receivingHeaders = new List<ReceivingHeader>();

            var task = await HttpClient.GetAsync("http://localhost:8080/api/v1/receiving/list?limit=20&skip=0");
            var jsonString = await task.Content.ReadAsStringAsync();

            receivingHeaders = JsonConvert.DeserializeObject<List<ReceivingHeader>>(jsonString);

            iReceivingHeader.OnSuccessReceivingHeaders(receivingHeaders);
        }
    }
}
