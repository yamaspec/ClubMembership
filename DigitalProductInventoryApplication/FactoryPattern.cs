namespace DigitalProductInventoryApplication
{
    public static class FactoryPattern<T, U> where T : class, U, new()
                                             where U : class, IPrimaryProperties
    {
        public static U GetInstance()
        {
            U objT = new T();
            return objT;
        }
    }

}
