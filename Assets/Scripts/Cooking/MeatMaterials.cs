using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatMaterials : MonoBehaviour
{
    private static MeatMaterials _instance;
    public static MeatMaterials Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(MeatMaterials)) as MeatMaterials;

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

    public List<TemperatureMaterial> temperatureMaterials = new List<TemperatureMaterial>();

    public Material returnMat;

    public Material GetMostRelevantMat()
    {
        return returnMat;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMat()
    {
        if (temperatureMaterials.Count != 0)
        {
            Material tmp = temperatureMaterials[0].material;
            float minDiff = 10000.0f;
            for (int i = 0; i < temperatureMaterials.Count; i++)
            {
                float diff = Mathf.Min(Mathf.Abs(CheckSteakCook.instance.maxSteakOutsideTemperature - temperatureMaterials[i].minTemperature),
                                       Mathf.Abs(CheckSteakCook.instance.maxSteakOutsideTemperature - temperatureMaterials[i].maxTemperature));
                if (diff < minDiff)
                {
                    tmp = temperatureMaterials[i].material;
                    minDiff = diff;
                }

            }
            returnMat = tmp;
        }
    }
}
