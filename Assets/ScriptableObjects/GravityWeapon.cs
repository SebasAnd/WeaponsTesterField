using UnityEngine;

[CreateAssetMenu(fileName = "Rifle de Gravedad", menuName = "Assets/ScriptableObjects/GravityWeapon.cs")]
public class GravityWeapon : ScriptableObject
{
    // Start is called before the first frame update
    public float velocidad_de_disparo;
    public float tiempo_de_duracion_del_projectil;
    public float fuerza_de_gravedad;
}
