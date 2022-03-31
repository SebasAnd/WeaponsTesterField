using UnityEngine;

[CreateAssetMenu(fileName = "Rifle Parabolico", menuName = "Assets/ScriptableObjects/ParabolicWeapon.cs")]
public class ParabolicWeapon : ScriptableObject
{
    public float velocidad_de_disparo;
    public float tiempo_de_duracion_del_projectil;
}
