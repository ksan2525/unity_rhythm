using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class notesScript : MonoBehaviour
{
    
    public int lineNum;
    private GameController _gameController;
    private bool isInLine = false;
    private KeyCode _lineKey;

    Vector3 notes;
    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        _lineKey = GameUtil.GetKeyCodeByLineNum(lineNum);
        notes =-transform.forward;
        // -transform.up * (Mathf.Sqrt(6) - Mathf.Sqrt(2)) + -transform.forward * (Mathf.Sqrt(3) + Mathf.Sqrt(2))
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += notes * 10 * Time.deltaTime;

        if (this.transform.position.y < -5.0f)
        {
            
            Destroy(this.gameObject);
        }

        Debug.Log(isInLine);
        if (isInLine)
        {
            CheckInput(_lineKey);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hantei")
        {
            isInLine = true;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "hantei")
        {
            isInLine = false;
        }
        
    }

    void CheckInput (KeyCode key)
    {
        Debug.Log("‚¿‚¥‚Á‚­‚¢‚ñ‚Õ‚Á‚Æ");
        if (Input.GetKeyDown(key))
        {            
            
            _gameController.GoodTimingFunc(lineNum);
            Destroy (this.gameObject);
        }
    }
}
