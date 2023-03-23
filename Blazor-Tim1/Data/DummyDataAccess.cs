namespace Blazor_Tim1.Data
{
    // You will always get the same age from this instance
    public class DummyDataAccess : IDataAccess
    {
        private int age;
        public DummyDataAccess()
        {
            Random rnd = new Random();
            age = rnd.Next(1, 15);
        }
        public int GetUserAge()
        {
            return age;
        }
    }
}
