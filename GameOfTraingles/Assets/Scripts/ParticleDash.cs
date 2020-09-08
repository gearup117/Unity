using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDash : MonoBehaviour
{
    public Transform transform;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = player.transform.rotation.z;
        x = x - 180;

        transform.eulerAngles = Vector3.forward * x;

    }
}
