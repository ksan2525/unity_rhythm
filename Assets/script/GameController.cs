using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] notes;
    private float[] _timing;
    private int[] _lineNum;

    public string filePass;
    private int _notesCount = 0;

    private AudioSource _audioSource;
    private float _startTime = 0;

    public float timeOffset = -1;

    private bool _isPlaying = false;
    public GameObject startButton;

    public Text scoreText;
    private int _score = 0;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        _timing = new float[1024];
        _lineNum = new int[1024];
        LoadCSV();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlaying)
        {
            CheckNextNotes();
            scoreText.text = _score.ToString();
        }
    }

    public void StartGame()
    {
    
        startButton.SetActive(false);
        _startTime = Time.time;
        _audioSource.Play();
        _isPlaying = true;
    }

    void CheckNextNotes()
    {
        
        while (_timing[_notesCount] + timeOffset < GetMusicTime() && _timing[_notesCount] != 0)
        {
            Debug.Log(_notesCount);
            SpawnNotes(_lineNum[_notesCount]);
            _notesCount++;
        }
    }

    

    void SpawnNotes(int num)
    {
        Instantiate(notes[num],
            new Vector3(-2.0f + (1.0f * num), 8.5f, 25),
            Quaternion.Euler(-15f, 0f, 0f));
    }

    void LoadCSV()
    {
        TextAsset csv = Resources.Load(filePass) as TextAsset;
        Debug.Log(csv.text);
        StringReader reader = new StringReader(csv.text);

        int i = 0;
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (int j = 0; j < values.Length; j++)
            {
                _timing[i] = float.Parse(values[0]);
                _lineNum[i] = int.Parse(values[1]);
            }
            i++;
        }

    }

    float GetMusicTime()
    {
        return Time.time - _startTime;
    }

    public void GoodTimingFunc(int num)
    {
        Debug.Log("Line:" + num + "good!");
        Debug.Log(GetMusicTime());

        _score++;
    }
}
