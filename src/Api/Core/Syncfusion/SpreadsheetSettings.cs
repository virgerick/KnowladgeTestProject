namespace Api.Core.Syncfusion;

public class SpreadsheetSettings
{
    public string SaveUrl { get; set; }
    public string OpenUrl { get; set; }
    public bool EnableRtl { get; set; }
    public string Locale { get; set; }
    public bool EnablePersistence { get; set; }
    public CellStyle CellStyle { get; set; }
    public bool ShowRibbon { get; set; }
    public bool ShowFormulaBar { get; set; }
    public bool ShowSheetTabs { get; set; }
    public bool AllowEditing { get; set; }
    public bool AllowOpen { get; set; }
    public bool AllowSave { get; set; }
    public bool EnableContextMenu { get; set; }
    public bool AllowAutoFill { get; set; }
    public SelectionSettings SelectionSettings { get; set; }
    public bool EnableKeyboardNavigation { get; set; }
    public bool AllowNumberFormatting { get; set; }
    public bool EnableKeyboardShortcut { get; set; }
    public bool EnableClipboard { get; set; }
    public bool AllowCellFormatting { get; set; }
    public bool AllowSorting { get; set; }
    public bool AllowResizing { get; set; }
    public bool AllowHyperlink { get; set; }
    public bool AllowUndoRedo { get; set; }
    public bool AllowFiltering { get; set; }
    public bool AllowWrap { get; set; }
    public bool AllowInsert { get; set; }
    public bool AllowDelete { get; set; }
    public bool AllowDataValidation { get; set; }
    public bool AllowFindAndReplace { get; set; }
    public bool AllowMerge { get; set; }
    public bool AllowConditionalFormat { get; set; }
    public bool AllowImage { get; set; }
    public bool AllowChart { get; set; }
    public int ActiveSheetIndex { get; set; }
    public string CssClass { get; set; }
    public string Height { get; set; }
    public string Width { get; set; }
    public bool AllowScrolling { get; set; }
    public ScrollSettings ScrollSettings { get; set; }
    public bool AllowFreezePane { get; set; }
    public List<object> DefinedNames { get; set; }
    public bool IsProtected { get; set; }
    public string Password { get; set; }
    public AutoFillSettings AutoFillSettings { get; set; }
    public bool ShowAggregate { get; set; }
    public List<object> FilterCollection { get; set; }
    public List<object> SortCollection { get; set; }
    public List<Sheet> Sheets { get; set; }
}
