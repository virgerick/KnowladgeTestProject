
namespace Api.Core.Syncfusion;

public enum VersionType
{
    Excel97to2003,
    Excel2007,
    Excel2010,
    Excel2013,
    Excel2016,
    Xlsx
}


public class FileType 
{
    private FileType(string extension,string name, string mimeType)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(extension);
        ArgumentException.ThrowIfNullOrEmpty(mimeType);

        Name = name;
        Extension = extension;
        MimeType = mimeType;
    }
    public string Name { get; private set; }
    public string Extension { get; private set; }
    public string MimeType { get; private set; }
    public static IEnumerable<FileType> Supported
    {
        get
        {
            yield return new(".aac", "Archivo de audio AAC", "audio/aac");
            yield return new(".abw", "Documento AbiWord", "application/x-abiword");
            yield return new(".arc", "Documento de Archivo (múltiples archivos incrustados)", "application/octet-stream");
            yield return new(".avi", "AVI: Audio Video Intercalado", "video/x-msvideo");
            yield return new(".azw", "Formato eBook Amazon Kindle", "application/vnd.amazon.ebook");
            yield return new(".bin", "Cualquier tipo de datos binarios", "application/octet-stream");
            yield return new(".bz", "Archivo BZip", "application/x-bzip");
            yield return new(".bz2", "Archivo BZip2", "application/x-bzip2");
            yield return new(".csh", "Script C-Shell", "application/x-csh");
            yield return new( ".css", "Hojas de estilo (CSS)", "text/css");
            yield return new( ".csv", "Valores separados por coma (CSV)", "text/csv");
            yield return new( ".doc", "Microsoft Word", "application/msword");
            yield return new( ".epub", "Publicación Electrónica (EPUB)", "application/epub+zip");
            yield return new( ".gif", "Graphics Interchange Format (GIF)", "image/gif");
            yield return new( ".htm", "Hipertexto (HTML)", "text/html");
            yield return new( ".html", "Hipertexto (HTML)", "text/html");
            yield return new( ".ico", "Formato Icon", "image/x-icon");
            yield return new( ".ics", "Formato iCalendar", "text/calendar");
            yield return new( ".jar", "Archivo Java (JAR)", "application/java-archive");
            yield return new( ".jpeg", "Imágenes JPEG", "image/jpeg");
            yield return new( ".jpg", "Imágenes JPEG", "image/jpeg");
            yield return new( ".js", "JavaScript (ECMAScript)", "application/javascript");
            yield return new( ".json", "Formato JSON", "application/json");
            yield return new( ".mid", "Interfaz Digital de Instrumentos Musicales (MIDI)", "audio/midi");
            yield return new( ".midi", "Interfaz Digital de Instrumentos Musicales (MIDI)", "audio/midi");
            yield return new( ".mpeg", "Video MPEG", "video/mpeg");
            yield return new( ".mpkg", "Paquete de instalación de Apple", "application/vnd.apple.installer+xml");
            yield return new( ".odp", "Documento de presentación de OpenDocument", "application/vnd.oasis.opendocument.presentation");
            yield return new( ".ods", "Hoja de Cálculo OpenDocument", "application/vnd.oasis.opendocument.spreadsheet");
            yield return new( ".odt", "Documento de texto OpenDocument", "application/vnd.oasis.opendocument.text");
            yield return new( ".oga", "Audio OGG", "audio/ogg");
            yield return new( ".ogv", "Video OGG", "video/ogg");
            yield return new( ".ogx", "OGG", "application/ogg");
            yield return new( ".pdf", "Adobe Portable Document Format (PDF)", "application/pdf");
            yield return new( ".ppt", "Microsoft PowerPoint", "application/vnd.ms-powerpoint");
            yield return new( ".rar", "Archivo RAR", "application/x-rar-compressed");
            yield return new( ".rtf", "Formato de Texto Enriquecido (RTF)", "application/rtf");
            yield return new( ".sh", "Script Bourne shell", "application/x-sh");
            yield return new( ".svg", "Gráficos Vectoriales (SVG)", "image/svg+xml");
            yield return new( ".swf", "Small web format (SWF) o Documento Adobe Flash", "application/x-shockwave;flash");
            yield return new( ".tar", "Archivo Tape (TAR)", "application/x-tar");
            yield return new( ".tif", "Formato de archivo de imagen etiquetado (TIFF)", "image/tiff");
            yield return new( ".tiff", "Formato de archivo de imagen etiquetado (TIFF)", "image/tiff");
            yield return new( ".ttf", "Fuente TrueType", "font/ttf");
            yield return new( ".vsd", "Microsoft Visio", "application/vnd.visio");
            yield return new( ".wav", "Formato de audio de forma de onda (WAV)", "audio/x-wav");
            yield return new( ".weba", "Audio WEBM", "audio/webm");
            yield return new( ".webm", "Video WEBM", "video/webm");
            yield return new( ".webp", "Imágenes WEBP", "image/webp");
            yield return new( ".woff", "Formato de fuente abierta web (WOFF)", "font/woff");
            yield return new( ".woff2", "Formato de fuente abierta web (WOFF)", "font/woff2");
            yield return new( ".xhtml", "XHTML", "application/xhtml+xml");
            yield return new( ".xls", "Microsoft Excel", "application/vnd.ms-excel");
            yield return new(".xlsx", "Microsoft Excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            yield return new( ".xml", "XML", "application/xml");
            yield return new( ".xul", "XUL", "application/vnd.mozilla.xul+xml");
            yield return new( ".zip", "Archivo ZIP", "application/zip");
            yield return new( ".3gp", "Contenedor de audio/video 3GPP", "video/3gpp audio/3gpp if it doesn't contain;video");
            yield return new( ".3g2", "Contenedor de audio/video 3GPP2", "video/3gpp2 audio/3gpp2 if it doesn't contain;video");
            yield return new( ".7z", "Archivo 7-zip", "application/x-7z-compressed");
        }
    }
}
