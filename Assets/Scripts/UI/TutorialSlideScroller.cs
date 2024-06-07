using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSlideScroller : MonoBehaviour
{
    [SerializeField] private GameObject[] _slides;
    [SerializeField] private GameObject _mainButtons;

    private int _currentSlide;

    private void OnEnable()
    {
        _currentSlide = 0;

        Scroll();
    }

    public void Scroll()
    {
        if (_currentSlide >= _slides.Length)
        {
            _currentSlide = 0;
            gameObject.SetActive(false);
            _mainButtons.SetActive(true);
            DeactiveSlides();
            return;
        }

        for (int i = 0; i < _slides.Length; i++)
            _slides[i].SetActive(i == _currentSlide);

        _currentSlide++;
    }

    private void DeactiveSlides()
    {
        for (int i = 0; i < _slides.Length; i++)
        {
            _slides[i].SetActive(false);
        }
    }
}
