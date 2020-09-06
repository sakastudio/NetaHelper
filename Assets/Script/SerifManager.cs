using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerifManager : MonoBehaviour
{
    [SerializeField]
    SerifElement ElementPrefab;

    List<SerifElement> SerifList = new List<SerifElement>();

    [SerializeField]
    Color SelectedColor;
    [SerializeField]
    Color UnSelectedColor;

    SerifProgress serifProgress;
    // Start is called before the first frame update
    void Start()
    {
        serifProgress = FindObjectOfType<SerifProgress>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSerif(string text = "")
    {
        var g =Instantiate(ElementPrefab);
        g.transform.SetParent(transform, false);
        SerifList.Add(g.GetComponent<SerifElement>());
        SerifList[SerifList.Count - 1].SetInitData(SerifList.Count - 1,this);
        SerifList[SerifList.Count - 1].input.text = text;
    }

    public void Down(int i)
    {
        if(i < SerifList.Count-1)
        {
            SerifList[i].transform.SetSiblingIndex(SerifList[i].transform.GetSiblingIndex() + 1);

            SerifList[i].SetIndex(i + 1);
            SerifList[i+1].SetIndex(i);

            var w = SerifList[i];
            SerifList[i] = SerifList[i + 1];
            SerifList[i + 1] = w;

            serifProgress.ElemetUp();
        }
    }
    public void Up(int i)
    {
        if (i > 0)
        {
            SerifList[i].transform.SetSiblingIndex(SerifList[i].transform.GetSiblingIndex() - 1);

            SerifList[i].SetIndex(i - 1);
            SerifList[i - 1].SetIndex(i);

            var w = SerifList[i];
            SerifList[i] = SerifList[i - 1];
            SerifList[i - 1] = w;

            serifProgress.ElemetDown();
        }
    }

    public void Delete(int index)
    {
        var g = SerifList[index].gameObject;
        SerifList.Remove(SerifList[index]);
        Destroy(g);
        for (int i = 0; i < SerifList.Count; i++)
        {
            SerifList[i].SetIndex(i);
        }

        serifProgress.ElemetDown();
    }

    public void SetElementColor(int index)
    {
        for (int i = 0; i < SerifList.Count; i++)
        {
            SerifList[i].SetSelectColor(UnSelectedColor);
        }
        GUIUtility.systemCopyBuffer = SerifList[index].input.text;
        SerifList[index].SetSelectColor(SelectedColor);
    }

    public int SerifListCount
    {
        get
        {
            return SerifList.Count;
        }
    }

    public List<SerifElement> GetSerifList
    {
        get
        {
            return SerifList;
        }
    }
}
