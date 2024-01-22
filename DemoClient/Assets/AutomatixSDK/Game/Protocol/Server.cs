using System;
using System.Collections.Generic;

namespace Amx
{
    [Serializable]
    public class GetServerListInfo {
		public string serverId;
        public string name;
		public Int64  serverType;
		public Int64 switchValue;
		public Int64  startTime;
		public Int64  area;
		public string tags;
		public Int64  maxOnline;
		public Int64  maxQueue;
		public Int64  maxSign;
		public string templateValue;
	}
    [Serializable]
    public class GetServerListReq
	{
	}
    [Serializable]
    public class GetServerListResp
	{
		public int returnCode;
		public List<GetServerListInfo> list;
	}



}