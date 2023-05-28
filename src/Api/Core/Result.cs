namespace Api.Core;
public interface IResult {
	public bool Succeeded { get; set; }
	public string Message { get; set; }
}
public interface IResult<TData>:IResult {
	public TData Data { get; set; }
}
public struct Result : IResult
{
    public bool Succeeded { get ; set ; }
    public string Message { get ; set ; }
	public static Result Success() => new() { Succeeded = true, Message = string.Empty };
	public static Result<TData> Success<TData>(TData data) => Result<TData>.Success(data);
	public static Result Success(string message) => new() { Succeeded = true, Message = message };
	public static Result Failure(string error) => new() { Succeeded = false, Message = error };
	public static Result Failure(Exception exception) => new() { Succeeded = false, Message = exception.Message };


}
public struct Result<TData> :  IResult<TData>
{
    public TData Data { get ; set ; }
    public bool Succeeded { get ; set ; }
    public string Message { get ; set ; }
    public static Result<TData> Success() => new() { Succeeded = true, Message = string.Empty };
    public static Result<TData> Success(TData data) => new() { Succeeded = true,Data=data, Message = string.Empty };
    public static Result<TData> Success(string message) => new() { Succeeded = true, Message = message };
    public static Result<TData> Failure(string error) => new() { Succeeded = false, Message = error };
    public static Result<TData> Failure(Exception exception) => new() { Succeeded = false, Message = exception.Message };
}
public struct Result<TSuccess,TError>
	where TError:Exception
{
	private TSuccess _data= default(TSuccess)!;
	private TError _error= default(TError)!;
	private bool _succeded = false;
	public Result(TSuccess data)
	{
		_data = data;
		_succeded = true;
	}
	public Result(TError error)
	{
		_error = error;
		_succeded = false;
	}
	public TResult Match<TResult>(Func<TSuccess, TResult> onSuccess, Func<TError, TResult> onError)   => _succeded ? onSuccess(_data) : onError(_error);
	public void Switch(Action<TSuccess> success, Action<TError> error) {

		if (_succeded) {
			success(_data);
			return;
		}
		error(_error);
	}

	public static implicit operator Result<TSuccess, TError>(TSuccess success) => new(success);
	public static implicit operator Result<TSuccess, TError>(TError error) => new(error);


}

public struct OperationStatus {
	public const string NoFound = "NoFound";
	public const string Duplicated = "Duplicated";
	public const string Success = "Success";
	public const string UnKnown = "UnKnown";
	public string Status { get; init; }
	private OperationStatus(string value)
	{
		Status=value;
	}
	private static IEnumerable<OperationStatus> Supported {
		get
		{
			yield return new OperationStatus(NoFound);
			yield return new OperationStatus(Duplicated);
			yield return new OperationStatus(Success);
			yield return new OperationStatus(UnKnown);
		}
	}
	public static OperationStatus Create(string value) { 
		var found = Supported.SingleOrDefault(x => x.Status == value);
		if (string.IsNullOrEmpty(found.Status)) throw new NotSupportedException();
		return found;
	}
	public static implicit operator OperationStatus(string status) => Create(status);
	public static implicit operator string(OperationStatus status) => Create(status);
	public static implicit operator bool(OperationStatus status) => status.Status == Success;

}