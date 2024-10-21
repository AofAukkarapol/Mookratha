using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private GameObject map;
    [SerializeField]
    private GameObject mapMark;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            map.transform.position = mapMark.transform.position;
        }
    }
}
