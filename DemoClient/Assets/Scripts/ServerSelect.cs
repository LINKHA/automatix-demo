using Amx;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ServerSelect : MonoBehaviour
{
    public Button buttonPrefab;
    public GameObject parentButtonPrefab;


    int maxRow = 1;
    int maxCol = 9;
    // Start is called before the first frame update
    void Start()
    {
        GetServerListResp getServerListResp = null;
        Task.Run(async () =>
        {
            getServerListResp = await _G.AmxCli.GetServerList();

        }).Wait();

        List<GetServerListInfo> list = getServerListResp.list;

        InitMines(list);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void InitMines(List<GetServerListInfo> list)
    {
        int _maxRow = 1;
        int _maxCol = list.Count;

        int _centerX = (int)(parentButtonPrefab.GetComponent<RectTransform>().rect.width / 2);
        int _centerY = (int)(parentButtonPrefab.GetComponent<RectTransform>().rect.height / 2);
        int _buttonWidth = (int)(buttonPrefab.GetComponent<RectTransform>().rect.width);
        int _buttonHeight = (int)(buttonPrefab.GetComponent<RectTransform>().rect.height);

        for (int i = 0; i < _maxRow; i++)
        {
            int j = 0;
            foreach (GetServerListInfo serverInfo in list)
            {
                Vector3 _pos = new Vector3(_centerX + (i - _maxRow / 2) * _buttonWidth, _centerY + (j - _maxCol / 2) * _buttonHeight);
                Button _button = Button.Instantiate(buttonPrefab, _pos, Quaternion.identity, parentButtonPrefab.transform);
                _button.onClick.AddListener(() => EnterServerOnClick(serverInfo.serverId));
                j++;
            }
        }
    }

    void EnterServerOnClick(string serverId) {
        LoginServerResp loginServerResp = null;
        Task.Run(async () =>
        {
            loginServerResp = await _G.AmxCli.LoginServer(serverId);
        }).Wait();
        string serverCode = loginServerResp.serverCode;

        EnterServerResp enterServerResp = null;
        Task.Run(async () =>
        {
            enterServerResp = await _G.AmxCli.EnterServer(serverCode);
        }).Wait();
        _G.RtIpstr = enterServerResp.host;
        _G.RtPortStr = enterServerResp.port;
    }
}
