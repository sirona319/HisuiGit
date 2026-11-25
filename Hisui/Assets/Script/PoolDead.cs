using NaughtyAttributes;
using UnityEngine;

public class PoolDead : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int damageVal = 1;

    [SerializeField] bool hitDead = true;

    [Tag]
    [SerializeField] string[] tagNames;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //AI
        foreach (var tagName in tagNames)
        {
            if (!other.CompareTag(tagName))
                continue;

            var iDamage = other.GetComponent<IDamage>();

            if (iDamage == null)
                break;

            iDamage.Damage(damageVal);

            if (hitDead)
                gameObject.SetActive(false);

            break;
        }

    }


}
