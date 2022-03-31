using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelfSpell : MonoBehaviour
{

    public float speedRotation;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate (new Vector3(0,0,1) * speedRotation * Time.deltaTime, Space.World);        
    }
}
