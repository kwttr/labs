namespace Lab2
{
    class Paper
    {
        public string _PublishName { get; set; }
        public Person _Autor {get; set;}
        public DateTime _PublishDate { get; set;}

        public Paper(string PublishName, Person Name, DateTime PusblishDate)
        {
            _PublishDate = PusblishDate;
            _Autor = Name;
            _PublishName = PublishName;
        }
        public Paper()
        {
            _PublishDate = new DateTime(1970,1,1);
            _Autor = new Person();
            _PublishName = "Имя_Публ_Не_указано";
        }
        public override string ToString()
        {
            return ToFullString();
        }
        public string ToFullString()
        {
            return _PublishName + " "+ _Autor.ToShortString() +" "+_PublishDate.ToString("d");
        }
    }
}