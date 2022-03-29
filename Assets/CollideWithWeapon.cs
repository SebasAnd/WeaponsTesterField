using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithWeapon : MonoBehaviour
{

    GameObject player;

    GameObject currentWeapon;

    public GameObject RifleGoodLocation;


    bool canPickup;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Rifle" ){
            canPickup = true; 
            currentWeapon = other.gameObject;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        canPickup = false; //when you leave the collider set the canpickup bool to false
     
    }

    void Update()
    {
        if(canPickup == true) // if you enter thecollider of the objecct
        {

            if(Input.GetKey(KeyCode.E)){
                //currentWeapon.transform.rotation = Quaternion.identity;
                //currentWeapon.transform.localPosition = player.GetComponent<CharacterControl>().WeaponLocation.transform.localPosition;
                //currentWeapon.transform.localRotation = player.GetComponent<CharacterControl>().WeaponLocation.transform.localRotation;
                //other.transform.position = player.GetComponent<CharacterControl>().WeaponLocation.transform.position;

                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                currentWeapon.transform.position = player.GetComponent<CharacterControl>().WeaponLocation.transform.position; // sets the position of the object to your hand position
                currentWeapon.transform.parent = player.GetComponent<CharacterControl>().WeaponLocation.transform;
                currentWeapon.SetActive(false);
                RifleGoodLocation.SetActive(true);

                //currentWeapon.transform.SetParent(player.GetComponent<CharacterControl>().WeaponLocation.transform);
                player.GetComponent<CharacterControl>().CurrentWeapon = currentWeapon.gameObject;
                player.GetComponent<CharacterControl>().changeState("Rifle");
                
            }

            
        }
        if (Input.GetKey(KeyCode.Q) && player.GetComponent<CharacterControl>().CurrentWeapon != null) // if you have an item and get the key to remove the object, again can be any key
        {   currentWeapon.SetActive(true);
            RifleGoodLocation.SetActive(false); 
            currentWeapon.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again
             currentWeapon.transform.parent = null; // make the object no be a child of the hands
             player.GetComponent<CharacterControl>().CurrentWeapon = null;
            player.GetComponent<CharacterControl>().changeState("None");
            
            
        }
        
    }

    
}
