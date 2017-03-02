namespace System
{
    internal static partial class Ensure
    {
        public static void NotNull<T>([ValidatedNotNull]T? value, string paramName)
            where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void NotNull<T>([ValidatedNotNull]T value, string paramName)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        private sealed class ValidatedNotNullAttribute : Attribute
        {
        }
    }
}