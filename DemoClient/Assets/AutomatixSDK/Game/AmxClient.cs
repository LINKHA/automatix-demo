using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.AudioSettings;

namespace Amx
{
    public class AmxClient {
        public class UserSession
        {
            public string accessToken;
            public Int64 accessExpire;
            public Int64 refreshAfter;
        }
        UserSession session = new UserSession();
        public async Task<FastLoginResp> FastLogin(string mobile, string password)
        {
            string json = JsonUtility.ToJson(new FastLoginReq
            {
                mobile = mobile,
                password = password
            });

            string result = await _G.HttpCli.Post("/login/fastLogin", json);
            FastLoginResp resp = JsonUtility.FromJson<FastLoginResp>(result);
            
            session.accessToken = resp.accessToken;
            session.accessExpire = resp.accessExpire;
            session.refreshAfter = resp.refreshAfter;

            return resp;
        }

        public async Task<GetServerListResp> GetServerList()
        {
            string json = JsonUtility.ToJson(new GetServerListReq{});
            var headers = new Dictionary<string, string>
            {
                { "Authorization", session.accessToken }
            };
            string result = await _G.HttpCli.Post("/servermanager/getServerList", json, headers);
            GetServerListResp resp = JsonUtility.FromJson<GetServerListResp>(result);

            return resp;
        }


        public async Task<LoginServerResp> LoginServer(string serverId)
        {
            string json = JsonUtility.ToJson(new LoginServerReq
            {
                serverId = serverId
            });

            string result = await _G.HttpCli.Post("/login/fastLogin", json);
            LoginServerResp resp = JsonUtility.FromJson<LoginServerResp>(result);

            return resp;
        }

        public async Task<EnterServerResp> EnterServer(string serverCode)
        {
            string json = JsonUtility.ToJson(new EnterServerReq{
                serverCode = serverCode
            });
            var headers = new Dictionary<string, string>
            {
                { "Authorization", session.accessToken }
            };

            string result = await _G.HttpCli.Post("/login/enterServer", json, headers);

            EnterServerResp resp = JsonUtility.FromJson<EnterServerResp>(result);

            return resp;
        }
    }


}