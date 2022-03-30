using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBullet : MonoBehaviour
{
    public GameObject target;

    public bool attract;

    // Start is called before the first frame update
    void Start()
    {
        attract = true;
       
    }

    
   

    // Update is called once per frame
    void Update()
    {
        foreach (Collider collider in Physics.OverlapSphere(this.transform.position, this.GetComponent<SphereCollider>().radius)){
             // calculate direction from target to me
             
            if(collider.gameObject.tag == "Element"){
                print(collider.gameObject.tag);
                Vector3 forceDirection = this.target.transform.position- collider.transform.position;
                //collider.GetComponent<Rigidbody>().AddForce(forceDirection * 2000.0f);
                collider.transform.Translate(forceDirection * 2.0f * Time.deltaTime);
                
            }
             // apply force on target towards me
             
         }

               
    }
}
