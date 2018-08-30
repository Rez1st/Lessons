namespace LearningCore
{
    public abstract class LessonBase
    {
        protected LessonBase()
        {
            LessonName = this.GetType().FullName;
        }

        protected string LessonName;

        public void Process()
        {
            Content();
        }

        protected abstract void Content();
    }
}
