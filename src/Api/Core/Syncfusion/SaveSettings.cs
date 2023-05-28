namespace Api.Core.Syncfusion;


public class SaveSettings
{
    private SaveType saveType;

    public Uri SaveUrl { get; set; }

    public string JSONData { get; set; }

    public SaveType SaveType
    {
        get
        {
            return saveType;
        }
        set
        {
            saveType = value;
            switch (saveType)
            {
                case SaveType.Xlsx:
                    VersionType = VersionType.Xlsx;
                    FileContentType = ContentType.Xlsx;
                    break;
                case SaveType.Xls:
                    VersionType = VersionType.Excel97to2003;
                    FileContentType = ContentType.Excel2000;
                    break;
                case SaveType.Csv:
                    VersionType = VersionType.Xlsx;
                    FileContentType = ContentType.CSV;
                    break;
                case SaveType.Pdf:
                    VersionType = VersionType.Xlsx;
                    FileContentType = ContentType.PDF;
                    break;
            }
        }
    }

    public string FileName { get; set; }

    public ContentType FileContentType { get; set; }

    public VersionType VersionType { get; set; }

    public string PdfLayoutSettings { get; set; }

    public string GetContentType()
    {
        string result = string.Empty;
        switch (FileContentType)
        {
            case ContentType.Excel97:
            case ContentType.Excel2000:
                result = "application/vnd.ms-excel";
                break;
            case ContentType.Excel2007:
            case ContentType.Excel2010:
            case ContentType.Excel2013:
            case ContentType.Excel2016:
            case ContentType.Xlsx:
                result = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                break;
            case ContentType.CSV:
                result = "text/csv";
                break;
            case ContentType.PDF:
                result = "application/pdf";
                break;
        }
        return result;
    }
}
