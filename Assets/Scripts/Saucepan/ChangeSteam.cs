using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSteam : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particleSys;
    ParticleSystem.MainModule particleMain;
    float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        particleMain = particleSys.main;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        particleMain.startColor = new Color(1,1,1, 0.01f * time);
    }
}
