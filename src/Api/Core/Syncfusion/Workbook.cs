using System;
namespace Api.Core.Syncfusion;

public class Workbook
{
    public List<object> FilterCollection { get; set; }
    public List<object> SortCollection { get; set; }
    public List<DefinedName> DefinedNames { get; set; }
    public List<Sheet> Sheets { get; set; }
}

public class OpenFromFileResponse
{
    public Workbook Workbook { get; set; }
}
