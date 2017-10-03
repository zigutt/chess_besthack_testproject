using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapInit : MonoBehaviour {
    public Transform gameArea;
    public GameObject saska;
    public Material[] team = new Material[3];
    public Text txt_Team;
    int count = 0;
	// Use this for initialization
	void Start () {
        foreach (Transform child in gameArea)
        {
            //Debug.Log("checking..");
            if(child.tag == "place")
            {
                //Debug.Log("found");
                if (child.GetComponent<Holder>().firsttimeSpawn == true)
                {
                    Object temp = Instantiate(saska, new Vector3(child.position.x, child.position.y, child.position.z), Quaternion.Euler(-90,0,0));
                    temp.name = "Saska " + count++;
                    GameObject.Find(temp.name).GetComponent<MeshRenderer>().material = team[child.GetComponent<Holder>().colorforSpawn-1];
                    GameObject.Find(temp.name).GetComponent<SaskaController>().team = child.GetComponent<Holder>().colorforSpawn - 1;
                    child.GetComponent<Holder>().saska = GameObject.Find(temp.name);
                    GameObject.Find(temp.name).GetComponent<SaskaController>().place = child.gameObject;
                }
            }
        }
        txt_Team.text = "Turn: White goes first";
        GetComponent<PlayerController>().player_Turn = 1;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
