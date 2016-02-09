using UnityEngine;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml.Linq;
using System.Linq;
using System.Text;

public class HightScoreHelper : MonoBehaviour {

    public Text[] TextPlayerScore;
    public Text[] TextScore;

    private void AddToFileXML()
    {
        string filepath = Application.dataPath + @"/Data/hightScores.xml";
        XElement root = XElement.Load(filepath);
        var scores =
            (from score in root.Elements("allScores")
            let n = (string)score.Element("name")
            let p = (int)score.Element("score")
            orderby p descending
            select new { name = n, score = p }).Take(10);
        int i = 0;
        foreach (var myScore in scores) {
            TextPlayerScore[i].text = "" + (i + 1) + ". " + myScore.name;
            TextScore[i].text = myScore.score.ToString("0000");
            i++;
            }
    }


    void Start()
    {
        AddToFileXML();
    }

    public static void WriteToXml(string namePlayer)
    {

        string filepath = Application.dataPath + @"/Data/hightScores.xml";
        XmlDocument xmlDoc = new XmlDocument();

        if (File.Exists(filepath))
        {
            xmlDoc.Load(filepath);

            XmlElement elmRoot = xmlDoc.DocumentElement;

           // elmRoot.RemoveAll(); // remove all inside the transforms node.

            XmlElement scoresHelper = xmlDoc.CreateElement("allScores"); // create the rotation node.

            XmlElement name = xmlDoc.CreateElement("name"); // create the x node.
            name.InnerText = namePlayer; // apply to the node text the values of the variable.

            XmlElement score = xmlDoc.CreateElement("score"); // create the x node.
            score.InnerText = "" + Game.points; // apply to the node text the values of the variable.

            scoresHelper.AppendChild(name); // make the rotation node the parent.
            scoresHelper.AppendChild(score); // make the rotation node the parent.

            elmRoot.AppendChild(scoresHelper); // make the transform node the parent.

            xmlDoc.Save(filepath); // save file.
        }
    }
}
