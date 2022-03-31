using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelentBullet : MonoBehaviour
{

    public float repelVelocity;

    public SpellWeapon InitialValuesSpellWeapon;
    // Start is called before the first frame update
    void Start()
    {
        repelVelocity = InitialValuesSpellWeapon.fuerza_de_empuje;
        
    }

    

    // Update is called once per frame
    void Update()
    {
        foreach (Collider collider in Physics.OverlapSphere(this.transform.position, this.GetComponent<SphereCollider>().radius)){
             // calculate direction from target to me
             
            if(collider.gameObject.tag == "Element"){
                
                print(collider.gameObject.tag);
                Vector3 forceDirection = collider.gameObject.transform.up + this.transform.forward;
                //collider.GetComponent<Rigidbody>().AddForce(forceDirection * 2000.0f);
                //his.GetComponent<SphereCollider>().radius = 50;
                collider.GetComponent<Rigidbody>().velocity = forceDirection * repelVelocity;
                Destroy(this);
                
            }
             
             
         }
    }
}
