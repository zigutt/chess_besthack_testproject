using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public int player_Turn;
    public bool making_Turn = false;
    public int[] player_Saske = new int[3];
    public float _cam;
    public float _speed;
    public GameObject choosed_Saska;
    public Text txt_Team;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animateTurn();
        if (player_Saske[0] == 0 && player_Turn == 1) player_Turn = 2;
        else if (player_Saske[1] == 0 && player_Turn == 2) player_Turn = 3;
        else if (player_Saske[2] == 0 && player_Turn == 3) player_Turn = 1;
        if (Input.GetMouseButtonUp(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "saska")
                {
                    player_Saske[hit.transform.gameObject.GetComponent<SaskaController>().team]--;
                    Destroy(hit.transform.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonUp(2))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "saska")
                {
                    hit.transform.rotation = Quaternion.Euler(90, 0, 0);
                    hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.4f, hit.transform.position.z);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "saska")
                {
                    if ((hit.transform.gameObject.GetComponent<SaskaController>().team + 1) == player_Turn && !making_Turn)
                    {
                        choosed_Saska = hit.transform.gameObject;
                        hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.5f, hit.transform.position.z);
                        Debug.Log("choosed");
                        making_Turn = true;
                       /* player_Turn++;
                        if (player_Turn == 4) player_Turn = 1;
                        if (true)
                            switch (player_Turn)
                            {
                                case 1: _cam = 60; _speed = transform.rotation.eulerAngles.y + 120; break;
                                case 2: _cam = 180; _speed = transform.rotation.eulerAngles.y + 120; break;
                                case 3: _cam = 300; _speed = transform.rotation.eulerAngles.y + 120; break;
                            }*/
                    }
                    else if ((hit.transform.gameObject.GetComponent<SaskaController>().team + 1) == player_Turn && making_Turn)
                    {
                        choosed_Saska.transform.position = new Vector3(choosed_Saska.transform.position.x, choosed_Saska.transform.position.y - 0.5f, choosed_Saska.transform.position.z);
                        choosed_Saska = hit.transform.gameObject;
                        hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.5f, hit.transform.position.z);
                        Debug.Log("rechoosed");
                        /* player_Turn++;
                         if (player_Turn == 4) player_Turn = 1;
                         if (true)
                             switch (player_Turn)
                             {
                                 case 1: _cam = 60; _speed = transform.rotation.eulerAngles.y + 120; break;
                                 case 2: _cam = 180; _speed = transform.rotation.eulerAngles.y + 120; break;
                                 case 3: _cam = 300; _speed = transform.rotation.eulerAngles.y + 120; break;
                             }*/
                    }
                }
                else if (hit.collider.gameObject.tag == "place")
                {
                    if (hit.transform.gameObject.GetComponent<Holder>().color == 1 && making_Turn)
                    {
                        /*if (hit.transform.gameObject.name == "Cube_042" || hit.transform.gameObject.name == "Cube_081" || hit.transform.gameObject.name == "Cube_034")
                            if (choosed_Saska.GetComponent<SaskaController>().place.name == "Cube_017" || choosed_Saska.GetComponent<SaskaController>().place.name == "Cube_049" || choosed_Saska.GetComponent<SaskaController>().place.name == "Cube_057" || choosed_Saska.GetComponent<SaskaController>().place.name == "Cube_026" || choosed_Saska.GetComponent<SaskaController>().place.name == "Cube_075" || choosed_Saska.GetComponent<SaskaController>().place.name == "Cube_083") return;
                        if (Vector3.Distance(hit.transform.position, choosed_Saska.GetComponent<SaskaController>().place.transform.position) > 1.25f)
                        {
                            Debug.Log(Vector3.Distance(hit.transform.position, choosed_Saska.GetComponent<SaskaController>().place.transform.position));
                            return;
                        }*/
                       // if (!checkTurn(choosed_Saska.GetComponent<SaskaController>().place, hit.transform.gameObject)) return;
                        Debug.Log(Vector3.Distance(hit.transform.position, choosed_Saska.GetComponent<SaskaController>().place.transform.position));
                        if (hit.transform.gameObject.GetComponent<Holder>().saska != null) return;
                        hit.transform.GetComponent<Holder>().saska = choosed_Saska;
                        choosed_Saska.GetComponent<SaskaController>().place.GetComponent<Holder>().saska = null;
                        choosed_Saska.GetComponent<SaskaController>().place = hit.transform.gameObject;
                        choosed_Saska.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
                        Debug.Log("turn");
                        making_Turn = false;
                        player_Turn++;
                         if (player_Turn == 4) player_Turn = 1;
                         if (true)
                             switch (player_Turn)
                             {
                                 case 1: txt_Team.text = "Turn: White"; _cam = 60; _speed = transform.rotation.eulerAngles.y + 120; break;
                                 case 2: txt_Team.text = "Turn: Black"; _cam = 180; _speed = transform.rotation.eulerAngles.y + 120; break;
                                 case 3: txt_Team.text = "Turn: Yellow"; _cam = 300; _speed = transform.rotation.eulerAngles.y + 120; break;
                             }
                    }
                }
            }
        }
    }
    public void animateTurn(/*Vector3 cam,*/ /*Quaternion _cam*/)
    {
        if(transform.rotation.eulerAngles.y < _cam || (transform.rotation.eulerAngles.y >300 &&  _cam != 300))
        transform.RotateAround(Vector3.zero, Vector3.up, 40 * Time.fixedDeltaTime);
    }
   /* public bool checkTurn(GameObject from, GameObject to)
    {
        //Ray ray = new Ray();
        Vector3 dir = to.transform.position- from.transform.position;
        Debug.DrawRay(from.transform.position, dir.normalized, Color.red, 300000);
        Ray ray = new Ray(from.transform.position, dir.normalized);
        RaycastHit[] cast = Physics.SphereCastAll(ray,  3f, Vector3.Distance(from.transform.position, to.transform.position));
        int white = 0;
        int black = 0;
        int saske = 0;
        
        foreach (RaycastHit c in cast)
        {
            if(c.transform.tag == "place")
            {
                Debug.Log("found place");
                Destroy(c.transform.gameObject);
                if (c.transform.gameObject.GetComponent<Holder>().color == 0) white++;
                else if (c.transform.gameObject.GetComponent<Holder>().color == 1) black++;
            }
            else if(c.transform.tag == "saska")
            {
                Debug.Log(c.transform.name);
                saske++;
            }
        }
        Debug.Log("W: " + white + " B: " + black + " S: " + saske);
        if (white == 2 && saske == 0 && black == 1) return true;
        if (white == 4 && saske == 1 && black == 3) return true;
        if (white == 1 || black == 1 || saske > 0) return false;
        return false;
    }*/
}
