﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DrumModeProperties : UpdateableService
{
    enum LaneCountOptions
    {
        // Keep this in the same order as the UI
        LaneCount5,
        LaneCount4,     
    }

    [SerializeField]
    Dropdown m_laneCountDropdown;

    readonly static Dictionary<LaneCountOptions, int> r_laneOptionToLaneCount = new Dictionary<LaneCountOptions, int>()
    {
        { LaneCountOptions.LaneCount5, 5 },
        { LaneCountOptions.LaneCount4, 4 },
    };

    readonly static Dictionary<int, LaneCountOptions> r_laneCountToLaneOption = r_laneOptionToLaneCount.ToDictionary((i) => i.Value, (i) => i.Key);

    protected override void Start()
    {
        base.Start();

        ChartEditor editor = ChartEditor.Instance;
        editor.events.chartReloadedEvent.Register(OnChartReload);

        
        OnChartReload();
    }

    public override void OnServiceUpdate()
    {
        
    }

    void OnChartReload()
    {
        bool isDrums = ChartEditor.Instance.currentChart.gameMode == Chart.GameMode.Drums;
        gameObject.SetActive(isDrums);

        if (isDrums)
        {
            LaneCountOptions option;

            if (!r_laneCountToLaneOption.TryGetValue(GameSettings.drumsLaneCount, out option))
            {
                option = LaneCountOptions.LaneCount5;
            }

            int intLastKnownLaneCount = (int)option;
            bool forceReload = intLastKnownLaneCount != ChartEditor.Instance.laneInfo.laneCount;
            m_laneCountDropdown.value = intLastKnownLaneCount;
            if (forceReload)
            {
                int desiredLaneCount;
                if (r_laneOptionToLaneCount.TryGetValue(option, out desiredLaneCount))
                {
                    ChartEditor.Instance.uiServices.menuBar.SetLaneCount(desiredLaneCount);
                }
            }
        }
    }

    public void OnLaneCountDropdownValueChanged(int value)
    {
        LaneCountOptions option = (LaneCountOptions)value;
        ChartEditor editor = ChartEditor.Instance;

        int desiredLaneCount;
        if (r_laneOptionToLaneCount.TryGetValue(option, out desiredLaneCount))
        {
            GameSettings.drumsLaneCount = desiredLaneCount;
            editor.uiServices.menuBar.SetLaneCount(desiredLaneCount);
            editor.uiServices.menuBar.LoadCurrentInstumentAndDifficulty();       
        }
    }
}
