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
    public class CategoriesService : IWebApiService<ApiReponse<Categories>, Categories>
    {
        private static RestClient _client = new RestClient(new StaticField().Web_Host);

        public Task<ApiReponse<Categories>> CreateAsync(Categories entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiReponse<Categories>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<Categories>> GetAllAsync()
        {
            try
            {
                var request = new RestRequest($"{StaticField.Categories}{StaticField.GetAll}", Method.Get);
                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    ApiReponse<ObservableCollection<Categories>> apiReponse = JsonConvert.DeserializeObject<ApiReponse<ObservableCollection<Categories>>>(response.Content);
                    if (apiReponse.Object.Count > 0)
                        return apiReponse.Object;
                }
                throw new ArgumentNullException("差无数据");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<ApiReponse<Categories>> GetExactsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiReponse<Categories>> UpdateAsync(int id, Categories entity)
        {
            throw new NotImplementedException();
        }
    }
}
