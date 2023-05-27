using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCutChecking : MonoBehaviour
{
    [SerializeField]
    GameObject[] breadCols;

    private static BreadCutChecking _instance;
    public static BreadCutChecking Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(BreadCutChecking)) as BreadCutChecking;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetCutting()
    {
        bool isCutAll = true;
        foreach(GameObject gameObj in breadCols)
        {
            if(gameObj.activeSelf)
                isCutAll = false;
        }
        return isCutAll;
    }
}
