using System;

namespace Amx
{
    [Serializable]
    public class LoginFastLoginReq
    {
        public string mobile;
        public string password;
    }
    [Serializable]
    public class LoginFastLoginResp
    {
        public string accessToken;
        public Int64 accessExpire;
        public Int64 refreshAfter;
    }
}