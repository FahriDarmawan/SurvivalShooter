using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageItem : PowerItem
{
    private PlayerShooting _playerShooting;
    private MeshRenderer _itemObject;
    private BoxCollider _boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        _playerShooting = GameObject.Find("GunBarrelEnd").GetComponent<PlayerShooting>();
        _itemObject = this.gameObject.GetComponent<MeshRenderer>();
        _boxCollider = this.gameObject.GetComponent<BoxCollider>();
    }

    public override void Powers()
    {
        base.Powers();

        //nilai damagepershot dikali 2
        _playerShooting.damagePerShot *= 2;

        //agar tidak terlihat saat gameplay
        _itemObject.enabled = !_itemObject.enabled;

        //trigger hilang
        _boxCollider.enabled = !_boxCollider.enabled;

        //reset attcak setelah 5 detik
        Invoke("resetDamage", 5);

        var go = Instantiate(floatingTextPrefabs, this.transform.position, Quaternion.identity);
        go.GetComponent<TextMesh>().text = "Damage Increased !!!";
        go.GetComponent<TextMesh>().color = Color.red;
    }

    private void resetDamage()
    {
        _playerShooting.damagePerShot /= 2;
        Destroy(this.gameObject); // mengancurkan item setelah 5 detik
    }
}
