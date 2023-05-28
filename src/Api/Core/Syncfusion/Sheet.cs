namespace Api.Core.Syncfusion;

public class Sheet
{
    public List<Column> Columns { get; set; }
    public string Name { get; set; }
    public List<Row> Rows { get; set; }
    public string SelectedRange { get; set; }
    public UsedRange UsedRange { get; set; }
}
