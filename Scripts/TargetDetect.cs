using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetect : MonoBehaviour
{
    [SerializeField]
    private GameObject cat;

    [SerializeField]
    private GameObject mush;

    [SerializeField]
    private GameObject storne;

    [SerializeField]
    private GameObject daikon;
   

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ChildTag")
        {
            cat = other.gameObject;
        }
        else if(other.gameObject.tag == "MushTag")
        {
            mush = other.gameObject;
        }
        else if(other.gameObject .tag == "StorneTag")
        {
            storne = other.gameObject;
        }
        else if(other.gameObject.tag == "DaikonTag")
        {
            daikon = other.gameObject;
        }       
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ChildTag")
        {
            cat = null;
        }
        else if (other.gameObject.tag == "MushTag")
        {
            mush = null;
        }
        else if (other.gameObject.tag == "StorneTag")
        {
            storne = null;
        }
        else if (other.gameObject.tag == "DaikonTag")
        {
            daikon = null;
        }

       
    }
    public GameObject GetTarget()
    {
        if (cat != null)
        {
            return this.cat;
        }
        else if(mush != null)
        {
            return this.mush;
        }
        else if(storne != null)
        {
            return this.storne;
        }
        else if(daikon != null)
        {
            return this.daikon;
        }
        else
        {
            return null;
        }
        
    }
}
