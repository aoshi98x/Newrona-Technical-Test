using UnityEngine;

public class BulletAction : MonoBehaviour
{
    [SerializeField] GameObject collisionEffect;
    [SerializeField] Rigidbody rigidB;
    [SerializeField] float launchSpeed;
    
    private void Start() {
        rigidB = GetComponent<Rigidbody>();
    }
    private void OnEnable() {
        Vector3 force = transform.forward * launchSpeed;
        rigidB.AddForce(force, ForceMode.Acceleration);
    }
    private void OnCollisionEnter(Collision other) {
        rigidB.Sleep();
        Instantiate(collisionEffect, transform.position, Quaternion.identity, null);
        this.gameObject.SetActive(false);

        if(other.gameObject.CompareTag("10Points"))
        {
            ScoreManager.Instance.UpdateScore(10);
        }
        else if(other.gameObject.CompareTag("9Points"))
        {
            ScoreManager.Instance.UpdateScore(9);
        }
        else if(other.gameObject.CompareTag("8Points"))
        {
            ScoreManager.Instance.UpdateScore(8);
        }
        else if(other.gameObject.CompareTag("7Points"))
        {
            ScoreManager.Instance.UpdateScore(7);
        }
    }
    
}
