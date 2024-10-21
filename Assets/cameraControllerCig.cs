using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class cameraControllerCig : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -10);
    public float smoothTime = 0.25f;
    Vector3 currentVelocity;

    public PostProcessingProfile BlurPP;
    public PostProcessingBehaviour PB;
    public PlayerCigController playerCig;

    // Start is called before the first frame update
    void Start()
    {
        PB = GetComponent<PostProcessingBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (playerCig.isDead)
        {
            PB.profile = BlurPP;
        }
        */
    }

    private void FixedUpdate()
    {
       
        transform.position = Vector3.SmoothDamp(
         transform.position,
         target.position + offset,
         ref currentVelocity,
         smoothTime
         );

    }
}
