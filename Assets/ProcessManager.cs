using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessManager : MonoBehaviour
{
    private static ProcessManager _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static ProcessManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
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
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
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
