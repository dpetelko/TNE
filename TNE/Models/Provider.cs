using System;
using System.ComponentModel.DataAnnotations.Schema;
using TNE.Dto;

namespace TNE.Models
{
    public class Provider : Division, IEquatable<Provider>
    {
        public Guid? SubDivisionId { get; set; }
        [ForeignKey("SubDivisionId")]
        public SubDivision SubDivision { get; set; }
        //public List<ControlPoint> ControlPoints { get; set; }
        //public List<DeliveryPoint> DeliveryPoints { get; set; }

        public Provider() { }

        public Provider(ProviderDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            Id = dto.Id;
            Name = dto.Name;
            AddressId = dto.AddressId;
            Address.PostCode = dto.PostCode;
            Address.Country = dto.Country;
            Address.Region = dto.Region;
            Address.City = dto.City;
            Address.Street = dto.Street;
            Address.Building = dto.Building;
            Deleted = dto.Deleted;
            SubDivisionId = dto.SubDivisionId;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Provider);
        }

        public bool Equals(Provider other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        public override string ToString()
        {
            return $"Provider" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"Address:{Address}, " +
                $"SubDivision:{SubDivision} " +
                $"Deleted:{Deleted} ]";
        }

    }
}