using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithWeapon : MonoBehaviour
{

    GameObject player;

    GameObject currentWeapon;

    public GameObject RifleGoodLocation;
    public GameObject ParabolicRifle;

    public bool haveWeapon;


    bool canPickup;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        haveWeapon = false;
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Rifle" && haveWeapon == false){

            canPickup = true; 
            currentWeapon = other.gameObject;
            
            other.GetComponent<PRifleBehaviour>().collideIndicator.gameObject.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        canPickup = false;

        if(other.tag == "Rifle" ){
            other.GetComponent<PRifleBehaviour>().collideIndicator.gameObject.SetActive(false);

        }        
     
    }

    void Update()
    {
        if(canPickup == true) // if you enter thecollider of the objecct
        {

            if(Input.GetKey(KeyCode.E) && player.GetComponent<CharacterControl>().CurrentWeapon == null && haveWeapon == false){
                //currentWeapon.transform.rotation = Quaternion.identity;
                //currentWeapon.transform.localPosition = player.GetComponent<CharacterControl>().WeaponLocation.transform.localPosition;
                //currentWeapon.transform.localRotation = player.GetComponent<CharacterControl>().WeaponLocation.transform.localRotation;
                //other.transform.position = player.GetComponent<CharacterControl>().WeaponLocation.transform.position;

                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                currentWeapon.transform.position = player.GetComponent<CharacterControl>().WeaponLocation.transform.position; // sets the position of the object to your hand position
                currentWeapon.transform.parent = player.GetComponent<CharacterControl>().WeaponLocation.transform;
                

                if(currentWeapon.GetComponent<PRifleBehaviour>().weapon == "Gravity"){
                    currentWeapon.SetActive(false);
                    RifleGoodLocation.SetActive(true);
                }
                if(currentWeapon.GetComponent<PRifleBehaviour>().weapon == "Parabolic"){
                    currentWeapon.SetActive(false);
                    ParabolicRifle.SetActive(true);
                }
                

                //currentWeapon.transform.SetParent(player.GetComponent<CharacterControl>().WeaponLocation.transform);
                player.GetComponent<CharacterControl>().CurrentWeapon = currentWeapon.gameObject;
                player.GetComponent<CharacterControl>().changeState("Rifle");
                haveWeapon = true;
                
            }

            
        }
        if (Input.GetKey(KeyCode.Q) && player.GetComponent<CharacterControl>().CurrentWeapon != null && haveWeapon == true) 
        {   

            if(currentWeapon.GetComponent<PRifleBehaviour>().weapon == "Gravity"){
                    currentWeapon.SetActive(true);
                    RifleGoodLocation.SetActive(false); 
                }
            if(currentWeapon.GetComponent<PRifleBehaviour>().weapon == "Parabolic"){
                    currentWeapon.SetActive(true);
                    ParabolicRifle.SetActive(false); 
                }
                
            currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
            currentWeapon.GetComponent<Rigidbody>().velocity = this.transform.forward * 10.0f; 
             currentWeapon.transform.parent = null; 
             player.GetComponent<CharacterControl>().CurrentWeapon = null;
            player.GetComponent<CharacterControl>().changeState("None");
            haveWeapon = false;
            
            
        }
        
    }

    
}
