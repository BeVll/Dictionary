namespace Dictionary
{
    class Program
    {
        static public void Main(String[] arg)
        {
            ControlDictionary cd = new ControlDictionary();
            cd.Path = @"D:\ITSTEP\C#\Exam\Dictionary";
           cd.LoadDictionary();
            cd.Menu();
            cd.SaveDictionary();
        }
    }
}
