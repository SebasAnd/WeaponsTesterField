using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBullet : MonoBehaviour
{
    public GameObject target;

    public float gravityForce;

    public GravityWeapon InitialValuesGravityWeapon;


    // Start is called before the first frame update
    void Start()
    {
       
        gravityForce = InitialValuesGravityWeapon.fuerza_de_gravedad;
       
    }

    
   

    // Update is called once per frame
    void Update()
    {
        foreach (Collider collider in Physics.OverlapSphere(this.transform.position, this.GetComponent<SphereCollider>().radius)){
             // calculate direction from target to me
             
            if(collider.gameObject.tag == "Element"){
                
                Vector3 forceDirection = this.target.transform.position - collider.transform.position;
                collider.GetComponent<Rigidbody>().velocity = forceDirection * gravityForce;
                //collider.transform.Translate(this.target.transform.position * gravityForce * Time.deltaTime);
                
            }
             
         }

               
    }
}
