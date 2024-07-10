namespace PolarisLite.Web;

public static class EmailExtensions
{
    public static int? MaxLength(this Email email)
    {
        return string.IsNullOrEmpty(email.GetAttribute("maxlength")) ? null : (int?)int.Parse(email.GetAttribute("maxlength"));
    }

    public static int? MinLength(this Email email)
    {
        return string.IsNullOrEmpty(email.GetAttribute("minlength")) ? null : (int?)int.Parse(email.GetAttribute("minlength"));
    }

    public static int? Size(this Email email)
    {
        return string.IsNullOrEmpty(email.GetAttribute("size")) ? null : (int?)int.Parse(email.GetAttribute("size"));
    }
}