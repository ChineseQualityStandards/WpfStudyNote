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
    public class ArticleService : IWebApiService<ApiReponse<Articles>, Articles>
    {
        private static RestClient _client = new RestClient(new StaticField().Web_Host);

        public async Task<ApiReponse<Articles>> CreateAsync(Articles entity)
        {
            try
            {
                var request = new RestRequest($"{StaticField.Articles}{StaticField.Create}", Method.Post);
                request.AddJsonBody(entity);
                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<ApiReponse<Articles>>(response.Content);
                }
                throw new Exception("创建失败");
            }
            catch (Exception ex)
            {
                return ApiReponse<Articles>.Reponse(StatusCode.BadRequest,ex.Message, null);
            }
        }

        public Task<ApiReponse<Articles>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<Articles>> GetAllAsync()
        {
            try
            {
                var request = new RestRequest($"{StaticField.Articles}{StaticField.GetAll}", Method.Get);
                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    ApiReponse<ObservableCollection<Articles>> apiReponse = JsonConvert.DeserializeObject<ApiReponse<ObservableCollection<Articles>>>(response.Content);
                    if (apiReponse.Object.Count > 0)
                        return apiReponse.Object;
                }
                throw new ArgumentNullException("查无数据");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<ApiReponse<Articles>> GetExactsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiReponse<Articles>> UpdateAsync(int id, Articles entity)
        {
            throw new NotImplementedException();
        }
    }
}
