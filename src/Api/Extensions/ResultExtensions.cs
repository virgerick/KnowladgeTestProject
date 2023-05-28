namespace Api.Extensions;
using Result = Core.Result;
public static class ResultExtensions
{
    public static IResult ToActionResult<TSuccess, TError>(this Core.Result<TSuccess, TError> result)
        where TError : Exception
    {
        return result.Match(
            data => Results.Ok(Result.Success(data)),
             HandlerError);
    }

    private static IResult HandlerError(Exception error)
    {
        var result = Result.Failure(error);
        if (error.Message.Contains("was not found")) {
            return Results.NotFound(result);
        }
        return Results.BadRequest(result);
    }
}
