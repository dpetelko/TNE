﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos
{
    public class SubDivisionDto : DivisionDto, IEquatable<SubDivisionDto>
    {
        [NotEmptyGuid("Выберите значение")]
        public Guid LeadDivisionId { get; set; }
        [Display(Name = "Головная огранизация")]
        public string LeadDivisionName { get; set; }

        public SubDivisionDto() { }

        public override string ToString()
        {
            return $"SubDivisionDto" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"PostCode:{PostCode}, " +
                $"Country:{Country}, " +
                $"Region:{Region}, " +
                $"City:{City}, " +
                $"Street:{Street}, " +
                $"Building:{Building}, " +
                $"LeadDivisionName:{LeadDivisionName} " +
                $"Deleted:{Deleted} ]";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SubDivisionDto);
        }

        public bool Equals(SubDivisionDto other)
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
