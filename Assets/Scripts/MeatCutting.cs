using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatCutting : MonoBehaviour
{
    [SerializeField]
    Material material;
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Knife" && timer > 1.0f)
        {
            GameObject[] gameObjects = ObjectCutting.Cut(gameObject, collision.transform.position, Vector3.left, material);
            timer = 0;
        }
    }
}
