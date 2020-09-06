using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFB;
using System.IO;
using System; 
using System.Text;

public class csvIO : MonoBehaviour
{
    SerifManager serifManager;

    private void Start()
    {
        serifManager = FindObjectOfType<SerifManager>();
    }

    public void OpneCSV()
    {
        try
        {
            var path = StandaloneFileBrowser.OpenFilePanel("ファイルを開く", "", "csv", false);
            StreamReader sr = new StreamReader(path[0]);

            while (sr.Peek() != -1)
            {
                serifManager.AddSerif(sr.ReadLine());
            }
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public void ExportCSV()
    {
        var path = StandaloneFileBrowser.SaveFilePanel("ファイルを保存", "","", "csv");
        StreamWriter sw = new StreamWriter(path);

        List<SerifElement> Serif = serifManager.GetSerifList;

        for (int i = 0; i < Serif.Count; i++)
        {
            sw.WriteLine(Serif[i].input.text);
        }

        sw.Close();
    }
}
