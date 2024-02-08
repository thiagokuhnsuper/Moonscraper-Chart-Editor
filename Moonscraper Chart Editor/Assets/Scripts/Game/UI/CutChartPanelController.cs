// Copyright (c) 2016-2020 Alexander Ong
// See LICENSE in project root for license information.

using MoonscraperChartEditor.Song;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CutChartPanelController : MonoBehaviour
{
    [SerializeField] private InputField _startInputField;
    [SerializeField] private InputField _endInputField;

    public void Apply()
    {
        var start = uint.Parse(_startInputField.text);
        var end = uint.Parse(_endInputField.text);

        ChartEditor.Instance.currentSong.Cut(start, end);

        ChartEditor.isDirty = true;
        TimelineHandler.Repaint();
    }

    public void Disable()
    {
        ChartEditor.Instance.interactionMethodManager.ChangeInteraction(EditorInteractionManager.InteractionType.HighwayObjectEdit);
    }

    public void Enable()
    {
        ChartEditor.Instance.interactionMethodManager.ChangeInteraction(EditorInteractionManager.InteractionType.CutChart);
    }
}
