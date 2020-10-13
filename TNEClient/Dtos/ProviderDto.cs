using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos
{
    public class ProviderDto : DivisionDto, IEquatable<ProviderDto>
    {
        [Required]
        public Guid SubDivisionId { get; set; }
        [Display(Name = "Дочерняя огранизация")]
        public string SubDivisionName { get; set; }

        public ProviderDto() { }
        
        public override string ToString()
        {
            return $"ProviderDto" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"PostCode:{PostCode}, " +
                $"Country:{Country}, " +
                $"Region:{Region}, " +
                $"City:{City}, " +
                $"Street:{Street}, " +
                $"Building:{Building}, " +
                $"SubDivisionName:{SubDivisionName} " +
                $"Deleted:{Deleted}  ]";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProviderDto);
        }

        public bool Equals(ProviderDto other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Id.Equals(other.Id) &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id, Name);
        }
    }
}
