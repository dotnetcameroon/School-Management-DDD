using Api.Domain.Common.Utilities;

namespace Api.Presentation.Utilities;

public class AuthHeaders
{
    public static string GetUserId(IHeaderDictionary headers)
    {
        return headers.TryGetValue(Headers.UserId, out var userId) ? userId! : string.Empty;
    }
}
