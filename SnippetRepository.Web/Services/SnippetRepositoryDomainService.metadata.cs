
namespace SnippetRepository.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies SnippetMetadata as the class
    // that carries additional metadata for the Snippet class.
    [MetadataTypeAttribute(typeof(Snippet.SnippetMetadata))]
    public partial class Snippet
    {

        // This class allows you to attach custom attributes to properties
        // of the Snippet class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SnippetMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SnippetMetadata()
            {
            }

            public string Code { get; set; }

            public DateTime DateAdded { get; set; }

            public DateTime DateLastViewed { get; set; }

            public Nullable<DateTime> DateModified { get; set; }

            public string Description { get; set; }

            public int Id { get; set; }

            public string Source { get; set; }

            public string Tags { get; set; }

            public string Title { get; set; }

            public string Usage { get; set; }

            public short Views { get; set; }
        }
    }
}
