using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Blade : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 mousePos;
    public Material material;
    private int currLines = 0;

    public GameObject newObjectPrefab;
    public GameObject newObjectPrefab2;
    public GameObject newObjectPrefab3;
    public GameObject newObjectPrefab4;
    public GameObject newObjectPrefab5;

    [SerializeField] public Text BlueText;
    [SerializeField] public Text RedText;
    [SerializeField] public Text GreenText;
    [SerializeField] public Text YellowText;
    [SerializeField] public Text PinkText;
    [SerializeField] public int BlueScore = 0;
    [SerializeField] public int RedScore = 0;
    [SerializeField] public int greenScore = 0;
    [SerializeField] public int YellowScore = 0;
    [SerializeField] public int PinkScore = 0;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (line == null)
            {
                CreateLine();
            }

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            line.SetPosition(0, mousePos);
            line.SetPosition(1, mousePos);
        }
        else if (Input.GetMouseButtonUp(0) && line)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            line.SetPosition(1, mousePos);
            CheckForIntersections();
            line = null;
            currLines++;
        }
        else if (Input.GetMouseButton(0) && line)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            line.SetPosition(1, mousePos);
        }
    }

    public void CreateLine()
    {
        line = new GameObject("Line" + currLines).AddComponent<LineRenderer>();
        line.material = material;
        line.positionCount = 2;
        line.startWidth = 0.15f;
        line.endWidth = 0.15f;
        line.useWorldSpace = true;
        line.numCapVertices = 50;
    }

    void CheckForIntersections()
    {
        Collider2D[] colliders = Physics2D.OverlapAreaAll(line.GetPosition(0), line.GetPosition(1));

        List<GameObject> RedobjectsToDestroy = new List<GameObject>();
        List<GameObject> GreenobjectsToDestroy = new List<GameObject>();
        List<GameObject> BlueobjectsToDestroy = new List<GameObject>();
        List<GameObject> PinkobjectsToDestroy = new List<GameObject>();
        List<GameObject> YellowobjectsToDestroy = new List<GameObject>();

        List<Vector3> destroyedObjectPositions = new List<Vector3>();

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Red") || collider.CompareTag("Green") || collider.CompareTag("Blue") || collider.CompareTag("Pink") || collider.CompareTag("Yellow"))
            {

                if (collider.CompareTag("Red"))
                {
                    RedobjectsToDestroy.Add(collider.gameObject);
                   
                }
                else if (collider.CompareTag("Green"))
                {
                    GreenobjectsToDestroy.Add(collider.gameObject);
                   
                }
                else if (collider.CompareTag("Blue"))
                {
                    BlueobjectsToDestroy.Add(collider.gameObject);
                   
                }
                else if (collider.CompareTag("Pink"))
                {
                    PinkobjectsToDestroy.Add(collider.gameObject);
                  
                }
                else if (collider.CompareTag("Yellow"))
                {
                    YellowobjectsToDestroy.Add(collider.gameObject);
                   
                }
            }
        }

        if (RedobjectsToDestroy.Count >= 3)
        {
            foreach (GameObject obj in RedobjectsToDestroy)
            {
                Destroy(obj);
                RedScore++;
                RedText.text = "Red : " + RedScore.ToString();
                Instantiate(newObjectPrefab, obj.transform.position, Quaternion.identity);
            }

            Destroy(line.gameObject);
        }
        if (GreenobjectsToDestroy.Count >= 3)
        {
            foreach (GameObject obj in GreenobjectsToDestroy)
            {
                Destroy(obj);
                greenScore++;
                GreenText.text = "Green : " + greenScore.ToString();
                Instantiate(newObjectPrefab2, obj.transform.position, Quaternion.identity);
            }

            Destroy(line.gameObject);
        }
        if (BlueobjectsToDestroy.Count >= 3)
        {
            foreach (GameObject obj in BlueobjectsToDestroy)
            {
                Destroy(obj);
                BlueScore++;
                BlueText.text = "Blue : "+ BlueScore.ToString();
                Instantiate(newObjectPrefab3, obj.transform.position, Quaternion.identity);
            }

            Destroy(line.gameObject);
        }
        if (PinkobjectsToDestroy.Count >= 3)
        {
            foreach (GameObject obj in PinkobjectsToDestroy)
            {
                Destroy(obj);
                PinkScore++;
                PinkText.text = "Pink : " + PinkScore.ToString();
                Instantiate(newObjectPrefab4, obj.transform.position, Quaternion.identity);
            }

            Destroy(line.gameObject);
        }
        if (YellowobjectsToDestroy.Count >= 3 )
        {
            foreach (GameObject obj in YellowobjectsToDestroy)
            {
                Destroy(obj);
                YellowScore++;
                YellowText.text = "Yellow : " +YellowScore.ToString();
                Instantiate(newObjectPrefab5, obj.transform.position, Quaternion.identity);
            }

            Destroy(line.gameObject);
        }
    }
}
