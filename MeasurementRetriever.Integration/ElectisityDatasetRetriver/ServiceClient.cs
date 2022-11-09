using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Integration.ElectisityDatasetRetriver
{
    public class ServiceClient : IServiceClient
    {

        private readonly HttpClient _httpClient;

        public ServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Measurement>>Get(string datasetUrl,string type)
        {

           

            string responseString = string.Empty;
            if(type == "File")
            {
                 responseString = ReadLocalFile(datasetUrl); 
            
            }
            else
            {

                var serviceResponse = await _httpClient.GetAsync(datasetUrl);
                responseString = await serviceResponse.Content.ReadAsStringAsync(); 
            }
            var lines = responseString.Split("\n");
            var parsedData = lines.Skip(1).Where(x => !string.IsNullOrEmpty(x)).Select(x => ParseString(x));
            return parsedData.ToList();
        }

        public string ReadLocalFile(string filePath)
        {
            var content = File.ReadAllText(filePath);
            return content;
        }

        private Measurement ParseString(string row)
        {
            try
            {

                

                var fields = row.Split(',');
                return new Measurement()
                {
                    TINKLAS = fields[0],
                    OBT_PAVADINIMAS = fields[1],
                    OBJ_GV_TIPAS = fields[2],
                    OBJ_NUMERIS = Convert.ToInt64(fields[3]),
                    PPlus = !string.IsNullOrEmpty(fields[4]) ? Convert.ToDecimal(fields[4]) : null,
                    PL_T = DateTime.ParseExact(fields[5], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                    PMinus = !string.IsNullOrEmpty(fields[6].Replace("\r", "")) ? Convert.ToDecimal(fields[6].Replace("\r", "")) : null,

                };
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
