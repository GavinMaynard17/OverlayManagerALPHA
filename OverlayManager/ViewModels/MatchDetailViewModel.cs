﻿using OverlayManager.Commands;
using OverlayManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace OverlayManager.ViewModels
{
    public class MatchDetailViewModel : ViewModelBase
    {
        private Match _match;

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand SeriesLengthCommand { get; }
        public ICommand SelectLogoCommand { get; }


        public MatchDetailViewModel(Match match,
            Services.NavigationService matchControlNavigationService,
            Services.NavigationService gameSelectionNavigationService)
        {
            _match = match;
            SubmitCommand = new MatchDetailCommand(this, _match, matchControlNavigationService);
            CancelCommand = new ClearDetailsCommand(_match, gameSelectionNavigationService);
            SeriesLengthCommand = new SeriesLengthCommand(this, _match);
            SelectLogoCommand = new SelectLogoCommand(this, _match);
        }

        public string GameSelected
        {
            get
            {
                return "Game Selected: "+_match.Game;
            }
        }

        public string SeriesLength
        {
            get
            {
                if (_match.SeriesLength == 0) return "Select a series length";
                return "Best of: " + _match.SeriesLength;
            }
            set
            {
                if (_match.SeriesLength != int.Parse(value))
                {
                    _match.SeriesLength = int.Parse(value);
                    _match.winScore = _match.SeriesLength / 2 + 1;
                    OnPropertyChanged(nameof(SeriesLength));
                }
            }
        }

        private string _team1Name;
        public string Team1Name
        {
            get
            {
                return _team1Name;
            }
            set
            {
                _team1Name = value;
                _match.Team1.Name = value.ToUpper();
                OnPropertyChanged(nameof(Team1Name));
            }
        }

        private BitmapImage _team1Logo;
        public BitmapImage Team1Logo
        {
            get
            {
                return _team1Logo;
            }
            set
            {
                _team1Logo = value;
                OnPropertyChanged(nameof(Team1Logo));
            }
        }

        private string _team2Name;
        public string Team2Name
        {
            get
            {
                return _team2Name;
            }
            set
            {
                _team2Name = value;
                _match.Team2.Name = value.ToUpper();
                OnPropertyChanged(nameof(Team2Name));
            }
        }

        private BitmapImage _team2Logo;
        public BitmapImage Team2Logo
        {
            get
            {
                return _team2Logo;
            }
            set
            {
                _team2Logo = value;
                OnPropertyChanged(nameof(Team2Logo));
            }
        }

    }
}
//propchange SL, t1n, t2n
//launch overlay based on game value
//navigate to match control or game selection