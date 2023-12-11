using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DOTTextChanger : MonoBehaviour
{
    [SerializeField] private Text _text;
    
    private float _delay = 3f;
    private float _dutation = 3f;
    
    void Start()
    {
        _text.DOText("Привет Мир!", _dutation);
        _text.DOText(" как дела?", _dutation).SetRelative().SetDelay(_delay);
        _text.DOText("Произошел взлом", _dutation, true, ScrambleMode.All).SetDelay(_delay + _delay);
    }
}
