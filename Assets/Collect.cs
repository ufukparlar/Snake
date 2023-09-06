using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    // Start is called before the first frame update


    public TMPro.TextMeshProUGUI skor_txt;
    int skor = 0;

    Movement tail_plus;

    private void Start()
    {

        tail_plus = GameObject.Find("Head").GetComponent<Movement>();


    }


    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name== "Head")
        {

            skor += 10;
            skor_txt.text = "SKOR" + skor;

            change_coordinate();

            tail_plus.tail_pluss();


        }

        if (other.gameObject.tag == "tail")
        {

            change_coordinate();



        }


    }


    void change_coordinate()
    {


        float x = Random.Range(-7.5f, 7.5f);
        float z = Random.Range(-8.5f, 7f);

        transform.position = new Vector3(x, 0.42f, z);

    }


    

    // Update is called once per frame
   
}
