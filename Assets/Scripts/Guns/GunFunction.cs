using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFunction : MonoBehaviour
{
   [SerializeField] GameObject bulletPrefab;
   [SerializeField] GameObject effectPrefab;

    [SerializeField] Transform spawnPoint;
    Animator animatorControl;
    List<GameObject> bullets = new List<GameObject>();
    GameObject shootEffect;
    private void Start() {

        animatorControl = GetComponent<Animator>(); 
        InstantiatePool(10);
    }

    void InstantiatePool(int amount)
    {
        shootEffect = Instantiate(effectPrefab, spawnPoint.position, spawnPoint.rotation, this.transform);
        shootEffect.SetActive(false);
        for (int i = 0; i < amount; i++)
        {    
            GameObject newObject = Instantiate(bulletPrefab);
            bullets.Add(newObject);
            newObject.SetActive(false);
            
        }
    }
    public void Fire()
    {   
        animatorControl.SetTrigger("fireGun");
        GameObject bullet = GetBullet();
        
        if(bullet != null)
        {
            bullet.transform.position = spawnPoint.position;
            bullet.transform.rotation = spawnPoint.rotation;
            bullet.SetActive(true);
            shootEffect.SetActive(true);
        }
    }

    GameObject GetBullet()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if(!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }
        return null;
    }
}
