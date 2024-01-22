using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
        public async Task<LoginFastLoginResp> FastLogin(string mobile, string password)
        {
            string json = JsonUtility.ToJson(new LoginFastLoginReq
            {
                mobile = mobile,
                password = password
            });

            string result = await _G.HttpCli.Post("/login/fastLogin", json);
            LoginFastLoginResp resp = JsonUtility.FromJson<LoginFastLoginResp>(result);
            
            session.accessToken = resp.accessToken;
            session.accessExpire = resp.accessExpire;
            session.refreshAfter = resp.refreshAfter;

            return resp;
        }

        public async Task<GetServerListResp> GetServerList()
        {
            string json = JsonUtility.ToJson(new GetServerListReq{});

            string result = await _G.HttpCli.Post("/servermanager/getServerList", json, new Dictionary<string, string>
            {
                { "Authorization", session.accessToken }
            });

            GetServerListResp resp = JsonUtility.FromJson<GetServerListResp>(result);

            return resp;
        }
    }


}