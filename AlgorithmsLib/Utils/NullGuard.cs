using System;

namespace AlgorithmsLib.Utils
{
    public static class NullGuard
    {
        const string text = "Cant be null";
        public static T3 Protect<T1, T2, T3>(Func<T1, T2, T3> func, T1 methodArg1, T2 methodArg2) 
            where T1: class
            where T2: class 
        {
            
            if (methodArg1 == null)
                throw new ArgumentNullException(typeof(T1).Name, text);
            if (methodArg2 == null)
                throw new ArgumentNullException(typeof(T2).Name, text);

            return func(methodArg1, methodArg2);
        }

        public static T4 Protect<T1, T2, T3, T4>(Func<T1, T2, T3, T4> func, T1 methodArg1, T2 methodArg2, T3 methodArg3)
            where T1 : class
            where T2 : class
            where T3 : class
        {

            if (methodArg1 == null)
                throw new ArgumentNullException(typeof(T1).Name, text);
            if (methodArg2 == null)
                throw new ArgumentNullException(typeof(T2).Name, text);
            if (methodArg3 == null)
                throw new ArgumentNullException(typeof(T3).Name, text);

            return func(methodArg1, methodArg2, methodArg3);
        }
    }
}