using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpWall : MonoBehaviour
{
    [SerializeField] private Transform[] m_randomPositions;
    private float timeCounter = 0;

    private void Start()
    {
    }

    private void SetRandomPosition()
    {
        transform.position = m_randomPositions[Random.Range(0, m_randomPositions.Length)].position;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out HarryController player))
        {
            timeCounter += Time.deltaTime;
           
            Debug.Log($"Tiempo que llevo dentro del box: {timeCounter}");

            if(timeCounter >= 2.0f)
            {
                SetRandomPosition();

                RestartCounter();
            }
        }
    }

    void OnTriggerExit()
    {
        RestartCounter();
    }

    private void RestartCounter()
    {
        timeCounter = 0;
    }

}