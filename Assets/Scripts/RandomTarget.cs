using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTarget : MonoBehaviour
{
    [SerializeField] List<Transform> spawnTargetPoints = new List<Transform>();
    [SerializeField] GameObject targetShoot;
    Animator targetAnimator;
    float timeToChange; 
    void Start()
    {
        targetAnimator = targetShoot.GetComponent<Animator>();
        SpawnToNewRandomPoint();
        RandomScale(targetShoot.transform);
    }
    void FixedUpdate()
    {
        timeToChange += Time.fixedDeltaTime;

        if(timeToChange >= 5f && timeToChange <=5.15f)
        {
            targetShoot.SetActive(false);
        }
        else if(timeToChange >= 6f)
        {
            SpawnToNewRandomPoint();
            RandomScale(targetShoot.transform);
            timeToChange = 0;
        }
    }

    void RandomScale(Transform target)
    {
        target.localScale = new Vector3(Random.Range(1,2), Random.Range(1,2), 1);
    }
    void SpawnToNewRandomPoint()
    {
        targetShoot.transform.position = spawnTargetPoints[IndexTarget()].position;
        targetShoot.SetActive(true);
        targetAnimator.SetBool("isHard", RandomMode());
    }
    int IndexTarget()
    {
        return Random.Range(0, spawnTargetPoints.Count);
    }
    bool RandomMode()
    {
        int result;
        result = Random.Range(0,2);

        if (result == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
