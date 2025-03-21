using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using WpfStudyNote.Core.Models;
using WpfStudyNote.Interfaces;

namespace WpfStudyNote.Services
{
    public class TagsService : IWebApiService<ApiReponse<Tags>, Tags>
    {
        private static RestClient _client = new RestClient(new StaticField().Web_Host);

        public Task<ApiReponse<Tags>> CreateAsync(Tags entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiReponse<Tags>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<Tags>> GetAllAsync()
        {
            try
            {
                var request = new RestRequest($"{StaticField.Tags}{StaticField.GetAll}",Method.Get);
                var response = await _client.ExecuteAsync(request);
                if(response.IsSuccessful)
                {
                    ApiReponse<ObservableCollection<Tags>> apiReponse = JsonConvert.DeserializeObject<ApiReponse<ObservableCollection<Tags>>>(response.Content);
                    if (apiReponse.Object.Count > 0)
                        return apiReponse.Object;
                }
                throw new ArgumentNullException("查无数据");
            }
            catch (Exception)
            {

                throw;
            }
            //throw new NotImplementedException();
        }

        public Task<ApiReponse<Tags>> GetExactsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiReponse<Tags>> UpdateAsync(int id, Tags entity)
        {
            throw new NotImplementedException();
        }
    }
}
