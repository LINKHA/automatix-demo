using Amx;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ServerSelect : MonoBehaviour
{
    public GameObject buttonPrefab;
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

        InitMines(maxRow, list.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void InitMines(int _maxRow, int _maxCol)
    {
        int _centerX = (int)(parentButtonPrefab.GetComponent<RectTransform>().rect.width / 2);
        int _centerY = (int)(parentButtonPrefab.GetComponent<RectTransform>().rect.height / 2);
        int _buttonWidth = (int)(buttonPrefab.GetComponent<RectTransform>().rect.width);
        int _buttonHeight = (int)(buttonPrefab.GetComponent<RectTransform>().rect.height);

        for (int i = 0; i < _maxRow; i++)
        {
            for (int j = 0; j < _maxCol; j++)
            {

                Vector3 _pos = new Vector3(_centerX + (i - _maxRow / 2) * _buttonWidth, _centerY + (j - _maxCol / 2) * _buttonHeight);
                GameObject _button = GameObject.Instantiate(buttonPrefab, _pos, Quaternion.identity, parentButtonPrefab.transform);
            }
        }
    }
}
