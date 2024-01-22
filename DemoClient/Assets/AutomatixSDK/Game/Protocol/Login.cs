using System;

namespace Amx
{
    [Serializable]
    public class FastLoginReq
    {
        public string mobile;
        public string password;
    }
    [Serializable]
    public class FastLoginResp
    {
        public string accessToken;
        public Int64 accessExpire;
        public Int64 refreshAfter;
    }
    [Serializable]
    public class LoginServerReq
    {
        public string serverId;
    }
    [Serializable]
    public class LoginServerResp
    {
        public Int64 returnCode;
        public string serverCode;
    }
    [Serializable]
    public class EnterServerReq
    {
        public string serverCode;
    }
    [Serializable]
    public class EnterServerResp
    {
        public Int64 returnCode;
        public string host;
        public string port;
    }
}