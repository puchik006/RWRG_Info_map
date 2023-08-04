using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "InfoPointCard",menuName = "InfoPointCard")]
public class InfoPointCard: ScriptableObject
{
    [SerializeField] private List<Sprite> _images;
    [SerializeField] private string _discription;

    public List<Sprite> Images => _images;
    public string Discription => _discription;
}
