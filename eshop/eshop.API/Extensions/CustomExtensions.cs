namespace eshop.API.Extensions
{
    public static class CustomExtensions
    {
        /// <summary>
        /// Tam sayının karesini alan fonksiyon
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetSquare(this int value)=> (int)Math.Pow(value, 2);

    }
}
