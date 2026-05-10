namespace System.Xml.Serialization
{
    using System;
    using System.CodeDom;

    internal sealed class XmlCodeExporter
    {
        public XmlCodeExporter(CodeNamespace codeNamespace)
        {
            _ = codeNamespace;
        }

        public void ExportTypeMapping(XmlTypeMapping map)
        {
            throw new PlatformNotSupportedException("XmlCodeExporter is not available on .NET 10. Use an alternate schema-to-code generation path for Intuit.Ipp.XsdExtension.");
        }
    }
}