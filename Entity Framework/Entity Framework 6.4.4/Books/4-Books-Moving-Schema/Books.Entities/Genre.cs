// Add Reference to C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.ComponentModel.DataAnnotations.dll
using System.ComponentModel.DataAnnotations;

namespace Books.Entities
{
    public enum Genre
    {
        [Display(Name = "Non Fiction")]
        NonFiction,
        Romance,
        Action,
        [Display(Name = "Science Fiction")]
        ScienceFiction
    }
}
