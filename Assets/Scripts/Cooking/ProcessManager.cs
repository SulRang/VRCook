using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessManager : MonoBehaviour
{
    private static ProcessManager _instance;
    public static ProcessManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(ProcessManager)) as ProcessManager;

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

    public int[] idx = new int[] { 0, 0, 0 };
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < idx.Length; i++)
        {
            idx[i] = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
