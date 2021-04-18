using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


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
        notes = -transform.up * 0.495f + -transform.forward * Mathf.Sqrt(3);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += notes * 1 * Time.deltaTime;

        if (this.transform.position.y < -5.0f)
        {
            Debug.Log("false");
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
        isInLine = true;
    }

    void OnTriggerExit(Collider other)
    {
        isInLine = false;
    }

    void CheckInput (KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            _gameController.GoodTimingFunc(lineNum);
            Destroy (this.gameObject);
        }
    }
}
