using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityRawInput;

public class SerifProgress : MonoBehaviour
{
    SerifManager serifManager;
    int index = -1;
    // Start is called before the first frame update
    void Start()
    {
        RawKeyInput.Start(true);
        RawKeyInput.OnKeyDown += LogKeyDown;
        serifManager = FindObjectOfType<SerifManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LogKeyDown(RawKey key)
    {
        if (key == RawKey.T)
        {
            NextProgress();
        }
    }

    private void OnDisable()
    {
        RawKeyInput.Stop();
        RawKeyInput.OnKeyDown -= LogKeyDown;
    }


    public void NextProgress()
    {
        if (index < serifManager.SerifListCount-1)
        {
            index++;
        }
        serifManager.SetElementColor(index);
    }
    public void PreviousProgress()
    {
        if (index == -1) return;
        if (index > 0)
        {
            index--;
        }
        serifManager.SetElementColor(index);
    }
    public void ElemetDown() { PreviousProgress(); }
    public void ElemetUp() { NextProgress(); }

    public void Delete(int i)
    {
        if (index > i+1)
        {
            index--;
            serifManager.SetElementColor(index);
        }
    }
}
