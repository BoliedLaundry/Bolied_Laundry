using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class S_Object : MonoBehaviour
{
    [SerializeField] string s_name;
    [SerializeField] bool toDayInter = false;
    [SerializeField] S_DescManager descManager;
    public void Interaction()
    {
        if (!toDayInter)
        {
            descManager.startDesc(s_name);
            toDayInter = true;
        }        
    }    
}
