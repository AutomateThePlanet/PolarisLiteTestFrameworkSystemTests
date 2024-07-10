using PolarisLite.Web.Components;
using PolarisLite.Web.Contracts;

namespace PolarisLite.Web;

public partial class UpdatedEmail : EmailExtensions
{
    public override void SetEmail(string email)
    {
        SetAttribute("value", email);
    }
}