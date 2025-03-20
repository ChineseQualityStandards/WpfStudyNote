using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using RestSharp;
using WpfStudyNote.Core.Models;
using WpfStudyNote.Interfaces;

namespace WpfStudyNote.Services
{
    public class AccountsService : IAccountService<ApiReponse<Accounts>, Accounts>,IRestClientService<Accounts>
    {        
        private static RestClient _client = new RestClient(new StaticField().Web_Host);

        public async Task<ApiReponse<Accounts>> CreateAsync(Accounts entity)
        {
            try
            {
                var request = new RestRequest($"{StaticField.Accounts}{StaticField.Create}", Method.Post);
                request.AddJsonBody(entity);
                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<ApiReponse<Accounts>>(response.Content);
                }
                throw new Exception("创建失败");
            }
            catch (Exception ex)
            {
                return ApiReponse<Accounts>.Reponse(StatusCode.Unknown, ex.Message, null);
            }
        }

        public Task<ApiReponse<Accounts>> DeleteAsync(Accounts entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiReponse<Accounts>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiReponse<Accounts>> ExecuteAsync(RestRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Accounts>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApiReponse<Accounts>> GetExactsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiReponse<Accounts>> LoginAsync(Accounts accounts)
        {
            try
            {
                var request = new RestRequest($"{StaticField.Accounts}{StaticField.Login}", Method.Post);
                request.AddJsonBody(accounts);
                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<ApiReponse<Accounts>>(response.Content);
                    //return ApiReponse.Accepted(JsonConvert.DeserializeObject<ApiReponse>(response.Content));
                    //return ApiReponse.Accepted(response.Content);
                }
                return ApiReponse<Accounts>.Reponse(StatusCode.BadRequest,"登录失败",null);
            }
            catch (Exception ex)
            {
                return ApiReponse<Accounts>.Reponse(StatusCode.Unknown,ex.Message,null);
            }
        }

        public Task<ApiReponse<Accounts>> UpdateAsync(string password, Accounts accounts)
        {
            throw new NotImplementedException();
        }

        public Task<ApiReponse<Accounts>> UpdateAsync(int id, Accounts entity)
        {
            throw new NotImplementedException();
        }
    }
}
