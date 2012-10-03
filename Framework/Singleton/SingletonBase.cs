namespace Framework.Singleton
{
    public abstract class SingletonBase<T> where T : SingletonBase<T>
    {
        public static T GetInstance()
        {
            return Singleton.GetInstance<T>();
        }
    }
}
