namespace Api.Exceptions;
public class NotFoundException:Exception
{
	public NotFoundException() : base() { }
	public NotFoundException(string message) : base(message) { }
	public NotFoundException(string message,Exception innerException) : base(message,innerException) { }
	public NotFoundException(object Key,Type type) : base($"The Entity '{type.Name}' '{Key}' was not found.") { }
	public NotFoundException(object Key,string type) : base($"The Entity '{type}' '{Key}' was not found.") { }

}

public class ExistingRecordException:Exception
{
	public ExistingRecordException() : base() { }
	public ExistingRecordException(string message) : base(message) { }
	public ExistingRecordException(string message,Exception innerException) : base(message,innerException) { }
	public ExistingRecordException(object Key,Type type) : base($"The Entity '{type.Name}' already has a record '{Key}'.") { }
	public ExistingRecordException(object Key,string type) : base($"The Entity '{type}' already has a record '{Key}'.") { }

}

