namespace Lab2
{
    class Person
    {
        private string _FirstName;
        private string _SecondName;
        private DateTime _BirthTime;
        public Person(string FirstName, string SecondName, DateTime BirthTime)
        {
            _FirstName = FirstName;
            _SecondName = SecondName;
            _BirthTime = BirthTime;
        }
        public Person()
        {
            _FirstName = "Имя_Не_указано";
            _SecondName = "Фамилия_Не_указано";
            _BirthTime = new DateTime(1970,1,1);
        }
        public string FirstName { get; set; }
        public string SecondName{ get; set; }
        public string BirthTime { get; set; }
        public string ToFullString()
        {
            return _FirstName +" "+ _SecondName +" "+ Convert.ToString(_BirthTime);
        }
        public string ToShortString()
        {
            return _FirstName + " " + _SecondName;
        }
    }
}