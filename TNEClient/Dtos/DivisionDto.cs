﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos
{
    public class DivisionDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Введите значение")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The {0} length must be between {2} and {1} characters.")]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        public Guid AddressId { get; set; }
        [Display(Name = "Индекс")]
        public string PostCode { get; set; }
        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Страна")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Регион")]
        public string Region { get; set; }
        [Display(Name = "Населенный пункт")]
        public string City { get; set; }
        [Display(Name = "Улица")]
        public string Street { get; set; }
        [Display(Name = "Строение")]
        public string Building { get; set; }
        [Required]
        public bool Deleted { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DivisionDto dto &&
                   Id.Equals(dto.Id) &&
                   Name == dto.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }

}
