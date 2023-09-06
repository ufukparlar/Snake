using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{



    public GameObject tail;
    List<GameObject> tails;
    public GameObject endgame_pnl;

    Vector3 old_coordinate;
    GameObject old_tail;
    float speed = 15.0f;


    private void OnTriggerEnter(Collider other)
    {
        

        if(other.gameObject.tag== "wall" || other.gameObject.tag == "tail")
        {

            endgame_pnl.SetActive(true);
            Time.timeScale = 0.0f;


        }
    }

    public void play_again()
    {

        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");

    }






    void Start()
    {
        // oyun baþlarken yýlana 5 adet kuyruk ekler

        tails = new List<GameObject>();

        for (int i = 0; i < 5; i++)
        {


            GameObject new_tail = Instantiate(tail, transform.position, Quaternion.identity);
            tails.Add(new_tail);

        }



        InvokeRepeating("hareket_et", 0.0f, 0.1f);



    }


    void hareket_et()
    {

        old_coordinate = transform.position;
        
        
        
        transform.Translate(0, 0, speed * Time.deltaTime);

        follow_tail();





    }

    public void tail_pluss()
    {
        GameObject new_tail = Instantiate(tail, transform.position, Quaternion.identity);
        tails.Add(new_tail);


    }

    void follow_tail() {
        

            tails[0].transform.position = old_coordinate;
            old_tail = tails[0];
            tails.RemoveAt(0);
            tails.Add(old_tail);

         
    }


    public void turn(float aci)
    {


        transform.Rotate(0, aci, 0);


    }
}
