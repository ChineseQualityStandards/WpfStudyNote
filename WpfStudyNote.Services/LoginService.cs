using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using RestSharp;
using WpfStudyNote.Core.Models;
using WpfStudyNote.Interfaces;

namespace WpfStudyNote.Services
{
    public class LoginService : IApiServer<Accounts, ApiReponse>, ILoginService
    {
        private static RestClient client = new RestClient(StaticField.Api_Url);

        public async Task<ApiReponse> LoginAsync(string value, string password)
        {
            try
            {
                RestRequest request = new RestRequest(StaticField.Account_Login,Method.Post);
                request.AddQueryParameter(StaticField.Login_Value, value);
                request.AddQueryParameter(StaticField.Login_Password, password);
                // 记录请求信息
                System.Diagnostics.Debug.WriteLine($"Request URL: {client.Options.BaseUrl}{request.Resource}");
                foreach (var param in request.Parameters)
                {
                    System.Diagnostics.Debug.WriteLine($"Parameter: {param.Name} = {param.Value}");
                }
                RestResponse response = await client.PostAsync(request);

                ApiReponse apiReponse = JsonConvert.DeserializeObject<ApiReponse>(response.Content);

                // 记录响应信息
                System.Diagnostics.Debug.WriteLine($"Response Status: {response.StatusCode}");
                System.Diagnostics.Debug.WriteLine($"Response Content: {response.Content}");

                return apiReponse;
            }
            catch (Exception ex)
            {
                return new ApiReponse() { Message = ex.Message };
            }
        }

        public new Task<ApiReponse> GetExactAsync(Accounts accounts)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public new Task<ApiReponse> DeleteAsync(Accounts entity)
        {
            throw new NotImplementedException();
        }
    }
}
