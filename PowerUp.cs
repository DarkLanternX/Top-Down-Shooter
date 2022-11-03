using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject gun;
    GunFIre firerate;


    private void Start()
    {
        firerate = gun.GetComponent<GunFIre>();
    }



    private void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Buff Activated");
            firerate.isEmpowered = true;
            gameObject.SetActive(false);
            Invoke("Debuff", 10f);
        }
    }

    private void Debuff()
    {
        firerate.isEmpowered = false;
        Debug.Log("Buff Expired");
    }
}
