using PolarisLite.Locators;
using PolarisLite.Web.Components;
using PolarisLite.Web.Core;

namespace PolarisLite.Web.Services;

public static class DriverAdapterExtensions
{
    public static TComponent FindByLabel<TComponent>(this IElementFindService driverAdapter, string label)
         where TComponent : WebComponent, new()
    {
        return driverAdapter.Find<TComponent>(new LabelFindStrategy(label));
    }

    public static List<TComponent> FindAllByLabel<TComponent>(this IElementFindService driverAdapter, string label)
         where TComponent : WebComponent, new()
    {
        return driverAdapter.FindAll<TComponent>(new LabelFindStrategy(label));
    }

    public static void Handle(this DriverAdapter driverAdapter, Action<IAlert> action = null, DialogButton dialogButton = DialogButton.Ok)
    {
        var driver = DriverFactory.WrappedDriver;
        var alert = driver.SwitchTo().Alert();
        action?.Invoke(alert);
        if (dialogButton == DialogButton.Ok)
        {
            alert.Accept();
            driver.SwitchTo().DefaultContent();
        }
        else
        {
            alert.Dismiss();
            driver.SwitchTo().DefaultContent();
        }
    }

    public static string GetText(this DriverAdapter driverAdapter)
    {
        var driver = DriverFactory.WrappedDriver;
        var alert = driver.SwitchTo().Alert();

        return alert.Text;
    }
}
