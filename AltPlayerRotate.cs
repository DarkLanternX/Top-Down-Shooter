using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AltPlayerRotate : MonoBehaviour
{
    public float speed;
    PhotonView view;
    void Update()
    {
        // Touch controls for rotation
        
        
       // if (view.IsMine)
       // {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))  //Ignore UI touch
                {
                    return;
                }
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                transform.Rotate(0, touchDeltaPosition.x * speed, 0);
            }
       // }
    }
}
