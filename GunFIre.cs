using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunFIre : MonoBehaviour
{

    public ParticleSystem flash;
    public AudioClip shoot;
    //public Button button;    // firebutton optional
    public float damage;
    public float range;
    public GameObject explode;
    public bool isEmpowered = false;
    //public static int IgnoreRaycastLayer;
    GameObject target;                         // last collider hit
    public Vector3 collision = Vector3.zero;   //coords of colliders hit by raycast


   

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            fx();
            Shoot();
        }
        if (isEmpowered == true)            //Checks if gun is buffed
        {
            if (Input.GetButton("Fire2"))
            {
                flash.Play();
                Shoot();
            }
        }
    }

    public void fx()
    {
        flash.Play();
        AudioSource.PlayClipAtPoint(shoot, transform.position, 1);
    }

    public void Shoot()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 20f, Color.green);
        if (Physics.Raycast(transform.position, this.transform.right, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            
            if (target != null && target.tag == "Enemy")
            {
             target.TakeDamage(damage);
            }
            else if ( target == null || target.tag != "Enemy")
            {
                target = null;
            }

            GameObject kill = Instantiate(explode, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(kill, 2f);
        }
    }

}
