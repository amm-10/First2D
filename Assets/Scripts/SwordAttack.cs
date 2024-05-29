using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private quaternion originRotate;
    private quaternion endRotate;
    private const double swingTick = 0.1;

    public double sumTick=0;

    void Start()
    {
        originRotate = transform.localRotation;
    }
    void Update()
    {
    }

    public void Attack()
    {
        gameObject.SetActive(true);
        int count = 0;

        float sumTick = 0;
        while (true)
        {
            sumTick += Time.deltaTime;

            //if (sumTick > swingTick)
            //{
        
            //    transform.Rotate(0, 0, 90f);
            //    sumTick = 0;
            //    count++;
            //    Debug.Log(transform.rotation);
            //}

            Debug.Log(sumTick);
            if (count > 1000)
                break;

            transform.Rotate(0, 0, 1f);
            count++;

       //     if (transform.rotation > quaternion.Euler(new Vector3(0,0,180))
              //  break;
        }
       
        //transform.localRotation = originRotate;
    }
}

// È¸Àü¿¡ 
