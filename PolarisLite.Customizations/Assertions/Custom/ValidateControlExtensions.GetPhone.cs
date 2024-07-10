using PolarisLite.Web.Contracts;
using PolarisLite.Web.Core;

namespace PolarisLite.Web.Assertions;

public static partial class ValidateComponentExtensions
{
    public static void ValidatePhoneIs<T>(this T control, string value, int? timeout = null, int? sleepInterval = null)
        where T : IComponentPhone, IComponent
    {
        Validate(() => control.GetPhone().Equals(value), $"The control's phone should be '{value}' but was '{control.GetPhone()}'.", timeout, sleepInterval);
    }

    public static void Validate(Func<bool> waitCondition, string exceptionMessage, int? timeoutInSeconds, int? sleepIntervalInSeconds)
    {
        var wrappedWebDriver = DriverFactory.WrappedDriver;
        var webDriverWait = new WebDriverWait(wrappedWebDriver, TimeSpan.FromSeconds(30));
        webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));

        try
        {
            webDriverWait.Until(d => waitCondition);
        }
        catch (WebDriverTimeoutException)
        {
            var elementPropertyValidateException = new ComponentPropertyValidateException(exceptionMessage, wrappedWebDriver.Url);
            throw elementPropertyValidateException;
        }
    }
}