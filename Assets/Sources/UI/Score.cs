using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _score;

    public void Reset()
    {
        _score = 0;
        UpdateText();
    }

    public void Increment()
    {
        _score++;
        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = _score.ToString();
    }
}
