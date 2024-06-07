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
            EndSlideShow();
            return;
        }

        for (int i = 0; i < _slides.Length; i++)
            _slides[i].SetActive(i == _currentSlide);
    }

    public void SetNextSlide()
    {
        _currentSlide++;
    }

    public void SetPreviousSlide()
    {
        _currentSlide--;
    }

    private void EndSlideShow()
    {
        _currentSlide = 0;
        gameObject.SetActive(false);

        if (_mainButtons != null)
            _mainButtons.SetActive(true);

        for (int i = 0; i < _slides.Length; i++)
            _slides[i].SetActive(false);
    }
}