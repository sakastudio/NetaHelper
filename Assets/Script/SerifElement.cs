using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SerifElement : MonoBehaviour
{
    [SerializeField]
    public InputField input;
    Image image;
    SerifManager serifManager;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        image = input.GetComponent<Image>();
    }

    private void OnEnable()
    {
    }

    public void SetInitData(int i, SerifManager s)
    {
        index = i;
        serifManager = s;
    }
    public void SetIndex(int i)
    {
        index = i;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ElemetUp()
    {
        serifManager.Up(index);
    }
    public void ElementDown()
    {
        serifManager.Down(index);
    }
    public void ElementDelete()
    {
        serifManager.Delete(index);
    }
    public void SetSelectColor(Color c)
    {
        image.color = c;
    }
}
