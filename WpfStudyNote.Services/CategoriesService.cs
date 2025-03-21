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

        public async Task<ApiReponse<Categories>> CreateAsync(Categories entity)
        {
            try
            {
                var request = new RestRequest($"{StaticField.Categories}{StaticField.Create}", Method.Post);
                request.AddJsonBody(entity);
                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<ApiReponse<Categories>>(response.Content);
                }
                throw new Exception("创建失败");
            }
            catch (Exception)
            {

                throw;
            }
            
            //throw new NotImplementedException();
        }

        public async Task<ApiReponse<Categories>> DeleteAsync(int id)
        {
            try
            {
                var request = new RestRequest($"{StaticField.Categories}{StaticField.Delete}{id}",Method.Delete);
                var response = await _client.DeleteAsync(request);
                if(response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<ApiReponse<Categories>>(response.Content);
                }
                throw new Exception("删除失败");
            }
            catch (Exception ex)
            {
                return ApiReponse<Categories>.Reponse(StatusCode.BadRequest, ex.Message, null);
            }
            //throw new NotImplementedException();
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
