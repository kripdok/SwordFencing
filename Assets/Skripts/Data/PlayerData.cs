using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class PlayerData
{
    private SwordSkins _selectedSword;
    private PointerSkins _selectedPointer;

    private List<SwordSkins> _openSwordSkins;
    private List<PointerSkins> _openPointerSkins;
    private List<NameScenes> _openLevels;

    private int _money;

    public IEnumerable<SwordSkins> OpenSwordSkins => _openSwordSkins;
    public IEnumerable<PointerSkins> OpenPointerSkins => _openPointerSkins;
    public IEnumerable<NameScenes> OpenLevels => _openLevels;


    public PlayerData()
    {
        _money = 1000;
        _selectedSword = SwordSkins.Blue;
        _selectedPointer = PointerSkins.Blue;

        _openPointerSkins = new List<PointerSkins>() { _selectedPointer };
        _openSwordSkins = new List<SwordSkins>() { _selectedSword };
        _openLevels = new List<NameScenes>() { NameScenes.DuelLevel0 };
    }

    [JsonConstructor]
    public PlayerData(int money, SwordSkins selectionSwordSkin,PointerSkins selectionPointerSkins, List<SwordSkins> openSwordSkins,List<PointerSkins> openPointerSkins, List<NameScenes> openLevels)
    {
        _money = money;
        _selectedPointer = selectionPointerSkins;
        _selectedSword = selectionSwordSkin;
        _openPointerSkins = openPointerSkins;
        _openSwordSkins = openSwordSkins;
        _openLevels = openLevels;
    }

    public int Money
    {
        get => _money;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            _money = value;
        }
    }

    public SwordSkins SelectedSword
    {
        get => _selectedSword;
        set
        {
            if (_openSwordSkins.Contains(value) == false)
            {
                throw new ArgumentException(nameof(value));
            }

            _selectedSword = value;
        }
    }

    public PointerSkins SelectedPointer
    {
        get => _selectedPointer;
        set
        {
            if (_openPointerSkins.Contains(value) == false)
            {
                throw new ArgumentException(nameof(value));
            }

            _selectedPointer = value;
        }
    }


    public void OpenSwordSkin(SwordSkins skins)
    {
        if (_openSwordSkins.Contains(skins))
        {
            throw new ArgumentException(nameof(skins));
        }

        _openSwordSkins.Add(skins);
    }

    public void OpenPointerSkin(PointerSkins skins)
    {
        if (_openPointerSkins.Contains(skins))
        {
            throw new ArgumentException(nameof(skins));
        }

        _openPointerSkins.Add(skins);
    }

    public void OpenLevel(NameScenes scene)
    {
        if (_openLevels.Contains(scene))
        {
            return;
        }

        _openLevels.Add(scene);
    }
}