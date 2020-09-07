﻿namespace RPNames.EventHandlers
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using System;
    using System.Collections.Generic;

    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        Random random = new Random();
        public void OnPlayerChangeRole(ChangingRoleEventArgs ev)
        {
            if (plugin.NickNames.Count == 0)
            {
                Refreshnames();
            }
            if (plugin.Config.ClassTitles.ContainsKey(ev.NewRole.ToString()))
            { 
                int RandomNameNumber = random.Next(1, plugin.NickNames.Count-1);
                plugin.NickNames.RemoveAt(RandomNameNumber);
                ev.Player.DisplayNickname = plugin.Config.ClassTitles[ev.NewRole.ToString()] + plugin.NickNames[(RandomNameNumber)];
            }
            if (plugin.Config.SCPSetting )
            {
                if (plugin.Config.SCPNames.ContainsKey(ev.NewRole.ToString()))
                {
                    ev.Player.DisplayNickname = plugin.Config.SCPNames[ev.NewRole.ToString()];
                }
            }
            else
            {
                if (!plugin.Config.DboisSetting)
                {
                    int RandomNameNumber = random.Next(1, plugin.NickNames.Count - 1);
                    plugin.NickNames.RemoveAt(RandomNameNumber);
                    ev.Player.DisplayNickname = plugin.Config.ClassTitles[ev.NewRole.ToString()] + plugin.NickNames[RandomNameNumber];
                }
                else
                {
                    int DclassNumber = random.Next(1000, 9999);
                    ev.Player.DisplayNickname = ("D-" + DclassNumber.ToString());
                }
            }
            if (ev.NewRole == RoleType.ClassD)
            {
                if (plugin.Config.DboisSetting)
                {
                    int DclassNumber = random.Next(1000, 9999);
                    ev.Player.DisplayNickname = ("D-" + DclassNumber.ToString());
                }
                
            }
            if (ev.NewRole == RoleType.Tutorial)
            {
                if (plugin.Config.TutorialNick)
                {
                    ev.Player.DisplayNickname = null;
                }
            }
        }
        public void OnPlayerDeath(DiedEventArgs ev)
        {
            if (plugin.Config.DeathReset == true)
            {
                ev.Target.DisplayNickname = null;
            }
        }

        public void Refreshnames()
        {
            if (plugin.Config.HumanNames == null)
            {
                plugin.NickNames = new List<string> { "Hyde", "Hood", "Hull", "Hogan", "Hitchens", "Higgins", "Hodder", "Huxx", "Hester", "King", "Kubiak", "Koker", "Kerrigan", "Kumara", "Knox", "Koufax", "Keagan", "Kestrel", "Future", "Fitzpatrick", "Fontana", "Fenner", "Furyk", "Finch", "Fullbright", "Fassbinder", "Flood", "Fong", "E.Gold", "Fleetwood", "Fugger", "Frost", "Fsik", "Fawcett", "Fishman", "Freeze", "Fissolo", "Foley", "Fairchild", "Freeman", "Decker", "Dobermann", "Dunlop", "Dumont", "Dandridge", "Diamond", "Cyrus", "Craggs", "Crisper", "Cotheran", "Curry", "Conard", "Cutler", "Coggins", "Cates", "Crisp", "Curio", "Murray", "Morrison", "McKay", "Merchant", "Murillo", "Mooney", "Murdock", "Matisse", "Massey", "McGee", "Minter", "Munson", "Oswald", "Ortega", "Ogle", "Orr", "Ogden", "Onassis", "Olson", "Ollenrenshaw", "Silver", "Small", "Stoneking", "Sweeney", "Surrett", "Swiatek", "Sloane", "Stapleton", "Seibert", "Stroud", "Strode", "Stockton", "Bright", "Miller", "Simarded", "Whix", "Tombstone", "Cimmerian", "Conwell", "Clef", "Gears", "Kiryu", "Heiden", "Lloyd", "Marlowe", "Sorts", "Xyank", "Anborough", "LaFerrier", "Iceberg", "Kondraki", "Eskobar", "Anderson", "Ambrose", "Baudin", "Belitrov", "Chao", "Blackwood", "Fitzroy", "Silberescher", "Aktus", "Diaghilev", "Winchell", "Winters", "Walsh", "Whalen", "Watson", "Wooster", "Woodson", "Winthrop", "Wall", "Wight", "Webb", "Woodard", "Wixx", "Wong", "Whesker", "Wolfenstein", "Winchester", "Wire", "Wolf", "Wheeler", "Warrick", "Walcott", "Wilde", "Wexler", "Wells", "Weeks", "Wainright", "Wallace", "Weaver", "Wagner", "Wadd", "Withers", "Whitby", "Woodland", "Woody", "Warren", "Race", "Rooney", "Russo", "Rude", "Roland", "Reader", "Renshaw", "Rossi", "Riddle", "Ripa", "Richter", "Rosenberg", "Romo", "Ramirez", "Reagan", "Rainwater", "Romirez", "Riker", "Riggs", "Redman", "Reinhart", "Redgrave", "Rafferty", "Rigby", "Roman", "Reece", "Abawi", "Allard", "Adara", "Abbott", "Acampora", "Ackerman", "Ackroyd", "Abbington", "Axworthy", "Ainge", "Abernathy", "Atkinson", "Abner", "Abella", "Agholor", "Allred", "Asola", "Abrams", "Acker", "Abrell", "Acuff", "Archer", "Asterio", "Adair", "Albright", "Adelson", "Atwood", "Aguillar", "Adler", "Arrowood", "Arora" };
            }
            else
            {
                plugin.NickNames = plugin.Config.HumanNames;
            }
        }
    }
}
