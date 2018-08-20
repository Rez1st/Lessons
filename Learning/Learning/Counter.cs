namespace Learning
{
    public class Counter
    {
        public delegate void MethodToCount();

        public event MethodToCount OnCount;

        public void Start()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 99)
                    OnCount();
            }
        }
    }
}