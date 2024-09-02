using HotChocolate.Types.Descriptors;

using System.Reflection;
using System.Runtime.CompilerServices;

namespace eShop.Catalog.API.Middlewares;

public static class UseToUpperObjectFieldDescriptorExtensions
{
    public static IObjectFieldDescriptor UseToUpper(this IObjectFieldDescriptor descriptor)
    {
        return descriptor.Use(next => async (context) =>
        {
            await next(context);

            if (context.Result is string field)
            {
                context.Result = field.ToUpperInvariant();
            }
        });
    }

    public class UseToUpperAttribute : ObjectFieldDescriptorAttribute
    {
        public UseToUpperAttribute([CallerLineNumber] int order = default)
        {
            Order = order;
        }

        protected override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseToUpper();
        }
    }
}
