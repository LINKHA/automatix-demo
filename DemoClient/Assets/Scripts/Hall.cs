using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hall : MonoBehaviour
{
    public Button beginMatchBtn;
    public Button cancelMatchBtn;

    public GameObject waitObj;
    public GameObject matchObj;
    // Start is called before the first frame update
    void Start()
    {
        beginMatchBtn.onClick.AddListener(OnMatch);
        cancelMatchBtn.onClick.AddListener(CancelMatch);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMatch() {
        waitObj.SetActive(false);
        matchObj.SetActive(true);
    }

    void CancelMatch()
    {
        waitObj.SetActive(true);
        matchObj.SetActive(false);
    }
}
