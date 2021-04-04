using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class notesScript : MonoBehaviour
{

    Vector3 notes;
    // Start is called before the first frame update
    void Start()
    {
        notes = Vector3.forward + Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += notes * -10 * Time.deltaTime;
        if (this.transform.position.y < -5.0f)
        {
            Debug.Log("false");
            Destroy(this.gameObject);
        }
    }

    
    
}
