using UnityEngine;

[CreateAssetMenu(fileName = "Anillos de Poder", menuName = "Assets/ScriptableObjects/SpellWeapon.cs")]
public class SpellWeapon : ScriptableObject
{
    // Start is called before the first frame update
    public float velocidad_de_disparo;
    public float tiempo_de_duracion_del_projectil;
    public float fuerza_de_empuje;
}
