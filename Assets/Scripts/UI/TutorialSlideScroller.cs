using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSlideScroller : MonoBehaviour
{
    [SerializeField] private GameObject[] _slides;

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
            DeactiveSlides();
            return;
        }

        _slides[_currentSlide].SetActive(true);

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
