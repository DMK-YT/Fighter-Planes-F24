using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -2.5f, 0) * Time.deltaTime * 3f);
        if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
    }
}