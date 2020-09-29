﻿using System;
using TNE.Models;

namespace TNE.Dto
{
    public class ProviderDto : DivisionDto, IEquatable<ProviderDto>
    {
        public Guid SubDivisionId { get; set; }
        public string SubDivisionName { get; set; }

        public ProviderDto() { }

        public ProviderDto(Provider entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Deleted = entity.Deleted;
            AddressId = entity.Address.Id;
            PostCode = entity.Address.PostCode;
            Country = entity.Address.Country;
            Region = entity.Address.Region;
            City = entity.Address.City;
            Street = entity.Address.Street;
            Building = entity.Address.Building;
            SubDivisionId = entity.SubDivision.Id;
            SubDivisionName = entity.SubDivision.Name;
        }

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
