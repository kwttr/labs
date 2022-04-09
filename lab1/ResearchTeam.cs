namespace Lab2
{
    class ResearchTeam
    {
        private string _themeName;
        private string _organisationName;
        private int _teamId;
        private TimeFrame _timeFrame;
        private Paper[] _publishList;
        public string ThemeName { get
            {
                return _themeName;
            } set
            {
                _themeName = value;
            }
        }
        public string OrganisationName { get
            {
                return _organisationName;
            } set
            {
                _organisationName = value;
            }
        }
        public int TeamId { get
            {
                return _teamId;
            } set
            {
                _teamId = value;
            }
        }
        public TimeFrame TimeFrame { get
            {
                return (TimeFrame)_timeFrame;
            } set
            {
                _timeFrame= value;
            }
        }
        public ResearchTeam(string ThemeName, string OrganisationName, int TeamId,TimeFrame timeFrame)
        {
            _themeName = ThemeName;
            _organisationName = OrganisationName;
            _teamId = TeamId;
            _timeFrame = timeFrame;
            _publishList = Array.Empty<Paper>();
        }
        public ResearchTeam()
        {
            _publishList = Array.Empty<Paper>();
            _themeName = "Тема_не_указана";
            _organisationName = "Организация_не_указана";
            _teamId = 0;
            _timeFrame=0;
        }

        public Paper[] GetPublishList()
        {
            return _publishList;
        }

        public Paper GetLastPublish()
        {
            if (_publishList == null) return null;
                return _publishList[_publishList.Length-1];
        }
        public void AddPapers(params Paper[] list)
        {
            Paper[] temp = new Paper[_publishList.Length+list.Length];
            for (int i= 0; i < list.Length+_publishList.Length; i++)
            {
                if (i < _publishList.Length)
                {
                    temp[i] = _publishList[i];
                }
                else
                {
                    temp[i] = list[i - _publishList.Length];
                }
            }
            _publishList = temp;
        }
        public override string ToString()
        {
            return ToFullString();
        }
        public string ToFullString()
        {
            var papers = string.Join("\n ", (object[]) GetPublishList());
            return _themeName + " " + _organisationName + " " + _teamId + " " + _timeFrame.ToString() + " " + papers;
        }
        public string ToShortString()
        {
            return _themeName + " " + _organisationName + " " + _teamId + " " + _timeFrame.ToString();
        }
    }
}