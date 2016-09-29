using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class KeywordScript : MonoBehaviour
{
    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;
    public GameObject cube;
    public GameObject sphere;

    void Start()
    {
        m_Keywords = new string[2];
        m_Keywords[0] = "Cube";
        m_Keywords[1] = "Sphere";
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {

        float newX = UnityEngine.Random.Range(-10, 10);
        float newY = UnityEngine.Random.Range(-10, 10);
        float newZ = UnityEngine.Random.Range(5, 10);

       if (args.text == m_Keywords[0])
        {
            Instantiate(cube, new Vector3(newX, newY, newZ), Quaternion.identity);
        }
        if (args.text == m_Keywords[1])
        {
            Instantiate(sphere, new Vector3(newX, newY, newZ), Quaternion.identity);
        }
    }
}