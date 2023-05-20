using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldGroup : MonoBehaviour
{
    [SerializeField]
    GameObject potatoObj;
    [SerializeField]
    GameObject potatoPieceObj;
    [SerializeField]
    bool isGroup = false;

    public float ctime = 0.0f;
    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 0, 0);
        //test
        /*ctime += Time.deltaTime;
        if (ctime >= 10f)
        {
            if (!isActive)
                HoldActive();
            else if (isActive)
                HoldDeActive();
            ctime = 0f;
        }*/


    }

    public void HoldActive()
    {
        if (isGroup)
        {
            potatoObj.SetActive(false);
            potatoPieceObj.transform.position = potatoObj.transform.position;
            potatoPieceObj.SetActive(true);
            isActive = true;
        }
    }

    public void HoldDeActive()
    {
        if (isGroup)
        {
            potatoPieceObj.SetActive(false);
            potatoObj.transform.position = potatoPieceObj.transform.position;
            potatoObj.SetActive(true);
            isActive = false;
        }
    }
}
