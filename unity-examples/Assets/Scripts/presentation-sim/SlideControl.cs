using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideControl : MonoBehaviour
{
    private int currentSlideIndex;
    public Slider slider;

    void Start()
    {
        InitializeSlider();
        foreach (Transform slide in transform)
        {
            if (slide.GetSiblingIndex() != 0) slide.gameObject.SetActive(false);
        }
        currentSlideIndex = 0;
    }

    public void Forward() { NextSlide(true); } 
    public void Backward() { NextSlide(false);}

    private void NextSlide(bool fwd)
    {
        transform.GetChild(currentSlideIndex).gameObject.SetActive(false);
        if (fwd)
        {
            currentSlideIndex += 1;
            if (currentSlideIndex >= transform.childCount) currentSlideIndex = 0;
        } else
        {
            currentSlideIndex -= 1;
            if (currentSlideIndex <= 0) currentSlideIndex = transform.childCount - 1;
        }
        
        slider.value = currentSlideIndex;
    }

    public void ChooseSlide(Slider slider)
    {
        transform.GetChild(currentSlideIndex).gameObject.SetActive(false);
        currentSlideIndex = (int)slider.value;
        transform.GetChild(currentSlideIndex).gameObject.SetActive(true);
    }

    private void InitializeSlider()
    {
        slider.wholeNumbers = true;
        slider.minValue = 0;
        slider.maxValue = transform.childCount - 1;
    }
}
