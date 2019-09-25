using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace gs.Controls
{
    public partial class HeaderView : ContentView
    {
        public Image userImage;
        public StackLayout textStack;
        public Label labelUser;
        public Label labelTeam;

        public HeaderView()
        {
            InitializeComponent();
            userImage = pgUser;
            textStack = pgText;
            labelUser = pgUserText;
            labelTeam = pgTeamText;
        }
    }
}
