using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SRS.Common
{
    public class Utils
    {
        public static void Errors(IdentityResult result, ModelStateDictionary modelState)
        {
            foreach (IdentityError error in result.Errors)
                modelState.AddModelError("", error.Description);
        }
    }
}
