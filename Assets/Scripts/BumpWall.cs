using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpWall : MonoBehaviour
{
    [SerializeField] private Transform[] m_randomPositions;

    /// <summary>
    /// Call this function to set a random position to the object
    /// </summary>
    private void SetRandomPosition()
    {
        transform.position = m_randomPositions[Random.Range(0, m_randomPositions.Length)].position;
    }
}