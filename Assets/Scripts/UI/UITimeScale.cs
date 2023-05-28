using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimeScale : MonoBehaviour
{
    float[] timeScale = { 1, 2.5f , 5 };
    int idx = 0;

    [SerializeField]
    Text scaleText;

    [SerializeField]
    Button buttonRight;

    [SerializeField]
    Button buttonLeft;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < timeScale.Length; i++)
        {
            if (Mathf.Abs(ThermalChangeController.instance.timerScale - timeScale[i]) < 0.4f)
                idx = i;
        }
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        scaleText.text = "x" + timeScale[idx].ToString();
        if (idx == 2)
            buttonRight.interactable = false;
        else if (idx == 0)
            buttonLeft.interactable = false;
        else
        {
            buttonLeft.interactable = true;
            buttonRight.interactable = true;
        }

    }

    public void OnRight()
    {
        if (idx < 2)
        {
           idx += 1;
            ThermalChangeController.instance.timerScale = timeScale[idx];
            scaleText.text = "x" + timeScale[idx].ToString();
            buttonLeft.interactable = true;
            if (idx == 2)
                buttonRight.interactable = false;

        }
    }


    public void OnLeft()
    {
        if (idx > 0)
        {
            idx -= 1;
            ThermalChangeController.instance.timerScale = timeScale[idx];
            scaleText.text = "x" + timeScale[idx].ToString();
            buttonRight.interactable = true;
            if (idx == 0)
                buttonLeft.interactable = false;
        }
    }
}
