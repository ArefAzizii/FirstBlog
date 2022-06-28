namespace FirsBlog_Core.Utilities
{
    public static class TextUtilities
    {
        public static string ToSlug(this string slug) 
        { 
         return slug.ToLower().Trim().Replace(" ","-")
                .Replace("!", "")
                .Replace("@", "")
                .Replace("#", "")
                .Replace("$", "")
                .Replace("%", "")
                .Replace("^", "")
                .Replace("&", "")
                .Replace("*", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("_", "")
                .Replace("+", "")
                .Replace("=", "")
                .Replace("/", "")
                .Replace("~", "")
                .Replace("`", "")
                .Replace(@"\","");
        }
    }
}
